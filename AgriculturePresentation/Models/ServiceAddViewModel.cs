using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models/*model uzerınden yapılan kısmı gormus olduk*/
{
	public class ServiceAddViewModel
	{
		[Display(Name = "Baslik")]
		[Required(ErrorMessage = "Baslik Bos Olamaz")]
		public string Title { get; set; }

		[Display(Name = "Gorsel")]
		[Required(ErrorMessage = "Gorsel Bos Olamaz")]
		public string Image { get; set; }

		[Display(Name = "Aciklama")]
		[Required(ErrorMessage = "Aciklama Bos Olamaz")]
		public string Description { get; set; }
	}
}
