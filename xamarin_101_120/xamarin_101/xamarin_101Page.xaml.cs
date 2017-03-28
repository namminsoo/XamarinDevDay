using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin_101
{
	public partial class xamarin_101Page : ContentPage
	{
		public xamarin_101Page()
		{
			InitializeComponent();
		}

		private void ButtonClicked(object sender, EventArgs e)
		{
			this.DisplayAlert("Alert", "You clicked me", "OK");
		}

		async void OnCall(object sender, System.EventArgs e)
		{
			if (await this.DisplayAlert(
				"Dial a Number",
				"Would you like to call " + phoneNumberText.Text + "?",
				"Yes",
				"No"))
			{
				var dialer = DependencyService.Get<IDialer>();
				if (dialer != null)
				{
					await dialer.DialAsync(phoneNumberText.Text);
				}
			}
		}

		public interface IDialer
		{
			Task<bool> DialAsync(string number);
		}

	}
}
