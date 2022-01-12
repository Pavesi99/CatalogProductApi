using Domain.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Integration
{
    public interface ICatalogoProdutosMessageHandler
    {
         void IniciarReceiver();
         void Listen();
    }
}
