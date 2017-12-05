using Terraria.ModLoader;

namespace TerrarianThroneMod
{
	class TerrarianThroneMod : Mod
	{
		public TerrarianThroneMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
