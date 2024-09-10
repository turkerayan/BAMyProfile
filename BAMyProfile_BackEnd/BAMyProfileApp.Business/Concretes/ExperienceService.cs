using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Experience;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public ExperienceService(IExperienceRepository experienceRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
            _localizer = localizer;
        }
        /// <summary>
        /// Yeni bir deneyim ekler.
        /// </summary>
        /// <param name="experienceCreateDTO">Eklenecek deneyim verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> CreateAsync(ExperienceCreateDTO experienceCreateDTO)
        {
            var hasExperience = await _experienceRepository.AnyAsync(x => x.CompanyName.ToLower() == experienceCreateDTO.CompanyName.ToLower());
            if (hasExperience) { return new ErrorResult(_localizer[Messages.ExperienceAlreadyExists]); }

            var newExperience = _mapper.Map<Experience>(experienceCreateDTO);
            await _experienceRepository.AddAsync(newExperience);
            await _experienceRepository.SaveChangesAsync();

            var experienceDto = _mapper.Map<ExperienceDTO>(newExperience);
            return new SuccessDataResult<ExperienceDTO>(experienceDto, _localizer[Messages.ExperienceAddSuccess]);
        }
        /// <summary>
        /// Belirtilen deneyimi siler.
        /// </summary>
        /// <param name="id">Silinecek deneyimin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> DeleteAsync(Guid id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            if (experience == null) { return new ErrorResult(_localizer[Messages.ExperienceNotFound]); }

            await _experienceRepository.DeleteAsync(experience);
            await _experienceRepository.SaveChangesAsync();

            return new SuccessResult(_localizer[Messages.ExperienceDeletedSuccess]);
        }
        /// <summary>
        /// Tüm deneyimleri listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetAllAsync()
        {
            var experiences = await _experienceRepository.GetAllAsync();
            if (experiences.Count() == 0) { return new ErrorResult(_localizer[Messages.ListHasNoExperiences]); }

            var experienceListDto = _mapper.Map<List<ExperienceListDTO>>(experiences);
            return new SuccessDataResult<List<ExperienceListDTO>>(experienceListDto, _localizer[Messages.ExperienceListedSuccess]);
        }
        /// <summary>
        /// Belirtilen deneyimin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak deneyimin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> GetByIdAsync(Guid id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            if (experience == null) { return new ErrorResult(_localizer[Messages.ExperienceNotFound]); }

            var experienceDto = _mapper.Map<ExperienceDTO>(experience);
            return new SuccessDataResult<ExperienceDTO>(experienceDto, _localizer[Messages.ExperienceFoundSuccess]);
        }
        /// <summary>
        /// Belirtilen deneyimi günceller.
        /// </summary>
        /// <param name="experienceUpdateDTO">Güncellenecek deneyimin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        public async Task<IResult> UpdateAsync(ExperienceUpdateDTO experienceUpdateDTO)
        {
            var experience = await _experienceRepository.GetByIdAsync(experienceUpdateDTO.Id);
            if (experience == null) { return new ErrorResult(_localizer[Messages.ExperienceNotFound]); }

            var updatedExperience = _mapper.Map(experienceUpdateDTO, experience);
            await _experienceRepository.UpdateAsync(updatedExperience);
            await _experienceRepository.SaveChangesAsync();

            return new SuccessDataResult<ExperienceDTO>(_mapper.Map<ExperienceDTO>(updatedExperience), _localizer[Messages.ExperienceUpdateSuccess]);
        }
    }
}