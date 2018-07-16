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

	public enum Crash1Stages
	{
		// Island 1
		NSanityBeach,
		JungleRollers,
		TheGreatGate,
		Boulders,
		Upstream,
		PapuPapu,
		HogWild,
		NativeFortress,

		// Island 2
		UpTheCreek,
		RipperRoo,
		TheLostCity,
		TempleRuins,
		RoadToNowhere,
		BoulderDash,
		WholeHog,
		SunsetVista,

		// Island 3
		HeavyMachinery,
		CortexPower,
		GeneratorRoom,
		ToxicWaste,
		Pinstripe,
		TheHighRoad,
		SlipperyClimb,
		LightsOut,
		FumblingInTheDark,
		JawsOfDarkness,
		CastleMachinery,
		NBrio,
		TheLab,

		// DLC
		StormyAscent
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

	public enum Crash3Stages
	{
		// Warp 1
		ToadVillage,
		UnderPressure,
		OrientExpress,
		BoneYard,
		MakinWaves,

		// Warp 2
		GeeWiz,
		HangEmHigh,
		HogRide,
		TombTime,
		MidnightRun,

		// Warp 3
		DinoMight,
		DeepTrouble,
		HighTime,
		RoadCrash,
		DoubleHeader,

		// Warp 4
		Sphynxinator,
		ByeByeBlimps,
		TellNoTales,
		FutureFrenzy,
		TombWader,

		// Warp 5
		GoneTomorrow,
		OrangeAsphalt,
		FlamingPassion,
		MadBombers,
		BugLite,

		// Warp 6
		SkiCrazed,
		Area51,
		RingsOfPower,

		// Secret stages
		HotCoco,
		EggipusRex,

		// DLC
		FutureTense
	}
}
