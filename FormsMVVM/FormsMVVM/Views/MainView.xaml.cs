using FormsMVVM.ViewModel;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsMVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView
	{
		public MainView ()
		{
			InitializeComponent ();
            BindingContext = new LoginViewModel();

            this.WhenActivated(d =>
            {
                d(this.Bind(ViewModel, vm => vm.Username, v => v.EntryUsername));
                d(this.Bind(ViewModel, vm => vm.Password, v => v.EntryPassword));
                d(this.BindCommand(ViewModel, vm => vm.LoginCommand, v => v.ButtonLogin));
            });

            SubscribeFromEventTextUsername();

            this.WhenAnyValue(v => v.ViewModel.Username, v => v.ViewModel.Password)
                .Where(x => !string.IsNullOrWhiteSpace(x.Item1) &&
                            !string.IsNullOrWhiteSpace(x.Item2))
                .Where(x => x.Item1.Length > 6)
                .Subscribe(data =>
                {
                    ButtonLogin.BackgroundColor = Color.Azure;
                });

		}

        private void SubscribeFromEventTextUsername()
        {
            var entryObservableUsername = Observable.FromEventPattern<EventHandler<TextChangedEventArgs>, TextChangedEventArgs>(
                h => EntryUsername.TextChanged += h,
                h => EntryUsername.TextChanged -= h)
                    .Select(args => args.EventArgs.NewTextValue)
                    .Where(args => args.Length > 6)
                    .Throttle(TimeSpan.FromSeconds(2))
                    .Subscribe(username =>
                    {
                        //Check service username
                    });
        }
    }
}