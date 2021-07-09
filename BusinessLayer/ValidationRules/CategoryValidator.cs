﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Ad Boş Bırakılamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En Az 3 Karakter");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Maksimum 20 Karakter");
        }
    }
}
