using Domain.Entities.BankAccounts;
using ErrorOr;
using MediatR;

namespace Application.CQRS.BankAccounts.Update
{
    public record UpdateBankAccountCommand(
        BankAccountId AccountId,
        string? Number,
        string? BankName,
        string? Name,
        string? Details,
        bool Status,
        string PhoneNumber
    ) : IRequest<ErrorOr<Unit>>;
}
