using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz.")]
		public string userName { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi Giriniz!")]
		public string password { get; set; }
	}
}
