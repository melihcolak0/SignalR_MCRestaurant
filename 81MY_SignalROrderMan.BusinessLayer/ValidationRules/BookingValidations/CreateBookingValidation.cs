using _81MY_SignalROrderMan.DtoLayer.BookingDtos;
using FluentValidation;

namespace _81MY_SignalROrderMan.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı alanı boş geçilemez!");
            RuleFor(x => x.BookDate).NotEmpty().WithMessage("Tarih alanı boş geçilemez!");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim alanı en az 3 karakter içermelidir!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter içerebilir!");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir E-Mail adresi giriniz!");
        }
    }
}
