using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Boş Bırakılamaz");
            RuleFor(x => x.WriterJob).NotEmpty().WithMessage("Yazar İşi Boş Bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En Az 2 Karakter");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Maksimum 50 Karakter");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkımda Kısmında en az bir 'A' harfi bulunmalı");
        }

    }
}
