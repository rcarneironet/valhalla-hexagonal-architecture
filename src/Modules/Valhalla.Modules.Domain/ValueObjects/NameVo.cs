using Flunt.Notifications;
using Flunt.Validations;

namespace Valhalla.Modules.Domain.ValueObjects
{
    public class NameVo : Notifiable, IValidatable
    {
        public NameVo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(FirstName, 3, "FirstName", "Firstname deve conter pelo menos 3 caracteres")
            .HasMaxLen(FirstName, 20, "FirstName", "Firstname deve conter no máximo 20 caracteres")
            .HasMinLen(LastName, 3, "FirstName", "Firstname deve conter pelo menos 3 caracteres")
            .HasMaxLen(LastName, 20, "FirstName", "Firstname deve conter no máximo 20 caracteres"));
        }
    }

}
