using Domain.Entities.BankAccounts;
using ErrorOr;
using MediatR;

namespace Application.CQRS.BankAccounts.Delete
{
    public record DeleteBankAccountCommand(BankAccountId AccountId) : IRequest<ErrorOr<Unit>>;
}
