using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.IO;

namespace SoundPlayer
{
	public class SoundService
	{
		private ISoundProvider _soundProvider;
		public SoundService ()
		{
			_soundProvider = DependencyService.Get<ISoundProvider> ();
		}

		public Task PlaySoundAsync(string filename){
			return _soundProvider.PlaySoundAsync (filename);
		}
	}
}

