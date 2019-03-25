using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp1
{
    public interface IMessageProvider
    {
        string GetMessage(string name);
    }
}
