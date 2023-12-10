using Domain.Primitives;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BankAccounts
{
    public sealed class BankAccount : AgregateRoot
    {
        public BankAccount(BankAccountId id, string? number, string? bankName, string? name, string? details, bool status, PhoneNumber? phoneNumber)
        {
            Id = id;
            Number = number;
            BankName = bankName;
            Name = name;
            Details = details;
            this.status = status;
            PhoneNumber = phoneNumber;
        }

        public BankAccount() { }


        public BankAccountId Id { get; private set; }
        public string? Number { get; private set; }
        public string? BankName { get; private set; }
        public string? Name { get; private set; }
        public string? Details { get; private set; }
        public bool status { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }

        // Dentro de la clase BankAccount en BankAccount.cs
        public void Update(string? number, string? bankName, string? name, string? details, bool status, PhoneNumber? phoneNumber)
        {
            // Lógica de actualización aquí
            this.Number = number;
            this.BankName = bankName;
            this.Name = name;
            this.Details = details;
            this.status = status;
            this.PhoneNumber = phoneNumber;
        }

    }
}
