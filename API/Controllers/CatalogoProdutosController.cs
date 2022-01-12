using Application.Interfaces;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace API.Controllers
{
    [Route("CatalogoProdutos")]
    [ApiController]
    public class CatalogoProdutosController : ControllerBase
    {
        private readonly ICatalogoProdutosAppService _appService;
        private readonly ILogger<CatalogoProdutosController> _logger;

        public CatalogoProdutosController(ILogger<CatalogoProdutosController> logger, ICatalogoProdutosAppService appService)
        {
            _appService = appService;
            _logger = logger;
        }

        [HttpPost, Route("/Buscar")]
        public IActionResult Consultar([FromBody] CatalogoProdutosSearchDto catalogoProdutoSearchDto)
        {
            try
            {
                return Ok(_appService.Buscar(catalogoProdutoSearchDto));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message, null, (int)HttpStatusCode.InternalServerError);
            }
        }


    }
}
