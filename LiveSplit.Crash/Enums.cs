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
	
	public enum Stages
	{
		//---------//
		// Crash 1 //
		//---------//

		// Island 1
		NSanityBeach,
		JungleRollers,
		TheGreatGate,
		Boulders,
		Upstream,
		RollingStones,
		HogWild,
		NativeFortress,

		// Island 2
		UpTheCreek,
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
		TheHighRoad,
		SlipperyClimb,
		LightsOut,
		FumblingInTheDark,
		JawsOfDarkness,
		CastleMachinery,
		TheLab,

		// Bosses
		PapuPapu,
		KoalaKong,
		RipperRoo1,
		Pinstripe,
		DrNBrio,

		// DLC
		StormyAscent,

		//---------//
		// Crash 2 //
		//---------//

		// Chamber 1
		TurtleWoods,
		SnowGo,
		HangEight,
		ThePits,
		CrashDash,

		// Chamber 2
		AirCrash,
		SnowBiz,
		BearIt,
		CrashCrush,
		TheEelDeal,

		// Chamber 3
		PlantFood,
		SewerOrLater,
		BearDown,
		RoadToRuin,
		UnBearable,

		// Chamber 4
		HanginOut,
		DigginIt,
		ColdHardCrash,
		Ruination,
		BeeHaving,

		// Chamber 5
		PistonItAway,
		RockIt,
		NightFight,
		PackAttack,
		SpacedOut,

		// Secret stages
		TotallyBear,
		TotallyFly,

		// Bosses
		RipperRoo2,
		KomodoBrothers,
		TinyTiger1,
		DrNGin1,
		DrNeoCortex,

		//---------//
		// Crash 3 //
		//---------//

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

		// Bosses
		TinyTiger2,
		Dingodile,
		DrNTropy,
		DrNGin2,
		UkaUka,

		// DLC
		FutureTense,
		
		//------//
		// Hubs //
		//------//

		TheWarpRoom,
		TheTimeTwister,

		// Other
		None
	}
}
