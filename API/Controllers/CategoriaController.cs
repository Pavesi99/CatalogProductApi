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
    [Route("Categoria")]
    [Authorize]
    [ApiController]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaAppService _appService;

        public CategoriaController(INotifier notifier, ICategoriaAppService appService) : base(notifier)
        {
            _appService = appService;
        }

      
    }
}
