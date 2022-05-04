
namespace Domain.Interfaces.Integration
{
    public interface ICatalogoProdutosMessageHandler
    {
         void IniciarReceiver();
         void Listen();
    }
}
