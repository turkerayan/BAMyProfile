using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.JobBenefit;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Concretes;

public class JobBenefitService : IJobBenefitService
{
    private readonly IJobBenefitRepository _jobBenefitRepository;
    private readonly IMapper _mapper;

    public JobBenefitService(IJobBenefitRepository jobBenefitRepository, IMapper mapper)
    {
        _jobBenefitRepository = jobBenefitRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Adds a new job benefit.
    /// </summary>
    /// <param name="jobBenefitCreateDTO">DTO containing the data of the job to be added.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> CreateAsync(JobBenefitCreateDTO jobBenefitCreateDTO)
    {
        if (await _jobBenefitRepository.AnyAsync(jb =>
            jb.JobId == jobBenefitCreateDTO.JobId
            && jb.BenefitId == jobBenefitCreateDTO.BenefitId))
        {
            return new ErrorResult(Messages.JobBenefitAlreadyExists);
        }

        var newJobBenefit = _mapper.Map<JobBenefit>(jobBenefitCreateDTO);
        await _jobBenefitRepository.AddAsync(newJobBenefit);
        await _jobBenefitRepository.SaveChangesAsync();

        var jobBenefitDto = _mapper.Map<JobBenefitDTO>(newJobBenefit);
        return new SuccessDataResult<JobBenefitDTO>(jobBenefitDto, Messages.JobBenefitAddSuccess);
    }

    /// <summary>
    /// Deletes the specified job benefit.
    /// </summary>
    /// <param name="id">The identifier of the Job Benefit to be deleted.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var jobBenefit = await _jobBenefitRepository.GetByIdAsync(id);
        if (jobBenefit == null) return new ErrorResult(Messages.JobBenefitNotFound);

        await _jobBenefitRepository.DeleteAsync(jobBenefit);
        await _jobBenefitRepository.SaveChangesAsync();
        return new SuccessResult(Messages.JobBenefitDeletedSuccess);
    }

    /// <summary>
    /// Lists all job benefits.
    /// </summary>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var jobBenefits = await _jobBenefitRepository.GetAllAsync();
        if (!jobBenefits.Any()) return new ErrorResult(Messages.ListHasNoJobBenefits);

        var jobBenefitListDto = _mapper.Map<List<JobBenefitListDTO>>(jobBenefits);
        return new SuccessDataResult<List<JobBenefitListDTO>>(jobBenefitListDto, Messages.JobBenefitListedSuccess);
    }

    /// <summary>
    /// Retrieves the details of the specified job benefit.
    /// </summary>
    /// <param name="id">The identifier of the job benefit whose details will be retrieved.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var jobBenefit = await _jobBenefitRepository.GetByIdAsync(id);
        if (jobBenefit == null) return new ErrorResult(Messages.JobBenefitNotFound);

        var jobBenefitDto = _mapper.Map<JobBenefitDTO>(jobBenefit);
        return new SuccessDataResult<JobBenefitDTO>(jobBenefitDto, Messages.JobBenefitFoundSuccess);
    }

    /// <summary>
    /// Updates the specified job benefit.
    /// </summary>
    /// <param name="jobBenefitUpdateDTO">DTO containing the data of the job benefit to be updated.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> UpdateAsync(JobBenefitUpdateDTO jobBenefitUpdateDTO)
    {
        if (await _jobBenefitRepository.AnyAsync(jb =>
            jb.JobId == jobBenefitUpdateDTO.JobId
            && jb.BenefitId == jobBenefitUpdateDTO.BenefitId))
        {
            return new ErrorResult(Messages.JobBenefitAlreadyExists);
        }

        var jobBenefit = await _jobBenefitRepository.GetByIdAsync(jobBenefitUpdateDTO.Id);
        if (jobBenefit == null) return new ErrorResult(Messages.JobBenefitNotFound);

        var updatedJobBenefit = _mapper.Map(jobBenefitUpdateDTO, jobBenefit);
        await _jobBenefitRepository.UpdateAsync(updatedJobBenefit);
        await _jobBenefitRepository.SaveChangesAsync();

        return new SuccessDataResult<JobBenefitDTO>(_mapper.Map<JobBenefitDTO>(updatedJobBenefit), Messages.JobBenefitUpdateSuccess);
    }
}