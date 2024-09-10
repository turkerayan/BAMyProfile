using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.EFCore.Repositories;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.ContactPerson;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    public class ContactPersonService : IContactPersonService
    {
        private readonly IContactPersonRepository _contactPersonRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public ContactPersonService(IContactPersonRepository contactPersonRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
        {
            _contactPersonRepository = contactPersonRepository;
            _mapper = mapper;
            _localizer = localizer;
        }
        /// <summary>
        /// Yeni bir bağlantılı olduğu kişiyi ekler.
        /// </summary>
        /// <param name="contactPersonCreateDto">Eklenecek bağlantılı olduğu kişi verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</param>
        /// <returns></returns>

        public async Task<IResult> CreateAync(ContactPersonCreateDto contactPersonCreateDto)
        {
            var hasContactPerson = await _contactPersonRepository.AnyAsync(x => x.PersonEmail.ToLower() == contactPersonCreateDto.PersonEmail.ToLower());
            if (hasContactPerson) { return new ErrorResult(_localizer[Messages.ContactPersonAlreadyExists]); }
            var newContactPerson = _mapper.Map<ContactPerson>(contactPersonCreateDto);
            await _contactPersonRepository.AddAsync(newContactPerson);
            await _contactPersonRepository.SaveChangesAsync();
            var contactPersonDto = _mapper.Map<ContactPersonDTO>(newContactPerson);
            return new SuccessDataResult<ContactPersonDTO>(contactPersonDto, _localizer[Messages.ContactPersonAddSuccess]);
        }

        /// <summary>
        /// Belirtilen bağlantılı olduğu kişiyi siler.
        /// </summary>
        /// <param name="id">Silinecek bağlantılı kişi kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> DeleteAync(Guid id)
        {
            var contactPerson = await _contactPersonRepository.GetByIdAsync(id);
            if (contactPerson == null) { return new ErrorResult(_localizer[Messages.ContactPersonNotFound]); }
            await _contactPersonRepository.DeleteAsync(contactPerson);
            await _contactPersonRepository.SaveChangesAsync();
            return new SuccessResult(_localizer[Messages.ContactPersonDeletedSuccess]);
        }
        /// <summary>
        /// Tüm bağlantılı olduğu kişileri listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> GetAllAync()
        {
            var contactPersons = await _contactPersonRepository.GetAllAsync();
            if (contactPersons.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoContactPerson]); }
            var contactPersonListDto = _mapper.Map<List<ContactPersonListDTO>>(contactPersons);
            return new SuccessDataResult<List<ContactPersonListDTO>>(contactPersonListDto, _localizer[Messages.ContactPersonListedSuccess]);
        }
        /// <summary>
        /// Belirtilen bağlantılı olan kişinin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak bağlantılı olan kişinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var contactPerson = await _contactPersonRepository.GetByIdAsync(id);
            if (contactPerson == null) { return new ErrorResult(_localizer[Messages.ContactPersonNotFound]); }
            var contactPersonDto = _mapper.Map<ContactPersonDTO>(contactPerson);
            return new SuccessDataResult<ContactPersonDTO>(contactPersonDto,_localizer[Messages.ContactPersonFoundSuccess]);
        }
        /// <summary>
        /// Belirtilen bağlantılı olunan kişiyi günceller.
        /// </summary>
        /// <param name="contactPersonUpdateDto">Güncellenecek bağlantılı olunulan kişinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>

        public async Task<IResult> UpdateAync(ContactPersonUpdateDto contactPersonUpdateDto)
        {
            var contactPeople = await _contactPersonRepository.GetByIdAsync(contactPersonUpdateDto.Id);
            if (contactPeople == null) { return new ErrorResult(_localizer[Messages.ContactPersonNotFound]); }
            var updatedContactPerson = _mapper.Map(contactPersonUpdateDto, contactPeople);
            await _contactPersonRepository.UpdateAsync(updatedContactPerson);
            await _contactPersonRepository.SaveChangesAsync();
            var updatedData = _mapper.Map<ContactPersonDTO>(updatedContactPerson);
            return new SuccessDataResult<ContactPersonDTO>(updatedData, _localizer[Messages.ContactPersonUpdateSuccess]);
        }
    }
}
