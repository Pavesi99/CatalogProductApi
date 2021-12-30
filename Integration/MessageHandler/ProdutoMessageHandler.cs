using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Havan.Core;
using Havan.Messaging.RabbitMQ;
using Infra.CrossCutting.Dto;
using Infra.Data.Repositories.ItlSys;
using Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.MessageHandler
{
    public class CatalogoProdutosMessageHandler 
    {
        private readonly Action<CatalogoProduto> _catalogoProdutosAppService;
        private readonly IMapper _mapper;
        public CatalogoProdutosMessageHandler( IProvider<ICatalogoProdutosAppService> CatalogoProdutosAppService, IMapper mapper)
        {
            _mapper = mapper;
            _catalogoProdutosAppService = CatalogoProdutosAppService.Action<CatalogoProduto>(s => s.RegistrarCatalogo);
        }

        public void IniciarReceiver()
        {
            Task.Run(Listen);
        }

        public void Listen()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "catalogoProduto", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var jsonified = Encoding.UTF8.GetString(body);
                    CatalogoProdutosMessage catalogo = JsonConvert.DeserializeObject<CatalogoProdutosMessage>(jsonified);

                    _catalogoProdutosAppService.Invoke(_mapper.Map<CatalogoProduto>(catalogo));
                    Console.WriteLine(" [x] Catalogo Recebido");
                };
                channel.BasicConsume(queue: "catalogoProduto", autoAck: true, consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}

