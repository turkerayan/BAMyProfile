using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.EFCore.Repositories;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Application;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    /// <summary>
    /// Başvuru işlemlerini yapan servis
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;
        private readonly IJobRepository _jobRepository;
        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer, IJobRepository jobRepository)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _localizer = localizer;
            _jobRepository = jobRepository;
        }
        /// <summary>
        /// Yeni bir başvuru ekler.
        /// </summary>
        /// <param name="applicationCreateDTO">Yeni başvuruya ait bilgileri içerir. </param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        public async Task<IResult> CreateAsync(ApplicationCreateDTO applicationCreateDTO)
        {
            var newApplication = _mapper.Map<Application>(applicationCreateDTO);
            await _applicationRepository.AddAsync(newApplication);
            await _applicationRepository.SaveChangesAsync();
            var applicationDto = _mapper.Map<ApplicationDTO>(newApplication);
            return new SuccessDataResult<ApplicationDTO>(applicationDto, _localizer[Messages.ApplicationAddSuccess]);
        }
        /// <summary>
        /// Bir başvuru siler
        /// </summary>
        /// <param name="id">Silinecek başvuruya ait id</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null) { return new ErrorResult(_localizer[Messages.ApplicationNotFound]); }
            await _applicationRepository.DeleteAsync(application);
            await _applicationRepository.SaveChangesAsync();
            return new SuccessResult(_localizer[Messages.ApplicationDeletedSuccess]);
        }
        /// <summary>
        /// Tüm başvuruları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetAllAsync()
        {
            var applications = await _applicationRepository.GetAllAsync();
            if (applications.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoApplications]); }
            var applicationListDto = _mapper.Map<List<ApplicationListDTO>>(applications);
            return new SuccessDataResult<List<ApplicationListDTO>>(applicationListDto, _localizer[Messages.ApplicationListedSuccess]);
        }
        /// <summary>
        /// Id ye göre başvuruya ait detayları getirir.
        /// </summary>
        /// <param name="id">Detayları getirilecek başvuruya ait id</param>
        /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null) { return new ErrorResult(_localizer[Messages.ApplicationNotFound]); }
            var applicationDto = _mapper.Map<ApplicationDTO>(application);
            return new SuccessDataResult<ApplicationDTO>(applicationDto, _localizer[Messages.ApplicationFoundSuccess]);
        }
        /// <summary>
        /// Bir başvuruyu günceller.
        /// </summary>
        /// <param name="applicationUpdateDTO">Güncellenecek başvuruya ait bilgileri içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        public async Task<IResult> UpdateAsync(ApplicationUpdateDTO applicationUpdateDTO)
        {
            var application = await _applicationRepository.GetByIdAsync(applicationUpdateDTO.Id);
            if (application == null) { return new ErrorResult(_localizer[Messages.ApplicationNotFound]); }
            var updatedApplication = _mapper.Map(applicationUpdateDTO, application);
            await _applicationRepository.UpdateAsync(updatedApplication);
            await _applicationRepository.SaveChangesAsync();
            return new SuccessDataResult<ApplicationDTO>(_mapper.Map<ApplicationDTO>(updatedApplication), _localizer[Messages.ApplicationUpdateSuccess]);
        }
        /// <summary>
        /// Aday Idsinie göre Basvuru Günceller.
        /// </summary>
        /// <param name="candidateId">Başvuruya ait aday Idsini içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        public async Task<IResult> GetApplicationsByCandidateIdAsync(Guid candidateId)
        {
            var applications = await _applicationRepository.GetAllAsync(x => x.CandidateId == candidateId);
            var applicationWithJob = applications.AsQueryable().Include(x => x.Job).ToListAsync();

            if (applications.Count() <= 0)
            {
                return new ErrorResult(_localizer[Messages.ListHasNoApplications]);
            }
           
            var applicationListDto = _mapper.Map<List<ApplicationListWithJobDTO>>(applications);
            return new SuccessDataResult<List<ApplicationListWithJobDTO>>(applicationListDto, _localizer[Messages.ApplicationListedSuccess]);

        }

    }
}
