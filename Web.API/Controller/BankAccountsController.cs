using Application.CQRS.BankAccounts.Create;
using Application.CQRS.BankAccounts.Delete;
using Application.CQRS.BankAccounts.GetAll;
using Application.CQRS.BankAccounts.Update;
using Application.CQRS.BankAccounts.GetById;
using Domain.Entities.BankAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.CQRS.BankAccounts.GetAll.GetAllBankAccountsCommand;

namespace Web.API.Controller
{
    [Route("BankAccounts")]
    public class BankAccounts : ApiController
    {
        private readonly ISender _mediator;

        public BankAccounts(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBankAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match(
                BankAccount => Ok(),
                errors => Problem(errors)
                );
        }



        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Delete([FromRoute] string accountId)
        {
            var command = new DeleteBankAccountCommand(new BankAccountId(accountId));
            var result = await _mediator.Send(command);

            return result.Match(
                BankAccount => Ok(),
                errors => Problem(errors)
            );
        }


        [HttpPut("{accountId}")]
        public async Task<IActionResult> Update([FromRoute] string accountId, [FromBody] UpdateBankAccountCommand command)
        {
            // Asegúrate de que el AccountId en la ruta y en el comando coincidan
            if (accountId != command.AccountId.Value)
            {
                return BadRequest("Mismatched AccountId in route and command.");
            }

            var result = await _mediator.Send(command);
            return result.Match(
                _ => Ok(),
                errors => Problem(errors)
            );
        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBankAccountsCommand();
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        // En el namespace Web.API.Controller
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetById([FromRoute] string accountId)
        {
            var query = new GetBankAccountByIdCommand(BankAccountId.Create(accountId));
            var result = await _mediator.Send(query);

            return Ok(result);
        }




    }
}
