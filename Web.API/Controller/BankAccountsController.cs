using Application.CQRS.BankAccounts.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
