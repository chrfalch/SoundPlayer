using System;
using Xamarin.Forms;
using SoundPlayer.Droid;
using System.Threading.Tasks;
using Android.Media;

[assembly: Dependency (typeof (AndroidSoundProvider))]
namespace SoundPlayer.Droid
{
	public class AndroidSoundProvider: ISoundProvider
	{
		public Task PlaySoundAsync (string filename)
		{
			// Create media player
			var player = new MediaPlayer();		

			// Create task completion source to support async/await
			var tcs = new TaskCompletionSource<bool> ();

			// Open the resource
			var fd = Xamarin.Forms.Forms.Context.Assets.OpenFd (filename);

			// Hook up some events
			player.Prepared += (s, e) => {            
				player.Start();
			};

			player.Completion += (sender, e) => {
				tcs.SetResult(true);
			};

			// Initialize
			player.SetDataSource (fd.FileDescriptor);			
			player.Prepare ();

			return tcs.Task;
		}

	}
}

