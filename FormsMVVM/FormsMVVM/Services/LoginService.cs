[assembly:Xamarin.Forms.Dependency(typeof(FormsMVVM.Services.LoginService))]

namespace FormsMVVM.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class LoginService : ILoginService
    {
        public void Login(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine($"{username} {password} in login");
        }
    }
}
