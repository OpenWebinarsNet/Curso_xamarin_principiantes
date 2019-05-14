using FormsMVVM.Services;
using FormsMVVM.ViewModel.Base;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsMVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService loginService;

        private string username;
        private string password;
        private ReactiveCommand<Unit,Unit> loginCommand;

        public LoginViewModel()
        {
            loginCommand = ReactiveCommand.CreateFromTask<Unit,Unit>(PerformLoginCommandAsync);
            loginService = DependencyService.Get<ILoginService>();
        }

        public string Username
        {
            get => username;
            set => this.RaiseAndSetIfChanged(ref username, value);            
        }

        public string Password
        {
            get => password;
            set => this.RaiseAndSetIfChanged(ref password, value);            
        }

        public ICommand LoginCommand => loginCommand;

        private void PerformLoginCommand()
        {
            //Do Something
            DependencyService.Get<ILoginService>().Login(username, password);
        }

        private Task<Unit> PerformLoginCommandAsync(Unit arg)
        {
            return Task.FromResult(Unit.Default);
        }


    }
}
