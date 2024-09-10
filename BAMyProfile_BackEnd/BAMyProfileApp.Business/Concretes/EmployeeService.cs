using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Employee;
using BAMyProfileApp.Entities.DbSets;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public EmployeeService(IEmployeeRepository employeeRepository, IAccountService accountService, IMapper mapper, IStringLocalizer<MessageResources> localizer)
        {
            _employeeRepository = employeeRepository;
            _accountService = accountService;
            _mapper = mapper;
            _localizer = localizer;
        }

        /// <summary>
        /// Yeni bir çalışan ekler.
        /// </summary>
        /// <param name="employeeCreateDTO">Eklenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> CreateAsync(EmployeeCreateDTO employeeCreateDTO)
        {
            var hasEmployee = await _employeeRepository.AnyAsync(e => e.Email.ToLower() == employeeCreateDTO.Email.ToLower());
            if (hasEmployee)
            {
                return new ErrorResult(_localizer[Messages.EmployeeAlreadyExists]);
            }

            IdentityUser user = new IdentityUser()
            {
                Email = employeeCreateDTO.Email,
                UserName = employeeCreateDTO.Email,
                //EmailConfirmed = true
            };

            Result result = new ErrorResult();

            var strategy = await _employeeRepository.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _employeeRepository.BeginTransactionAsync();

                try
                {
                    var accountResult = await _accountService.CreateAsync(user, "Employee");
                    if (!accountResult.IsSuccess) 
                    {
                        result = new ErrorDataResult<EmployeeDTO>(accountResult.Message);
                        transaction.Rollback();
                        return;
                    }

                    var newEmployee = _mapper.Map<Employee>(employeeCreateDTO);
                    newEmployee.IdentityId = user.Id;

                    await _employeeRepository.AddAsync(newEmployee);
                    await _employeeRepository.SaveChangesAsync();

                    var employeeDTO = _mapper.Map<EmployeeDTO>(newEmployee);
                    result = new SuccessResult(_localizer[Messages.EmployeeAddSuccess]);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    result = new ErrorDataResult<EmployeeDTO>(_localizer[Messages.EmployeeAddFail]);
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
        /// Belirtilen çalışanı siler.
        /// </summary>
        /// <param name="id">Silinecek öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) 
            {
                return new ErrorResult(_localizer[Messages.EmployeeNotFound]);
            }
            await _employeeRepository.DeleteAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            return new SuccessResult(_localizer[Messages.EmployeeDeletedSuccess]);

        }

        /// <summary>
        /// Tüm çalışanları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> GetAllAsync()
        {
          var employees = await _employeeRepository.GetAllAsync();
            if (employees.Count() <= 0) 
            {
                return new ErrorResult(_localizer[Messages.ListHasNoEmployees]);
            }
           var employeeListDto = _mapper.Map <List<EmployeeListDTO>>(employees);
            return new SuccessDataResult<List<EmployeeListDTO>>(employeeListDto, _localizer[Messages.EmployeeListedSuccess]);
        }

        /// <summary>
        /// Belirtilen çalışanın detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if(employee == null) 
            {
              return new ErrorResult(_localizer[Messages.EmployeeNotFound]);
            }
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);
            return new SuccessDataResult<EmployeeDTO>(employeeDto, _localizer[Messages.EmployeeFoundSuccess]);
        }

        /// <summary>
        /// Belirtilen çalışanı günceller.
        /// </summary>
        /// <param name="employeeUpdateDTO">Güncellenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> UpdateAsync(EmployeeUpdateDTO employeeUpdateDTO)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeUpdateDTO.Id);
            if(employee == null) 
            {
                return new ErrorResult(_localizer[Messages.EmployeeNotFound]);
            }
           var updatedEmployee = _mapper.Map(employeeUpdateDTO,employee);
           await _employeeRepository.UpdateAsync(updatedEmployee);
            await _employeeRepository.SaveChangesAsync();

            var updatedData = _mapper.Map<EmployeeDTO>(updatedEmployee);
            return new SuccessDataResult<EmployeeDTO>(updatedData, _localizer[Messages.EmployeeUpdateSuccess]);
           
        }
    }
}
