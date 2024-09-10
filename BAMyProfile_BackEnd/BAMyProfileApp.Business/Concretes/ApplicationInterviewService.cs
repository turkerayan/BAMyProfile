using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    /// <summary>
    /// Mülakat işlemlerini yapan servis
    /// </summary>
    public class ApplicationInterviewService : IApplicationInterviewService
    {
        private readonly IApplicationInterviewRepository _applicationInterviewRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public ApplicationInterviewService(IApplicationInterviewRepository applicationInterviewRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer, IApplicationRepository applicationRepository)
        {
            _applicationInterviewRepository = applicationInterviewRepository;
            _mapper = mapper;
            _localizer = localizer;
            _applicationRepository = applicationRepository;
        }

        /// <summary>
        /// Yeni bir mülakat ekler
        /// </summary>
        /// <param name="appInterviewCreateDTO">Yeni eklenecek mülakat bilgilerini içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        public async Task<IResult> CreateAsync(ApplicationInterviewCreateDTO appInterviewCreateDTO)
        {

            var newAppInterview = _mapper.Map<ApplicationInterview>(appInterviewCreateDTO);
            await _applicationInterviewRepository.AddAsync(newAppInterview);
            await _applicationInterviewRepository.SaveChangesAsync();
            var interviewDto = _mapper.Map<ApplicationInterviewDTO>(newAppInterview);
            return new SuccessDataResult<ApplicationInterviewDTO>(interviewDto, _localizer[Messages.ApplicationInterviewAddSuccess]);
        }

        /// <summary>
        /// Bir mülakatı siler
        /// </summary>
        /// <param name="id">Silinecek mülakat idsi</param>
        /// <returns>İşlemin başarı durumunu döner</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var appInterview = await _applicationInterviewRepository.GetByIdAsync(id);
            if (appInterview == null) { return new ErrorResult(_localizer[Messages.ApplicationInterviewNotFound]); }
            await _applicationInterviewRepository.DeleteAsync(appInterview);
            await _applicationInterviewRepository.SaveChangesAsync();
            return new SuccessResult(_localizer[Messages.ApplicationInterviewDeletedSuccess]);
        }

        /// <summary>
        /// Mülakatları listeler
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetAllAsync()
        {
            var interviews = await _applicationInterviewRepository.GetAllAsync();
            if (interviews.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoApplicationInterviews]); }
            var interviewListDto = _mapper.Map<List<ApplicationInterviewListDTO>>(interviews);
            return new SuccessDataResult<List<ApplicationInterviewListDTO>>(interviewListDto, _localizer[Messages.ApplicationInterviewListedSuccess]);
        }

        /// <summary>
        /// Id ye göre mülakat detaylarını getirir
        /// </summary>
        /// <param name="id">Mülakat idsi</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var interview = await _applicationInterviewRepository.GetByIdAsync(id);
            if (interview == null) { return new ErrorResult(_localizer[Messages.ApplicationInterviewNotFound]); }
            var interviewDto = _mapper.Map<ApplicationInterviewDTO>(interview);
            return new SuccessDataResult<ApplicationInterviewDTO>(interviewDto, _localizer[Messages.ApplicationInterviewFoundSuccess]);
        }

        /// <summary>
        /// Mülakatı günceller
        /// </summary>
        /// <param name="appInterviewUpdateDTO">Güncellenecek mülakat bilgisini içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        public async Task<IResult> UpdateAsync(ApplicationInterviewUpdateDTO appInterviewUpdateDTO)
        {
            var interview = await _applicationInterviewRepository.GetByIdAsync(appInterviewUpdateDTO.Id);
            if (interview == null) { return new ErrorResult(_localizer[Messages.ApplicationInterviewNotFound]); }
            var updatedInterview = _mapper.Map(appInterviewUpdateDTO, interview);
            await _applicationInterviewRepository.UpdateAsync(updatedInterview);
            await _applicationInterviewRepository.SaveChangesAsync();
            return new SuccessDataResult<ApplicationInterviewDTO>(_mapper.Map<ApplicationInterviewDTO>(updatedInterview), _localizer[Messages.ApplicationInterviewUpdateSuccess]);
        }
        /// <summary>
        /// Şirket Idsine göre mülakatları getirir
        /// </summary>
        /// <param name="companyId">Şirket Idsi</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetInterviewsByCompanyIdAsync(Guid companyId)
        {
            var interviews = await _applicationInterviewRepository.GetAllAsync(x => x.CompanyId == companyId);
            if (interviews.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoApplicationInterviews]); }
            var interviewListDto = _mapper.Map<List<ApplicationInterviewListDTO>>(interviews);
            return new SuccessDataResult<List<ApplicationInterviewListDTO>>(interviewListDto, _localizer[Messages.ApplicationInterviewListedSuccess]);


        }
        /// <summary>
        /// Aday Id sine göre mülakatları listeler
        /// </summary>
        /// <param name="candidateId">Aday Id si</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetInterviewsByCandidateIdAsync(Guid candidateId)
        { 
            var applications = await _applicationRepository.GetAllAsync(x => x.CandidateId == candidateId);

            if (applications.Count() <= 0)
            {
                return new ErrorResult(_localizer[Messages.ListHasNoApplications]);
            }

            var interviewList = new List<ApplicationInterviewListDTO>();
            foreach (var application in applications)
            {
                var interviews = await _applicationInterviewRepository.GetAllAsync(x => x.ApplicationId == application.Id);
                if (interviews.Any())
                {
                    var interviewListDto = _mapper.Map<List<ApplicationInterviewListDTO>>(interviews);
                    interviewList.AddRange(interviewListDto);
                }
            }


            if (interviewList.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoApplicationInterviews]); }

            return new SuccessDataResult<List<ApplicationInterviewListDTO>>(interviewList, _localizer[Messages.ApplicationInterviewListedSuccess]);

        }

    }

}

