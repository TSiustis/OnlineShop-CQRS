namespace OnlineShop.Application.Common.CustomExceptions
{
    [Serializable]
    public class NotFoundException : BaseException
    {
        public NotFoundException()
        {
            UiMessage = "Not Found!";
        }

        public NotFoundException(string message)
            : base(message)
        {
            UiMessage = message;
        }
    }
}
