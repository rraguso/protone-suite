using System;
using Microsoft.Win32;

namespace OPMedia.Core
{
	public static class RegistryEmulation
	{
		public static RegistryKey Emu_OpenSubKey (this RegistryKey key, string path)
		{
#if HAVE_MONO
			return null;
#else
			return key.OpenSubKey(path);
#endif
		}

		public static RegistryKey Emu_CreateSubKey (this RegistryKey key, string path)
		{
#if HAVE_MONO
			return null;
#else
			return key.CreateSubKey(path);
#endif
		}
	}
}

