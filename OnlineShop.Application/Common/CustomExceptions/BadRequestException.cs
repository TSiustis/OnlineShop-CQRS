namespace OnlineShop.Application.Common.CustomExceptions;

[Serializable]
public class BadRequestException : BaseException
{
    public BadRequestException()
    {
        UiMessage = "Bad Request!";
    }

    public BadRequestException(string message)
        : base(message)
    {
        UiMessage = message;
    }
}
    
