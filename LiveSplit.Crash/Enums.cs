using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.Crash
{
	public enum ItemTypes
	{
		Crystal,
		ClearGem,
		RedGem,
		BlueGem,
		GreenGem,
		YellowGem,
		PurpleGem,
		Relic
	}

	public enum ColoredGems
	{
		Red,
		Blue,
		Green,
		Yellow,
		Purple,
		None
	}

	public enum Crash2Stages
	{
		// Chamber 1
		TurtleWoods,
		SnowGo,
		HangEight,
		ThePits,
		CrashDash,
		RipperRoo,

		// Chamber 2
		AirCrash,
		SnowBiz,
		BearIt,
		CrashCrush,
		TheEelDeal,
		KomodoBrothers,

		// Chamber 3
		PlantFood,
		SewerOrLater,
		BearDown,
		RoadToRuin,
		UnBearable,
		TinyTiger,

		// Chamber 4
		HanginOut,
		DigginIt,
		ColdHardCrash,
		Ruination,
		BeeHaving,
		DrNGin,

		// Chamber 5
		PistonItAway,
		RockIt,
		NightFight,
		PackAttack,
		SpacedOut,
		DrNeoCortex,

		// Secret stages
		TotallyBear,
		TotallyFly,

		// Other
		TheWarpRoom,
		None
	}
}
