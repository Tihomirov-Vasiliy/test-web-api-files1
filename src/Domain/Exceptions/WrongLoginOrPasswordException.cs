namespace Domain.Exceptions
{
    public class WrongLoginOrPasswordException : Exception
    {
        public WrongLoginOrPasswordException() : base() { }
        public WrongLoginOrPasswordException(string message) : base(message) { }
    }
}
