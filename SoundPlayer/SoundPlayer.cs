using System;

using Xamarin.Forms;

namespace SoundPlayer
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Click to play a sound!"
						},
						new Button{
							Text = "Play",
							Command = new Command(async () => {

								var soundService = new SoundService();
								await soundService.PlaySoundAsync("sound.mp3");
							})
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

