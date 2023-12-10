using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.BankAccounts.Create
{
    public record CreateBankAccountCommand(


         string Number,
     string BankName,
     string Name,
    string Details,
  bool status,
    string PhoneNumber

        ) : IRequest<ErrorOr<Unit>>;
}
