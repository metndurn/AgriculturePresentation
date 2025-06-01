using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AddressValidator : AbstractValidator<Address>
	{
		public AddressValidator()
		{
			RuleFor(x=>x.Description1).NotEmpty().WithMessage("Açıklaması 1 boş geçilemez");
			RuleFor(x=>x.Description2).NotEmpty().WithMessage("Açıklaması 2 boş geçilemez");
			RuleFor(x=>x.Description3).NotEmpty().WithMessage("Açıklaması 3 boş geçilemez");
			RuleFor(x=>x.Description4).NotEmpty().WithMessage("Açıklaması 4 boş geçilemez");
			RuleFor(x => x.Mapinfo)
				.NotEmpty().WithMessage("Harita Bilgisi boş geçilemez")
				.MinimumLength(10).WithMessage("Harita bilgisi en az 10 karakter olmalıdır");
			RuleFor(x=>x.Description1).MaximumLength(30).WithMessage("Lütfen Açıklamayı Kısaltın");
			RuleFor(x=>x.Description2).MaximumLength(30).WithMessage("Lütfen Açıklamayı Kısaltın");
			RuleFor(x=>x.Description3).MaximumLength(30).WithMessage("Lütfen Açıklamayı Kısaltın");
			RuleFor(x=>x.Description4).MaximumLength(30).WithMessage("Lütfen Açıklamayı Kısaltın");
		}
	}
}
