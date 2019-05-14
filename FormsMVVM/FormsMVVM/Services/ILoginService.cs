using System;
using System.Collections.Generic;
using System.Text;

namespace FormsMVVM.Services
{
    public interface ILoginService
    {
        void Login(string username, string password);
    }
}
