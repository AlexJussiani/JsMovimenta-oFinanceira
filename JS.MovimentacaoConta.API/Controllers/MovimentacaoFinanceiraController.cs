using JS.Core.Mediator;
using JS.MovimentacaoConta.API.Services;
using JS.MovimentacaoConta.Domain.Models;
using JS.WebAPI.Core.Controllers;
using JS.WebAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.API.Controllers
{
    [Authorize]
    [Route("api/movimentacoes")]
    public class MovimentacaoFinanceiraController : MainController
    {
        private readonly MovimentacaoServices _movimentacaoServices;
        private readonly IMediatorHandler _mediator;
        public MovimentacaoFinanceiraController(MovimentacaoServices movimentacaoServices, 
                                                IMediatorHandler mediator)
        {
            _movimentacaoServices = movimentacaoServices;
            _mediator = mediator;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(200);
        }

        [HttpGet()]
        public async Task<IActionResult> ObterMovimentacao()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _movimentacaoServices.ObterTodos());            
        }
    }
}
