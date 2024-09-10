using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Skill;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.Business.Concretes;

public class SkillService : ISkillService

{
    private readonly ISkillRepository _skillRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public SkillService(ISkillRepository skillRepository, IStringLocalizer<MessageResources> localizer, IMapper mapper = null)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
        _localizer = localizer;
    }

    /// <summary>
    /// Adds a new skill.
    /// </summary>
    /// <param name="skillCreateDTO">DTO containing the data of the skill to be added.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> CreateAsync(SkillCreateDTO skillCreateDTO)
    {
        var isSkillExists = await _skillRepository
            .AnyAsync(b => b.Name.ToLower() == skillCreateDTO.Name.ToLower());
        if (isSkillExists) { return new ErrorResult(_localizer[Messages.SkillAlreadyExists]); }

        var newSkill = _mapper.Map<Skill>(skillCreateDTO);
        await _skillRepository.AddAsync(newSkill);
        await _skillRepository.SaveChangesAsync();
        var skillDto = _mapper.Map<SkillDTO>(newSkill);
        return new SuccessDataResult<SkillDTO>(skillDto, _localizer[Messages.SkillAddSuccess]);
    }

    /// <summary>
    /// Deletes the specified skill.
    /// </summary>
    /// <param name="id">The identifier of the Skill to be deleted.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var skill = await _skillRepository.GetByIdAsync(id);
        if (skill == null) { return new ErrorResult(_localizer[Messages.SkillNotFound]); }
        await _skillRepository.DeleteAsync(skill);
        await _skillRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.SkillDeletedSuccess]);
    }

    /// <summary>
    /// Lists all skills.
    /// </summary>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var skills = await _skillRepository.GetAllAsync();
        if (!skills.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoSkills]); }
        var skillListDto = _mapper.Map<List<SkillListDTO>>(skills);
        return new SuccessDataResult<List<SkillListDTO>>(skillListDto, _localizer[Messages.SkillListedSuccess]);
    }

    /// <summary>
    /// Retrieves the details of the specified skill.
    /// </summary>
    /// <param name="id">The identifier of the skill whose details will be retrieved.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var skill = await _skillRepository.GetByIdAsync(id);
        if (skill == null) { return new ErrorResult(_localizer[Messages.SkillNotFound]); }
        var skillDto = _mapper.Map<SkillDTO>(skill);
        return new SuccessDataResult<SkillDTO>(skillDto, _localizer[Messages.SkillFoundSuccess]);
    }

    /// <summary>
    /// Updates the specified skill.
    /// </summary>
    /// <param name="skillUpdateDTO">DTO containing the data of the skill to be updated.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> UpdateAsync(SkillUpdateDTO skillUpdateDTO)
    {
        var skill = await _skillRepository.GetByIdAsync(skillUpdateDTO.Id);
        if (skill == null) { return new ErrorResult(_localizer[Messages.SkillNotFound]); }
        var updatedSkill = _mapper.Map(skillUpdateDTO, skill);
        await _skillRepository.UpdateAsync(updatedSkill);
        await _skillRepository.SaveChangesAsync();
        return new SuccessDataResult<SkillDTO>(_mapper.Map<SkillDTO>(updatedSkill), _localizer[Messages.SkillUpdateSuccess]);
    }
}