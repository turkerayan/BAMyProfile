using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.CompanyContactInformation;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    public class CompanyContactInformationService : ICompanyContactInformationService
    {
        private readonly ICompanyContactInformationRepository _companyContactInformationRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public CompanyContactInformationService(ICompanyContactInformationRepository companyContactInformationRepository, 
            ICompanyRepository companyRepository,
            IMapper mapper, 
            IStringLocalizer<MessageResources> localizer)
        {
            _companyContactInformationRepository = companyContactInformationRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        /// <summary>
        /// Şirket iletişim bilgisi ekler.
        /// </summary>
        /// <param name="companyContactInformationCreateDTO">Şirket iletişim bilgisi ekleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> CreateAsync(CompanyContactInformationCreateDTO companyContactInformationCreateDTO)
        {
            var hasCompany = await _companyRepository.AnyAsync(company => company.Id == companyContactInformationCreateDTO.CompanyId);
            if (!hasCompany) { return new ErrorResult(_localizer[Messages.CompanyNotFound]); }

            var newCompanyContactInformation = _mapper.Map<CompanyContactInformation>(companyContactInformationCreateDTO);
            await _companyContactInformationRepository.AddAsync(newCompanyContactInformation);
            await _companyContactInformationRepository.SaveChangesAsync();

            var companyContactInformationDto = _mapper.Map<CompanyContactInformationDTO>(newCompanyContactInformation);
            return new SuccessDataResult<CompanyContactInformationDTO>(companyContactInformationDto, _localizer[Messages.CompanyContactInformationAddSuccess]);
        }
        
        /// <summary>
        /// Şirket iletişim bilgisi siler.
        /// </summary>
        /// <param name="id">Şirket iletişim bilgisi tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var companyContactInformation = await _companyContactInformationRepository.GetByIdAsync(id);
            if (companyContactInformation == null) { return new ErrorResult(_localizer[Messages.CompanyContactInformationNotFound]); }

            await _companyContactInformationRepository.DeleteAsync(companyContactInformation);
            await _companyContactInformationRepository.SaveChangesAsync();

            return new SuccessResult(_localizer[Messages.CompanyContactInformationDeletedSuccess]);
        }
        
        /// <summary>
        /// Şirket iletişim bilgilerini verir.
        /// </summary>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> GetAllAsync()
        {
            var companyContactInformations = await _companyContactInformationRepository.GetAllAsync();
            if (!companyContactInformations.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoCompanyContactInformations]); }

            var companyContactInformationListDto = _mapper.Map<List<CompanyContactInformationListDTO>>(companyContactInformations);
            return new SuccessDataResult<List<CompanyContactInformationListDTO>>(companyContactInformationListDto, _localizer[Messages.CompanyContactInformationListedSuccess]);
        }
        
        /// <summary>
        /// Şirket iletişim bilgisi verir.
        /// </summary>
        /// <param name="id">Şirket iletişim bilgisi tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var companyContactInformation = await _companyContactInformationRepository.GetByIdAsync(id);
            if (companyContactInformation == null) { return new ErrorResult(_localizer[Messages.CompanyContactInformationNotFound]); }

            var companyContactInformationDto = _mapper.Map<CompanyContactInformationDTO>(companyContactInformation);
            return new SuccessDataResult<CompanyContactInformationDTO>(companyContactInformationDto, _localizer[Messages.CompanyContactInformationFoundSuccess]);
        }
        
        /// <summary>
        /// Şirket iletişim bilgisi günceller.
        /// </summary>
        /// <param name="companyContactInformationUpdateDTO">Şirket iletişim bilgisi güncelleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> UpdateAsync(CompanyContactInformationUpdateDTO companyContactInformationUpdateDTO)
        {
            var companyContactInformation = await _companyContactInformationRepository.GetByIdAsync(companyContactInformationUpdateDTO.Id);
            if (companyContactInformation == null) { return new ErrorResult(_localizer[Messages.CompanyContactInformationNotFound]); }

            var updatedCompanyContactInformation = _mapper.Map(companyContactInformationUpdateDTO, companyContactInformation);
            await _companyContactInformationRepository.UpdateAsync(updatedCompanyContactInformation);
            await _companyContactInformationRepository.SaveChangesAsync();

            return new SuccessDataResult<CompanyContactInformationDTO>(_mapper.Map<CompanyContactInformationDTO>(updatedCompanyContactInformation), _localizer[Messages.CompanyContactInformationUpdateSuccess]);
        }

        /// <summary>
        /// Şirket iletişim bilgilerini şirket tanımlayıcısına göre verir.
        /// </summary>
        /// <param name="companyId">Şirket bilgisi tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> GetAllByCompanyId(Guid companyId)
        {
            var hasCompany = await _companyRepository.AnyAsync(c => c.Id == companyId);
            if (!hasCompany) { return new ErrorResult(_localizer[Messages.CompanyNotFound]); }

            var companyContactInformations = await _companyContactInformationRepository.GetAllAsync(c => c.CompanyId == companyId);
            if (!companyContactInformations.Any()) { return new ErrorResult(_localizer[Messages.CompanyContactInformationNotFound]); }

            var companyContactInformationListDto = _mapper.Map<List<CompanyContactInformationListByCompanyIdDTO>>(companyContactInformations);
            return new SuccessDataResult<List<CompanyContactInformationListByCompanyIdDTO>>(companyContactInformationListDto, _localizer[Messages.CompanyContactInformationListedSuccess]);
        }
    }
}
