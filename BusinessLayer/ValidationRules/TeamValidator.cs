	using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{//AbstractValidator fluentValidation kütüphanesinden gelen bir sınıf yanında bir generic sınıf alır
	public class TeamValidator : AbstractValidator<Team>
	{
		public TeamValidator()
		{
			RuleFor(x=>x.PersonelName).NotEmpty().WithMessage("Personel adı boş geçilemez");
			RuleFor(x => x.Title).NotEmpty().WithMessage("Görev kısmı boş geçilemez");
			RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş geçilemez");
			RuleFor(x => x.PersonelName).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");
			RuleFor(x => x.PersonelName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
			RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en az 50 karakter veri girişi yapınız");
			RuleFor(x => x.Title).MinimumLength(3).WithMessage("Personel adı en az 3 karakter olmalıdır");
		}
	}
}
