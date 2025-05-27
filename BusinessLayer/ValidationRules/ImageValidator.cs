using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ImageValidator : AbstractValidator<Image>
	{
		public ImageValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Resim başlığı boş geçilemez");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Resim açıklaması boş geçilemez");
			RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş geçilemez");
			RuleFor(x => x.Title).MaximumLength(30).WithMessage("Lütfen 30 karakterden daha az veri girişi yapınız");
			RuleFor(x => x.Title).MinimumLength(10).WithMessage("Resim başlığı en az 10 karakter olmalıdır");
			RuleFor(x => x.Description).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");
			RuleFor(x => x.Description).MinimumLength(20).WithMessage("Resim başlığı en az 20 karakter olmalıdır");

		}
	}
}
