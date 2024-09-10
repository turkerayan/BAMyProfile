using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Dtos.ApplicationInterviewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
	public interface IApplicationInterviewerService
	{
		/// <summary>
		/// Yeni bir mülakata katılan kişi ekler
		/// </summary>
		/// <param name="appInterviewerCreateDTO">Mülakata katılan kişi bilgisini içerir</param>
		/// <returns>İşlemin başarı durumunu ve verileri döner</returns>
		Task<IResult> CreateAsync(ApplicationInterviewerCreateDTO appInterviewerCreateDTO);

		/// <summary>
		/// Bir mülakatçıyı siler
		/// </summary>
		/// <param name="id">Mülakata katılan kişiye ait id </param>
		/// <returns>İşlemin başarı durumunu döner</returns>
		Task<IResult> DeleteAsync(Guid id);

		/// <summary>
		/// Mülakata katılan kişiyi günceller
		/// </summary>
		/// <param name="appInterviewerUpdateDTO">Güncellenecek mülakatçı bilgisini içerir</param>
		/// <returns>İşlemin başarı durumunu ve verileri döner</returns>
		Task<IResult> UpdateAsync(ApplicationInterviewerUpdateDTO appInterviewerUpdateDTO);

		/// <summary>
		/// Mülakata katılan kişileri listeler
		/// </summary>
		/// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
		Task<IResult> GetAllAsync();

		/// <summary>
		/// Id ye göre mülakata katılan kişi detaylarını getirir
		/// </summary>
		/// <param name="id">Mülakata katılan kişiye ait id</param>
		/// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
		Task<IResult> GetByIdAsync(Guid id);
	}
}
