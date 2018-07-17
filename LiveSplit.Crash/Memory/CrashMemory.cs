using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Crash.Memory
{
	public class CrashMemory
	{
		private Process process;
		private ProgramPointer stageBase;
		private ProgramPointer fadePointer;
		private ProgramPointer loadPointer;
		private ProgramPointer stagePointer;
		private ProgramPointer collectiblePointer;

		// The game stores stage data in a different order than you'd logically expect. This array is used to translate
		// that order to the order stages are listed in the enumeration.
		private Stages[] stageOrdering;

		private int[] stageOffsets;

		public CrashMemory()
		{
			// This is the hex string of "Ripper Roo" (note that the lowercase letters differentiate it from Crash 2's Ripper Roo).
			stageBase = new ProgramPointer("52697070657220526f6f", 0);
			stagePointer = new ProgramPointer("3F0000803F000000FF0AD7233C00", 0x39);

			stageOrdering = new []
			{
				// Crash 1
				Stages.RipperRoo1,
				Stages.PapuPapu,
				Stages.NSanityBeach,
				Stages.JungleRollers,
				Stages.TheGreatGate,
				Stages.Boulders,
				Stages.Upstream,
				Stages.RollingStones,
				Stages.HogWild,
				Stages.NativeFortress,
				Stages.UpTheCreek,
				Stages.TheLostCity,
				Stages.TempleRuins,
				Stages.RoadToNowhere,
				Stages.BoulderDash,
				Stages.WholeHog,
				Stages.SunsetVista,
				Stages.HeavyMachinery,
				Stages.CortexPower,
				Stages.GeneratorRoom,
				Stages.ToxicWaste,
				Stages.TheHighRoad,
				Stages.SlipperyClimb,
				Stages.LightsOut,
				Stages.FumblingInTheDark,
				Stages.JawsOfDarkness,
				Stages.CastleMachinery,
				Stages.NBrio,
				Stages.Pinstripe,
				Stages.TheLab,

				// Crash 2
				Stages.RipperRoo2,
				Stages.KomodoBrothers,
				Stages.TinyTiger,
				Stages.DrNGin,
				Stages.DrNeoCortex,
				Stages.TurtleWoods,
				Stages.HangEight,
				Stages.ThePits,
				Stages.CrashDash,
				Stages.SnowBiz,
				Stages.AirCrash,
				Stages.CrashCrush,
				Stages.TheEelDeal,
				Stages.PlantFood,
				Stages.SewerOrLater,
				Stages.BearDown,
				Stages.RockIt,
				Stages.RoadToRuin,
				Stages.SnowGo,
				Stages.BearIt,
				Stages.UnBearable,
				Stages.HanginOut,
				Stages.DigginIt,
				Stages.ColdHardCrash,
				Stages.Ruination,
				Stages.BeeHaving,
				Stages.PistonItAway,
				Stages.NightFight,
				Stages.PackAttack,
				Stages.SpacedOut,
				Stages.TotallyBear,
				Stages.TotallyFly,

				// Crash 3
			};

			stageOffsets = new[]
			{
				0x0, // Ripper Roo 1
				0x2850, // Papu Papu
				0x16fb0, // N. Sanity Beach
				0x16fd0, // Jungle Rollers
				0x170f0, // The Great Gate
				0x17200, // Boulders
				0x17308, // Upstream
				0x17418, // Rolling Stones
				0x17528, // Hog Wild
				0x17630, // Native Fortress
				0x17738, // Up the Creek
				0x17848, // The Lost City
				0x17958, // Temple Ruins
				0x17a68, // Road to Nowhere
				0x17b80, // Boulder Dash
				0x17c90, // Whole Hog
				0x17e30, // Sunset Vista
				0x17e58, // Heavy Machinery
				0x18000, // Cortex Power
				0x180c0, // Generator Room
				0x18178, // Toxic Waste
				0x18230, // The High Road
				0x18258, // Slippery Climb
				0x18400, // Lights Out
				0x184d0, // Fumbling in the Dark
				0x18500, // Jaws of Darkness
				0x186c0, // Castle Machinery
				0xb43e7, // N. Brio
				0xb4477, // Pinstripe Potoroo
				0xf0bf0, // The Lab

				0x18a70, // Ripper Roo 2
				0x18bb8, // Komodo Brothers
				0x18c30, // Tiny Tiger
				0x18e40, // Dr. N. Gin 
				0x18f48, // Dr. Neo Cortex 
				0x19270, // Turtle Woods 
				0x19720, // Hang Eight 
				0x19850, // The Pits
				0x19958, // Crash Dash
				0x19a60, // Snow Biz
				0x19b58, // Air Crash 
				0x19d38, // Crash Crush 
				0x19e48, // The Eel Deal 
				0x19f58, // Plant Food 
				0x1a060, // Sewer or Later 
				0x1a168, // Bear Down 
				0x1a388, // Rock It 
				0x1a3a8, // Road to Ruin 
				0xf0ee0, // Snow Go 
				0xf11d0, // Bear It 
				0xf9fb8, // Un-Bearable
				0xfa090, // Hangin' Out 
				0xfa190, // Diggin' It
				0xfa2a0, // Cold Hard Crash 
				0xfa448, // Ruination 
				0xfa470, // Bee-Having 
				0xfa580, // Piston It Away 
				0xfa710, // Night Fight 
				0xfa820, // Pack Attack 
				0xfa9b8, // Spaced Out
				0xfa9e0, // Totally Bear 
				0xfabb8, // Totally Fly
				
				0xe2790 // Toad Village
			};

			return;

			fadePointer = new ProgramPointer("e85d??????7F000001", 0x1C);
			loadPointer = new ProgramPointer("185c49a2f67f000001", 0x10, 1);
			collectiblePointer = new ProgramPointer("48989640F77F0000", 0);
		}

		public bool HookProcess()
		{
			if (process == null || process.HasExited)
			{
				Process[] processes = Process.GetProcessesByName("CrashBandicootNSaneTrilogy");
				process = processes.Length == 0 ? null : processes[0];

				if (processes.Length == 0 || process.HasExited)
				{
					return false;
				}

				MemoryReader.Update64Bit(process);

				return true;
			}

			return true;
		}

		public int GetCrystals()
		{
			//return process.Read<int>(fadePointer, 0x198);
			return 0;
		}

		public int GetGems()
		{
			return 0;
		}

		public int GetLives()
		{
			return 0;
		}

		public int GetBoxes()
		{
			return 0;
		}

		public float GetFade()
		{
			return 0;
			//return fadePointer.Get<float>(process);
		}

		public Stages GetStage()
		{
			if (!stageBase.AcquirePointer(process))
			{
				return Stages.None;
			}

			IntPtr address = stagePointer.Get<IntPtr>(process, out bool success);

			if (success)
			{
				int offset = (int)((ulong)address - (ulong)stageBase.Pointer);

				for (int i = 0; i < stageOffsets.Length; i++)
				{
					if (offset == stageOffsets[i])
					{
						return stageOrdering[i];
					}
				}
			}

			return Stages.None;

			/*
			IntPtr pointer = process.Read<IntPtr>(stagePointer);
			
			for (int i = 0; i < StageCount; i++)
			{
				if (pointer == stagePointers[i])
				{
					return (Crash2Stages)i;
				}
			}

			return Crash2Stages.TheWarpRoom;
			*/
		}

		public bool GetBoss(int bossIndex)
		{
			return false;
		}

		public bool GetColoredGem(ColoredGems gem)
		{
			return false;
		}

		private class ProgramPointer
		{
			private DateTime lastTry;

			private string signature;
			private int offset;
			private int resultIndex;

			public ProgramPointer(string signature, int offset, int resultIndex = 0)
			{
				this.signature = signature;
				this.offset = offset;
				this.resultIndex = resultIndex;
			}

			public IntPtr Pointer { get; private set; }

			public T Get<T>(Process process, out bool success) where T : struct
			{
				if (process == null)
				{
					Pointer = IntPtr.Zero;
					success = false;

					return default(T);
				}

				if (!AcquirePointer(process))
				{
					success = false;

					return default(T);
				}

				success = true;

				return process.Read<T>(Pointer, offset);
			}

			public bool AcquirePointer(Process process)
			{
				if (Pointer == IntPtr.Zero && DateTime.Now > lastTry.AddSeconds(1))
				{
					lastTry = DateTime.Now;

					MemorySearcher searcher = new MemorySearcher
					{
						MemoryFilter = info =>
							(info.State & 0x1000) != 0 &&
							(info.Protect & 0x04) != 0 &&
							(info.Protect & 0x100) == 0
					};

					Pointer = resultIndex == 0
						? searcher.FindSignature(process, signature)
						: searcher.FindSignatures(process, signature)[resultIndex];
				}

				return Pointer != IntPtr.Zero;
			}
		}
	}
}
