using System;
using System.IO;
using BepInEx;
using BepInEx.Configuration;

namespace GOOMPS
{
	internal class Cfg
	{
		public static void LoadConfig()
		{
			ConfigFile configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "GOOMPS.cfg"), true);
			radius = configFile.Bind("Settings", "Detection Radius", 0.65f, "Radius of detection");
			mute = configFile.Bind("Settings", "Mute Intruder", false, "Muted intruders will always be hidden");
			audio = configFile.Bind("Settings", "Hide Noise", true, "Intruders will be muted");
		}

		public static ConfigEntry<float> radius;
		public static ConfigEntry<bool> mute;
		public static ConfigEntry<bool> audio;
	}
}
