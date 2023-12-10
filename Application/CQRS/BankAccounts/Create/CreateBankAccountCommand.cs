using ErrorOr;
using MediatR;

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
