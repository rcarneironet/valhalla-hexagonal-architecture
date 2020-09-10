using Flunt.Notifications;
using Flunt.Validations;

namespace Valhalla.Modules.Domain.ValueObjects
{
    public class EmailVo : Notifiable, IValidatable
    {
        public EmailVo(string address)
        {
            Address = address;
            Validate();
        }

        public string Address { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email", "O e-mail é inválido"));
        }
    }
}
