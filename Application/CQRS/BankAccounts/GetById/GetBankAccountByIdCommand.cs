using Domain.Entities.BankAccounts;
using ErrorOr;
using MediatR;

namespace Application.CQRS.BankAccounts.GetById
{
    public record GetBankAccountByIdCommand(BankAccountId AccountId) : IRequest<BankAccount>;
}
