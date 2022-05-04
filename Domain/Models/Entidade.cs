namespace Domain.Models
{
    public abstract class Entidade<T> where T : struct
    {
        public T Id { get; private set; }
    }
}
