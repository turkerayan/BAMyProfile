using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.JobCandidate;
using BAMyProfileApp.Entities.DbSets;


namespace BAMyProfileApp.Business.Concretes
{
    public class JobCandidateService : IJobCandidateService
    {
        private readonly IJobCandidateRepository _jobCandidateRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public JobCandidateService(IJobCandidateRepository jobCandidateRepository, IMapper mapper, IEmailService emailService)
        {
            _jobCandidateRepository = jobCandidateRepository;
            _mapper = mapper;
            _emailService = emailService;
        }
        /// <summary>
        /// Yeni adayı ilana ekler
        /// </summary>
        /// <param name="jobCandidateCreateDTO">Eklenecek ilanın verilerini içerir</param>
        /// <returns>İşlemin başarı durumunu ve gerekiyorsa verileri içeren bir sonuç nesnesi döndürür</returns>

        public async Task<IResult> CreateAsync(JobCandidateCreateDTO jobCandidateCreateDTO)
        {
            if(await _jobCandidateRepository.AnyAsync(jb=>jb.JobId==jobCandidateCreateDTO.JobId && jb.CandidateID==jobCandidateCreateDTO.CandidateId
                )) {
                return new ErrorResult(Messages.JobBenefitAlreadyExists);
            }
            var newJobCandidate=_mapper.Map<JobCandidate>(jobCandidateCreateDTO);
            await _jobCandidateRepository.AddAsync(newJobCandidate);
            await _jobCandidateRepository.SaveChangesAsync();
            var jobCandidateDto=_mapper.Map<JobCandidateDTO>(newJobCandidate);
            await _emailService.SendEmailJobToCandidate(jobCandidateCreateDTO.JobId.ToString(), jobCandidateCreateDTO.CandidateId.ToString());
            return new SuccessDataResult<JobCandidateDTO> (jobCandidateDto,Messages.JobCandidateAddSuccess);
        }
        /// <summary>
        /// Belirtilen ilan adayını siler 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>İşlemin başarı durumunu ve gerekiyorsa verileri içeren bir sonuç nesnesi döndürür</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var jobCandidate=await _jobCandidateRepository.GetByIdAsync(id);
            if(jobCandidate==null) return new ErrorResult
(Messages.JobCandidateNotFound);
            await _jobCandidateRepository.DeleteAsync(jobCandidate);
            await _jobCandidateRepository.SaveChangesAsync();
            return new SuccessResult(Messages.JobBenefitDeletedSuccess);
        }

        /// <summary>
        /// İlanın tüm adaylarını listeler
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekiyorsa verileri içeren bir sonuç nesnesi döndürür</returns>
        public async Task<IResult> GetAllAsync()
        {
           var jobCandidates=await _jobCandidateRepository.GetAllAsync();
            if (!jobCandidates.Any()) return new ErrorResult(Messages.ListHasNoJobCandidates);

            var jobCandidateListDto=_mapper.Map<List<JobCandidateListDTO>>(jobCandidates);
            return new SuccessDataResult<List<JobCandidateListDTO>>(jobCandidateListDto, Messages.JobCandidateListedSuccess);
        }
        /// <summary>
        /// Belirtilen ilandaki adayın bilgilerini listeler
        /// </summary>
        /// <param name="id"></param>
        /// <returns>İşlemin başarı durumunu ve gerekiyorsa verileri içeren bir sonuç nesnesi döndürür</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var jobCandidate = await _jobCandidateRepository.GetByIdAsync(id);
            if (jobCandidate == null) return new ErrorResult(Messages.JobBenefitNotFound);

            var jobCandidateDto=_mapper.Map<JobCandidateDTO>(jobCandidate);

            return new SuccessDataResult<JobCandidateDTO>(jobCandidateDto, Messages.JobCandidateFoundSuccess);
                }
        /// <summary>
        /// Belirtilen ilan-aday bilgilerini günceller
        /// </summary>
        /// <param name="jobCandidateUpdateDTO">Güncellenecek aday-ilan bilgilerini içerir</param>
        /// <returns>İşlemin başarı durumunu ve gerekiyorsa verileri içeren bir sonuç nesnesi döndürür</returns>
        public async Task<IResult> UpdateAsync(JobCandidateUpdateDTO jobCandidateUpdateDTO)
        {
            if(await _jobCandidateRepository.AnyAsync(jb => jb.JobId == jobCandidateUpdateDTO.CandidateId))
            {
                return new ErrorResult(Messages.JobBenefitAlreadyExists);
            }

            var jobCandidate=await _jobCandidateRepository.GetByIdAsync(jobCandidateUpdateDTO.Id);
            if(jobCandidate == null) return new ErrorResult(Messages
                .JobBenefitNotFound);
            var updateJobCandidate=_mapper.Map(jobCandidateUpdateDTO,jobCandidate);
            await _jobCandidateRepository.UpdateAsync(updateJobCandidate);
            await _jobCandidateRepository.SaveChangesAsync();
            return new SuccessDataResult<JobCandidateDTO>(_mapper.Map<JobCandidateDTO>(updateJobCandidate),Messages.JobCandidateUpdateSuccess);
        }
    }
}
