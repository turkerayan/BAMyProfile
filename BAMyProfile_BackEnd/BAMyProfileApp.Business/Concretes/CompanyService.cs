using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Company;
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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _localizer = localizer;
        }

        /// <summary>
        /// Şirket ekler.
        /// </summary>
        /// <param name="companyCreateDTO">Şirket ekleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> CreateAsync(CompanyCreateDTO companyCreateDTO)
        {
            var hasCompany = await _companyRepository.AnyAsync(company => company.Name.ToLower() == companyCreateDTO.Name.ToLower() && company.Location.ToLower() == companyCreateDTO.Location && company.Sector.ToLower() == companyCreateDTO.Sector.ToLower());
            if (hasCompany) { return new ErrorResult(_localizer[Messages.CompanyAlreadyExists]); }

            var newCompany = _mapper.Map<Company>(companyCreateDTO);
            await _companyRepository.AddAsync(newCompany);
            await _companyRepository.SaveChangesAsync();

            var companyDto = _mapper.Map<CompanyDTO>(newCompany);
            return new SuccessDataResult<CompanyDTO>(companyDto, _localizer[Messages.CompanyAddSuccess]);
        }

        /// <summary>
        /// Şirket siler.
        /// </summary>
        /// <param name="id">Şirket tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null) { return new ErrorResult(_localizer[Messages.CompanyNotFound]); }

            await _companyRepository.DeleteAsync(company);
            await _companyRepository.SaveChangesAsync();

            return new SuccessResult(_localizer[Messages.CompanyDeletedSuccess]);
        }

        /// <summary>
        /// Şirketleri verir.
        /// </summary>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> GetAllAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            if (!companies.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoCompanies]); }

            var companyListDto = _mapper.Map<List<CompanyListDTO>>(companies);
            return new SuccessDataResult<List<CompanyListDTO>>(companyListDto, _localizer[Messages.CompanyListedSuccess]);
        }

        /// <summary>
        /// Şirket verir.
        /// </summary>
        /// <param name="id">Şirket tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null) { return new ErrorResult(_localizer[Messages.CompanyNotFound]); }

            var companyDto = _mapper.Map<CompanyDTO>(company);
            return new SuccessDataResult<CompanyDTO>(companyDto, _localizer[Messages.CompanyFoundSuccess]);
        }

        /// <summary>
        /// Şirket günceller.
        /// </summary>
        /// <param name="companyUpdateDTO">Şirket güncelleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> UpdateAsync(CompanyUpdateDTO companyUpdateDTO)
        {
            var company = await _companyRepository.GetByIdAsync(companyUpdateDTO.Id);
            if (company == null) { return new ErrorResult(_localizer[Messages.CompanyNotFound]); }

            var updatedCompany = _mapper.Map(companyUpdateDTO, company);
            await _companyRepository.UpdateAsync(updatedCompany);
            await _companyRepository.SaveChangesAsync();

            return new SuccessDataResult<CompanyDTO>(_mapper.Map<CompanyDTO>(updatedCompany), _localizer[Messages.CompanyUpdateSuccess]);
        }
    }
}
