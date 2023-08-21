namespace Contacts.Domain.Models
{
    public abstract class Base<T>
    {
        public T Id { get; set; }
    }
}
