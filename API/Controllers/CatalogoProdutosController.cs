using Application.Interfaces;
using Havan.Logistica.Core.Controller;
using Havan.Logistica.Core.Notifications;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("CatalogoProdutos")]
    [ApiController]
    public class CatalogoProdutosController : MainController
    {
        private readonly ICatalogoProdutosAppService _appService;

        public CatalogoProdutosController(INotifier notifier, ICatalogoProdutosAppService appService) : base(notifier)
        {
            _appService = appService;
        }

        [HttpPost, Route("/Buscar")]
        public IActionResult Consultar([FromBody] CatalogoProdutosSearchDto catalogoProdutoSearchDto)
        {
            try
            {
                return Response(_appService.Buscar(catalogoProdutoSearchDto));
            }
            catch (Exception e)
            {
                Notify(e.InnerException?.Message ?? e.Message);
                return Response();
            }
        }


    }
}
