using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Student;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _localizer = localizer;
        }

        /// <summary>
        /// Yeni bir öğrenci ekler.
        /// </summary>
        /// <param name="studentCreateDTO">Eklenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> CreateAsync(StudentCreateDTO studentCreateDTO)
        {
            // Duplicate kontrolü
            var hasStudent = await _studentRepository.AnyAsync(x => x.Email.ToLower() == studentCreateDTO.Email.ToLower());
            if (hasStudent)
            {
                return new ErrorResult(_localizer[Messages.StudentAlreadyExists]);
            }

            // Student nesnesini DTO'dan dönüştürme
            var newStudent = _mapper.Map<Student>(studentCreateDTO);
            

            // Image dosyasını byte[] olarak kaydetme
            if (studentCreateDTO.Image != null && studentCreateDTO.Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await studentCreateDTO.Image.CopyToAsync(memoryStream);
                    newStudent.Image = memoryStream.ToArray();
                }
            }

            try
            {
                await _studentRepository.AddAsync(newStudent);
                await _studentRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.StartsWith("Violation of UNIQUE KEY constraint") == true)
                {
                    return new ErrorResult(_localizer[Messages.UserEmailAlreadyExists]);
                }
                else
                {
                    return new ErrorResult($"{ex.Message} Details: {ex.InnerException?.Message}");
                }
            }

            var studentDto = _mapper.Map<StudentDTO>(newStudent);
            return new SuccessDataResult<StudentDTO>(studentDto, _localizer[Messages.StudentAddSuccess]);
        }

        /// <summary>
        /// Belirtilen öğrenciyi günceller.
        /// </summary>
        /// <param name="studentUpdateDTO">Güncellenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> UpdateAsync(StudentUpdateDTO studentUpdateDTO)
        {
            var student = await _studentRepository.GetByIdAsync(studentUpdateDTO.Id);

            if (student == null)
            {
                return new ErrorResult(_localizer[Messages.StudentNotFound]);
            }

            var updatedStudent = _mapper.Map(studentUpdateDTO, student);

            // Image dosyasını byte[] olarak güncelleme
            if (studentUpdateDTO.Image != null && studentUpdateDTO.Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await studentUpdateDTO.Image.CopyToAsync(memoryStream);
                    updatedStudent.Image = memoryStream.ToArray();
                }
            }

            await _studentRepository.UpdateAsync(updatedStudent);
            await _studentRepository.SaveChangesAsync();

            return new SuccessDataResult<StudentDTO>(_mapper.Map<StudentDTO>(updatedStudent), _localizer[Messages.StudentUpdateSuccess]);
        }

        /// <summary>
        /// Belirtilen öğrenciyi siler.
        /// </summary>
        /// <param name="id">Silinecek öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return new ErrorResult(_localizer[Messages.StudentNotFound]);
            }

            await _studentRepository.DeleteAsync(student);
            await _studentRepository.SaveChangesAsync();

            return new SuccessResult(_localizer[Messages.StudentDeletedSuccess]);
        }

        /// <summary>
        /// Tüm öğrencileri listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            if (students.Count() <= 0)
            {
                return new ErrorResult(_localizer[Messages.ListHasNoStudent]);
            }

            var studentListDto = _mapper.Map<List<StudentListDTO>>(students);
            return new SuccessDataResult<List<StudentListDTO>>(studentListDto, _localizer[Messages.StudentListedSuccess]);
        }

        /// <summary>
        /// Belirtilen öğrencinin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return new ErrorResult(_localizer[Messages.StudentNotFound]);
            }
            var studentDto = _mapper.Map<StudentDTO>(student);
            return new SuccessDataResult<StudentDTO>(studentDto, _localizer[Messages.StudentFoundSuccess]);
        }
    }
}