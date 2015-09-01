using System;
using System.Threading.Tasks;
using AVFoundation;
using Foundation;
using Xamarin.Forms;
using SoundPlayer.iOS;
using System.IO;

[assembly: Dependency (typeof (TouchSoundProvider))]
namespace SoundPlayer.iOS
{
	public class TouchSoundProvider: NSObject, ISoundProvider
	{
		private AVAudioPlayer _player;

		public Task PlaySoundAsync (string filename)
		{
			var tcs = new TaskCompletionSource<bool> ();

			string path = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(filename), 
				Path.GetExtension(filename));

			var url = NSUrl.FromString (path);
			_player = AVAudioPlayer.FromUrl(url);

			_player.FinishedPlaying += (object sender, AVStatusEventArgs e) => {
				_player = null;
				tcs.SetResult(true);
			};

			_player.Play();

			return tcs.Task;
		}
	}
}

