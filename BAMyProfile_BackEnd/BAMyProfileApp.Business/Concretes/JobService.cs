using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.Business.Concretes;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public JobService(IJobRepository jobRepository, IStringLocalizer<MessageResources> localizer, IMapper mapper = null)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
        _localizer = localizer;
    }

    /// <summary>
    /// Adds a new job.
    /// </summary>
    /// <param name="jobCreateDTO">DTO containing the data of the job to be added.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> CreateAsync(JobCreateDTO jobCreateDTO)
    {
        var newJob = _mapper.Map<Job>(jobCreateDTO);
        await _jobRepository.AddAsync(newJob);
        await _jobRepository.SaveChangesAsync();
        var jobDto = _mapper.Map<JobDTO>(newJob);
        return new SuccessDataResult<JobDTO>(jobDto, _localizer[Messages.JobAddSuccess]);
    }

    /// <summary>
    /// Deletes the specified job.
    /// </summary>
    /// <param name="id">The identifier of the Job to be deleted.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);
        if (job == null) { return new ErrorResult(_localizer[Messages.JobNotFound]); }
        await _jobRepository.DeleteAsync(job);
        await _jobRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.JobDeletedSuccess]);
    }

    /// <summary>
    /// Lists all jobs.
    /// </summary>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var jobs = await _jobRepository.GetAllAsync();
        if (!jobs.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoJobs]); }
        var jobListDto = _mapper.Map<List<JobListDTO>>(jobs);
        return new SuccessDataResult<List<JobListDTO>>(jobListDto, _localizer[Messages.JobListedSuccess]);
    }

    /// <summary>
    /// Retrieves the details of the specified job.
    /// </summary>
    /// <param name="id">The identifier of the job whose details will be retrieved.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);
        if (job == null) { return new ErrorResult(_localizer[Messages.JobNotFound]); }
        var jobDto = _mapper.Map<JobDTO>(job);
        return new SuccessDataResult<JobDTO>(jobDto, _localizer[Messages.JobFoundSuccess]);
    }

    /// <summary>
    /// Updates the specified job.
    /// </summary>
    /// <param name="jobUpdateDTO">DTO containing the data of the job to be updated.</param>
    /// <returns>Returns a result object containing the success status of the operation and, if necessary, the data.</returns>
    public async Task<IResult> UpdateAsync(JobUpdateDTO jobUpdateDTO)
    {
        var job = await _jobRepository.GetByIdAsync(jobUpdateDTO.Id);
        if (job == null) { return new ErrorResult(_localizer[Messages.JobNotFound]); }
        var updatedJob = _mapper.Map(jobUpdateDTO, job);
        await _jobRepository.UpdateAsync(updatedJob);
        await _jobRepository.SaveChangesAsync();
        return new SuccessDataResult<JobDTO>(_mapper.Map<JobDTO>(updatedJob), _localizer[Messages.JobUpdateSuccess]);
    }
}