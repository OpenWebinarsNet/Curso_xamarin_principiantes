using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinBeginner
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            List<Food> meats = new List<Food>();            
            meats.Add(new Food() { Name = "Pork"});
            meats.Add(new Food() { Name = "Chicken" });

            ListOfMeats.ItemsSource = meats;

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<string>("MasterPresented", string.Empty);
        }
    }
}
