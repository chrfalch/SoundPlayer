using System;
using System.Threading.Tasks;
using System.IO;

namespace SoundPlayer
{
	public interface ISoundProvider
	{
		Task PlaySoundAsync (string filename);
	}
}

