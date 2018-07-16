using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntPtr = System.IntPtr;

namespace LiveSplit.Crash.Memory
{
	public class CrashMemory
	{
		private Process process;
		private ProgramPointer fadePointer;
		private ProgramPointer loadPointer;
		private ProgramPointer stagePointer;
		private ProgramPointer collectiblePointer;
		private IntPtr[] stagePointers;

		public CrashMemory()
		{
			return;

			fadePointer = new ProgramPointer("e85d??????7F000001", 0x1C);
			loadPointer = new ProgramPointer("185c49a2f67f000001", 0x10, 1);
			stagePointer = new ProgramPointer("06000000000100020", 0x130);
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

				string[] stageStrings =
				{
					// Chamber 1
					"545552544c4520574f4f4453", // TURTLE WOODS
					"534e4f5720474f", // SNOW GO
					"48414e47204549474854", // HANG EIGHT
					"5448452050495453", // THE PITS
					"43524153482044415348", // CRASH DASH
					"52495050455220524f4f", // RIPPER ROO

					// Chamber 2
					"414952204352415348", // AIR CRASH
					"534e4f572042495a", // SNOW BIZ
					"42454152204954", // BEAR IT
					"4352415348204352555348", // CRASH CRUSH
					"5448452045454c204445414c", // THE EEL DEAL
					"4b4f4d4f444f2042524f5448455253", // KOMODO BROTHERS

					// Chamber 3
					"504c414e5420464f4f44", // PLANT FOOD
					"5345574552204f52204c41544552", // SEWER OR LATER
					"4245415220444f574e", // BEAR DOWN
					"524f414420544f205255494e", // ROAD TO RUIN
					"554e2d4245415241424c45", // UN-BEARABLE
					"54494e59205449474552", // TINY TIGER

					// Chamber 4
					"48414e47494e27204f5554", // HANGIN' OUT
					"44494747494e27204954", // DIGGIN' IT
					"434f4c442048415244204352415348", // COLD HARD CRASH
					"5255494e4154494f4e", // RUINATION
					"4245452d484156494e47", // BEE-HAVING
					"44522e204e2e2047494e", // DR. N. GIN

					// Chamber 5
					"504953544f4e2049542041574159", // PISTON IT AWAY
					"524f434b204954", // ROCK IT
					"4e49474854204649474854", // NIGHT FIGHT
					"5041434b2041545441434b", // PACK ATTACK
					"535041434544204f5554", // SPACED OUT
					"44522e204e454f20434f52544558", // DR. NEO CORTEX

					// Secret stages
					"544f54414c4c592042454152", // TOTALLY BEAR
					"544f54414c4c5920464c59", // TOTALLY FLY
				};

				Console.WriteLine("Finding stage pointers...");

				stagePointers = new IntPtr[stageStrings.Length];
				
				for (int i = 0; i < stagePointers.Length; i++)
				{
					//stagePointers[i] = memorySearcher.FindSignature(process, stageStrings[i]);

					Console.WriteLine((Crash2Stages)i + " found.");
				}

				Console.WriteLine("Done.\n");
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

		public float GetFade()
		{
			return 0;
			//return fadePointer.Get<float>(process);
		}

		public Crash2Stages GetStage()
		{
			return Crash2Stages.DrNeoCortex;

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
			private IntPtr pointer;
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

			public T Get<T>(Process process) where T : struct
			{
				if (process == null)
				{
					pointer = IntPtr.Zero;

					return default(T);
				}

				if (pointer == IntPtr.Zero && DateTime.Now > lastTry.AddSeconds(1))
				{
					lastTry = DateTime.Now;

					MemorySearcher searcher = new MemorySearcher
					{
						MemoryFilter = info =>
							(info.State & 0x1000) != 0 &&
							(info.Protect & 0x40) != 0 &&
							(info.Protect & 0x100) == 0
					};

					pointer = resultIndex == 0
						? searcher.FindSignature(process, signature)
						: searcher.FindSignatures(process, signature)[resultIndex];

					if (pointer == IntPtr.Zero)
					{
						return default(T);
					}

					Console.WriteLine("Pointer acquired");
				}

				return process.Read<T>(pointer, offset);
			}
		}
	}
}
