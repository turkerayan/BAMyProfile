using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.EFCore.Repositories;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Candidate;
using BAMyProfileApp.Dtos.Student;
using BAMyProfileApp.Entities.DbSets;
using BAMyProfileApp.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper, IAccountService accountService, IStringLocalizer<MessageResources> localizer, IStudentRepository studentRepository)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
            _accountService = accountService;
            _localizer = localizer;
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Yeni bir aday ekler.
        /// </summary>
        /// <param name="studentId">Eklenecek adayın verilerini içeren Student varlığının kimliği.</param>
        /// <param name="workingStatus">Eklenecek adayın çalışma durumu.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> CreateAsync(Guid studentId, int workingStatus)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            
            if (student == null)
            {
                return new ErrorResult(_localizer[Messages.StudentNotFound]);
            }
            
            var hasCandidate = await _candidateRepository.AnyAsync(x => x.Email.ToLower() == student.Email.ToLower());

            if (hasCandidate)
            {
                return new ErrorResult(_localizer[Messages.CandidateAlreadyExists]);
            }

            IdentityUser user = new IdentityUser()
            {
                Email = student.Email,
                UserName = student.Email,
                EmailConfirmed = true
            };
            Result result = new ErrorResult();

            var strategy = await _candidateRepository.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _candidateRepository.BeginTransactionAsync();

                try
                {
                    var accountResult = await _accountService.CreateAsync(user, "Candidate");
                    if (!accountResult.IsSuccess)
                    {
                        result = new ErrorResult(accountResult.Message);
                        transaction.Rollback();
                        return;
                    }

                    var candidateDto = _mapper.Map<CandidateCreateDTO>(student);
                    var newCandidate = _mapper.Map<Candidate>(candidateDto);
                    newCandidate.WorkingStatus = (WorkingStatus)workingStatus;
                    newCandidate.IdentityId = user.Id;
                    
                    await _candidateRepository.AddAsync(newCandidate);
                    await _candidateRepository.SaveChangesAsync();

                    result = new SuccessResult(_localizer[Messages.CandidateAddSuccess]);

                    await MarkStudentAsCandidateAsync(student, true);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    result = new ErrorResult(_localizer[Messages.CandidateAddFail]);
                    transaction.Rollback();
                }
                finally
                {
                    transaction.Dispose();
                }
            });
            return result;


        }

        /// <summary>
        /// Belirtilen adayı siler.
        /// </summary>
        /// <param name="id">Silinecek adayın kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
 
            if (candidate == null)
            {
                return new ErrorResult(_localizer[Messages.CandidateNotFound]);
            }

            await _candidateRepository.DeleteAsync(candidate);
            await _candidateRepository.SaveChangesAsync();

            var student = await _studentRepository.GetByIdAsync(candidate.StudentId);

            if (student == null)
            {
                return new ErrorResult(_localizer[Messages.StudentNotFound]);
            }
            await MarkStudentAsCandidateAsync(student, false);

            return new SuccessResult(_localizer[Messages.CandidateDeletedSuccess]);
        }


        /// <summary>
        /// Tüm adayları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetAllAsync()
        {
            var candidates = await  _candidateRepository.GetAllAsync();
            if(candidates.Count()<=0)
            {
                return new ErrorResult(_localizer[Messages.CandidateNotFound]);
            }

            var candidateListDto = _mapper.Map<List<CandidateListDTO>>(candidates);
            return new SuccessDataResult<List<CandidateListDTO>>(candidateListDto, _localizer[Messages.CandidateListedSuccess]);
        }


        /// <summary>
        /// Belirtilen adayın detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak adayın kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null)
            {
                return new ErrorResult(_localizer[Messages.CandidateNotFound]);
            }
            var candidateDto = _mapper.Map<CandidateDTO>(candidate);
            return new SuccessDataResult<CandidateDTO>(candidateDto, _localizer[Messages.CandidateFoundSuccess]);
        }


        /// <summary>
        /// Belirtilen adayı günceller.
        /// </summary>
        /// <param name="candidateUpdateDTO">Güncellenecek adayın verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> UpdateAsync(CandidateUpdateDTO candidateUpdateDTO)
        {
            var candidate = await _candidateRepository.GetByIdAsync(candidateUpdateDTO.Id);

            if (candidate == null)
            {
                return new ErrorResult(_localizer[Messages.CandidateNotFound]);
            }

            var updatedCandidate = _mapper.Map(candidateUpdateDTO, candidate);
            await _candidateRepository.UpdateAsync(updatedCandidate);
            await _candidateRepository.SaveChangesAsync();

            return new SuccessDataResult<CandidateDTO>(_mapper.Map<CandidateDTO>(updatedCandidate), _localizer[Messages.CandidateUpdateSuccess]);

        }

        /// <summary>
        /// Belirtilen öğrencinin aday olma durumunu işaretler.
        /// </summary>
        /// <param name="student">İşaretlenecek öğrenci.</param>
        /// <param name="isCandidate">Aday olma durumunun kontrolü için alınan parametre.</param>
        private async Task MarkStudentAsCandidateAsync(Student student, bool isCandidate)
        {
            student.IsCandidate = isCandidate;
            await _studentRepository.UpdateAsync(student);
            await _studentRepository.SaveChangesAsync();
        }

    }
}
