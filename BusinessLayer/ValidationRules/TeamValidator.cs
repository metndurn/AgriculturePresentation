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
	}
}
