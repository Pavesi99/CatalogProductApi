﻿using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Integration;
using Domain.Message;
using Domain.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace API.MessageHandler
{
    public class CatalogoProdutosMessageHandler : ICatalogoProdutosMessageHandler
    {
        private readonly Action<CatalogoProduto> _catalogoProdutosAppService;
        private readonly IMapper _mapper;
        private readonly IConnectionFactory _factory;

        public CatalogoProdutosMessageHandler( ICatalogoProdutosAppService catalogoProdutosAppService, IMapper mapper, IConnectionFactory factory)
        {
            _factory = factory;
            _mapper = mapper;
            _catalogoProdutosAppService = catalogoProdutosAppService.IntegrarCatalogo;
        }

        public void IniciarReceiver()
        {
            Task.Run(Listen);
        }

        public void Listen()
        {
            using (var connection = _factory.CreateConnection())
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

