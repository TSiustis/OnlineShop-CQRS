using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Common.CustomExceptions;
[Serializable]
public class ForbiddenException : BaseException
{
    public ForbiddenException()
    {
        UiMessage = "Forbidden!";
    }

    public ForbiddenException(string resourceName)
    {
        UiMessage = $"{resourceName} is forbidden.";
    }
}
