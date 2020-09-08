using System;
using Valhalla.Modules.Domain.Enums;

namespace Valhalla.Modules.Domain.Entities
{
    public class Address : IEntity
    {
        public Address(string street, int number, string complement, string district, string state, string country)
        {
            Id = Guid.NewGuid();
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            State = state;
            Country = country;
        }

        public Guid Id { get; private set; }

        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public EAddressType AddressType { get; private set; }

        public override string ToString()
        {
            return $"{Street}, {Number} {Complement} - {District}/{State}";
        }

    }

}
