using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator : AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
			RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez.");
			RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
		}
	}
}
