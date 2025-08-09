using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz.")]
		public string userName { get; set; }

		[Required(ErrorMessage = "Lütfen Email Giriniz!")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi Giriniz!")]
		public string password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz!")]
		[Compare("password", ErrorMessage = "Şifreler Eşleşmiyor! Tekrar Deneyin!")]
		public string passwordConfirm { get; set; }//şifreyi tekrar girme alanı
	}
}
