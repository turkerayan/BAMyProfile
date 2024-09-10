using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Dtos.ApplicationInterviewer;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes
{
	/// <summary>
	/// Mülakata katılan kişi işlemlerini yapan servis
	/// </summary>
	public class ApplicationInterviewerService : IApplicationInterviewerService
	{
		private readonly IApplicationInterviewerRepository _applicationInterviewerRepository;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<MessageResources> _localizer;

		public ApplicationInterviewerService(IApplicationInterviewerRepository applicationInterviewerRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
		{
			_applicationInterviewerRepository = applicationInterviewerRepository;
			_mapper = mapper;
			_localizer = localizer;
		}
		/// <summary>
		/// Yeni bir mülakata katılan kişi ekler
		/// </summary>
		/// <param name="appInterviewerCreateDTO">Mülakata katılan kişi bilgisini içerir</param>
		/// <returns>İşlemin başarı durumunu ve verileri döner</returns>
		public async Task<IResult> CreateAsync(ApplicationInterviewerCreateDTO appInterviewerCreateDTO)
		{
			var hasInterviewer = await _applicationInterviewerRepository.AnyAsync(x => x.Email.ToLower() == appInterviewerCreateDTO.Email.ToLower() && x.ApplicationInterviewId==appInterviewerCreateDTO.ApplicationInterviewId);
			if (hasInterviewer) { return new ErrorResult(_localizer[Messages.ApplicationInterviewerAlreadyExists]); }
			var newInterviewer = _mapper.Map<ApplicationInterviewer>(appInterviewerCreateDTO);
			await _applicationInterviewerRepository.AddAsync(newInterviewer);
			await _applicationInterviewerRepository.SaveChangesAsync();
			var interviewerDto = _mapper.Map<ApplicationInterviewerDTO>(newInterviewer);
			return new SuccessDataResult<ApplicationInterviewerDTO>(interviewerDto, _localizer[Messages.ApplicationInterviewerAddSuccess]);
		}

		/// <summary>
		/// Bir mülakatçıyı siler
		/// </summary>
		/// <param name="id">Mülakata katılan kişiye ait id </param>
		/// <returns>İşlemin başarı durumunu döner</returns>
		public async Task<IResult> DeleteAsync(Guid id)
		{
			var interviewer = await _applicationInterviewerRepository.GetByIdAsync(id);
			if (interviewer == null) { return new ErrorResult(_localizer[Messages.ApplicationInterviewerNotFound]); }
			await _applicationInterviewerRepository.DeleteAsync(interviewer);
			await _applicationInterviewerRepository.SaveChangesAsync();
			return new SuccessResult(_localizer[Messages.ApplicationInterviewerDeletedSuccess]);

		}

		/// <summary>
		/// Mülakata katılan kişileri listeler
		/// </summary>
		/// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
		public async Task<IResult> GetAllAsync()
		{
			var interviewers = await _applicationInterviewerRepository.GetAllAsync();
			if (interviewers.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoApplicationInterviewers]); }
			var interviewerDtos = _mapper.Map<List<ApplicationInterviewerDTO>>(interviewers);
			return new SuccessDataResult<List<ApplicationInterviewerDTO>>(interviewerDtos, _localizer[Messages.ApplicationInterviewerListedSuccess]);
		}

		/// <summary>
		/// Id ye göre mülakata katılan kişi detaylarını getirir
		/// </summary>
		/// <param name="id">Mülakata katılan kişiye ait id</param>
		/// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
		public async Task<IResult> GetByIdAsync(Guid id)
		{
			var interviewer = await _applicationInterviewerRepository.GetByIdAsync(id);
			if (interviewer == null) { return new ErrorResult(_localizer[Messages.ApplicationInterviewerNotFound]); }
			var interviewerDto = _mapper.Map<ApplicationInterviewerDTO>(interviewer);
			return new SuccessDataResult<ApplicationInterviewerDTO>(interviewerDto, _localizer[Messages.ApplicationInterviewerFoundSuccess]);
		}

		/// <summary>
		/// Mülakata katılan kişiyi günceller
		/// </summary>
		/// <param name="appInterviewerUpdateDTO">Güncellenecek mülakatçı bilgisini içerir</param>
		/// <returns>İşlemin başarı durumunu ve verileri döner</returns>
		public async Task<IResult> UpdateAsync(ApplicationInterviewerUpdateDTO appInterviewerUpdateDTO)
		{
			var interviewer = await _applicationInterviewerRepository.GetByIdAsync(appInterviewerUpdateDTO.Id);
			if (interviewer == null) { return new ErrorResult(_localizer[Messages.ApplicationInterviewerNotFound]); }
			var updatedInterviewer = _mapper.Map(appInterviewerUpdateDTO, interviewer);
			await _applicationInterviewerRepository.UpdateAsync(updatedInterviewer);
			await _applicationInterviewerRepository.SaveChangesAsync();
			return new SuccessResult(_localizer[Messages.ApplicationInterviewerUpdateSuccess]);
		}
	}
}
