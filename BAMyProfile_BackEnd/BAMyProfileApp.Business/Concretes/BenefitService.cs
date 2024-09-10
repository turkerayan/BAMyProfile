using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Benefit;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.Business.Concretes;

public class BenefitService : IBenefitService
{
    private readonly IBenefitRepository _benefitRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public BenefitService(IBenefitRepository benefitRepository, IStringLocalizer<MessageResources> localizer, IMapper mapper = null)
    {
        _benefitRepository = benefitRepository;
        _mapper = mapper;
        _localizer = localizer;
    }

    /// <summary>
    /// Adds a new benefit.
    /// </summary>
    /// <param name="benefitCreateDTO">DTO containing the data of the benefit to be added.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> CreateAsync(BenefitCreateDTO benefitCreateDTO)
    {
        var isBenefitExists = await _benefitRepository
            .AnyAsync(b => b.Name.ToLower() == benefitCreateDTO.Name.ToLower());
        if (isBenefitExists) { return new ErrorResult(_localizer[Messages.BenefitAlreadyExists]); }

        var newBenefit = _mapper.Map<Benefit>(benefitCreateDTO);
        await _benefitRepository.AddAsync(newBenefit);
        await _benefitRepository.SaveChangesAsync();
        var benefitDto = _mapper.Map<BenefitDTO>(newBenefit);
        return new SuccessDataResult<BenefitDTO>(benefitDto, _localizer[Messages.BenefitAddSuccess]);
    }

    /// <summary>
    /// Deletes the specified benefit.
    /// </summary>
    /// <param name="id">The identifier of the Benefit to be deleted.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var benefit = await _benefitRepository.GetByIdAsync(id);
        if (benefit == null) { return new ErrorResult(_localizer[Messages.BenefitNotFound]); }
        await _benefitRepository.DeleteAsync(benefit);
        await _benefitRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.BenefitDeletedSuccess]);
    }

    /// <summary>
    /// Lists all benefits.
    /// </summary>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var benefits = await _benefitRepository.GetAllAsync();
        if (!benefits.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoBenefits]); }
        var benefitListDto = _mapper.Map<List<BenefitListDTO>>(benefits);
        return new SuccessDataResult<List<BenefitListDTO>>(benefitListDto, _localizer[Messages.BenefitListedSuccess]);
    }

    /// <summary>
    /// Retrieves the details of the specified benefit.
    /// </summary>
    /// <param name="id">The identifier of the benefit whose details will be retrieved.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var benefit = await _benefitRepository.GetByIdAsync(id);
        if (benefit == null) { return new ErrorResult(_localizer[Messages.BenefitNotFound]); }
        var benefitDto = _mapper.Map<BenefitDTO>(benefit);
        return new SuccessDataResult<BenefitDTO>(benefitDto, _localizer[Messages.BenefitFoundSuccess]);
    }

    /// <summary>
    /// Updates the specified benefit.
    /// </summary>
    /// <param name="benefitUpdateDTO">DTO containing the data of the benefit to be updated.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> UpdateAsync(BenefitUpdateDTO benefitUpdateDTO)
    {
        var benefit = await _benefitRepository.GetByIdAsync(benefitUpdateDTO.Id);
        if (benefit == null) { return new ErrorResult(_localizer[Messages.BenefitNotFound]); }
        var updatedBenefit = _mapper.Map(benefitUpdateDTO, benefit);
        await _benefitRepository.UpdateAsync(updatedBenefit);
        await _benefitRepository.SaveChangesAsync();
        return new SuccessDataResult<BenefitDTO>(_mapper.Map<BenefitDTO>(updatedBenefit), _localizer[Messages.BenefitUpdateSuccess]);
    }
}