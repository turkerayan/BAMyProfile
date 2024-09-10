using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.JobSkill;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Concretes;

public class JobSkillService : IJobSkillService
{
    private readonly IJobSkillRepository _jobSkillRepository;
    private readonly IMapper _mapper;

    public JobSkillService(IJobSkillRepository jobSkillRepository, IMapper mapper)
    {
        _jobSkillRepository = jobSkillRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Adds a new jobSkill.
    /// </summary>
    /// <param name="jobSkillCreateDTO">DTO containing the data of the job to be added.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> CreateAsync(JobSkillCreateDTO jobSkillCreateDTO)
    {
        if (await _jobSkillRepository.AnyAsync(jb =>
            jb.JobId == jobSkillCreateDTO.JobId
            && jb.SkillId == jobSkillCreateDTO.SkillId))
        {
            return new ErrorResult(Messages.JobSkillAlreadyExists);
        }

        var newJobSkill = _mapper.Map<JobSkill>(jobSkillCreateDTO);
        await _jobSkillRepository.AddAsync(newJobSkill);
        await _jobSkillRepository.SaveChangesAsync();

        var jobSkillDto = _mapper.Map<JobSkillDTO>(newJobSkill);
        return new SuccessDataResult<JobSkillDTO>(jobSkillDto, Messages.JobSkillAddSuccess);
    }

    /// <summary>
    /// Deletes the specified job skill.
    /// </summary>
    /// <param name="id">The identifier of the Job Skill to be deleted.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var jobSkill = await _jobSkillRepository.GetByIdAsync(id);
        if (jobSkill == null) return new ErrorResult(Messages.JobSkillNotFound);

        await _jobSkillRepository.DeleteAsync(jobSkill);
        await _jobSkillRepository.SaveChangesAsync();
        return new SuccessResult(Messages.JobSkillDeletedSuccess);
    }

    /// <summary>
    /// Lists all job skills.
    /// </summary>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var jobSkills = await _jobSkillRepository.GetAllAsync();
        if (!jobSkills.Any()) return new ErrorResult(Messages.ListHasNoJobSkills);

        var jobSkillListDto = _mapper.Map<List<JobSkillListDTO>>(jobSkills);
        return new SuccessDataResult<List<JobSkillListDTO>>(jobSkillListDto, Messages.JobSkillListedSuccess);
    }

    /// <summary>
    /// Retrieves the details of the specified job skill.
    /// </summary>
    /// <param name="id">The identifier of the job skill whose details will be retrieved.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var jobSkill = await _jobSkillRepository.GetByIdAsync(id);
        if (jobSkill == null) return new ErrorResult(Messages.JobSkillNotFound);

        var jobSkillDto = _mapper.Map<JobSkillDTO>(jobSkill);
        return new SuccessDataResult<JobSkillDTO>(jobSkillDto, Messages.JobSkillFoundSuccess);
    }

    /// <summary>
    /// Updates the specified job skill.
    /// </summary>
    /// <param name="jobSkillUpdateDTO">DTO containing the data of the job skill to be updated.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> UpdateAsync(JobSkillUpdateDTO jobSkillUpdateDTO)
    {
        if (await _jobSkillRepository.AnyAsync(jb =>
            jb.JobId == jobSkillUpdateDTO.JobId
            && jb.SkillId == jobSkillUpdateDTO.SkillId))
        {
            return new ErrorResult(Messages.JobSkillAlreadyExists);
        }

        var jobSkill = await _jobSkillRepository.GetByIdAsync(jobSkillUpdateDTO.Id);
        if (jobSkill == null) return new ErrorResult(Messages.JobSkillNotFound);

        var updatedJobSkill = _mapper.Map(jobSkillUpdateDTO, jobSkill);
        await _jobSkillRepository.UpdateAsync(updatedJobSkill);
        await _jobSkillRepository.SaveChangesAsync();

        return new SuccessDataResult<JobSkillDTO>(_mapper.Map<JobSkillDTO>(updatedJobSkill), Messages.JobSkillUpdateSuccess);
    }
}