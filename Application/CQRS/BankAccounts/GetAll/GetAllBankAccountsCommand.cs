using Domain.Entities.BankAccounts;
using MediatR;

namespace Application.CQRS.BankAccounts.GetAll
{

    public record GetAllBankAccountsCommand : IRequest<List<BankAccount>>;

    
}
