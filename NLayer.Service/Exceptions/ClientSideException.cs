namespace NLayer.Service.Expections
{
    public class ClientSideException : Exception
    {
        public ClientSideException(string message) : base(message)
        {
        }
    }
}
