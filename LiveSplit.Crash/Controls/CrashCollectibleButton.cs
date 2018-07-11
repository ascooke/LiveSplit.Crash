using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.Crash.Properties;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace LiveSplit.Crash.Controls
{
	public partial class CrashCollectibleButton : CheckBox
	{
		public CrashCollectibleButton(CollectibleTypes collectibleType)
		{
			InitializeComponent();

			CollectibleType = collectibleType;
			Appearance = Appearance.Button;
			Image = GetImage(collectibleType);
			Size = new Size(32, 32);
		}

		public CollectibleTypes CollectibleType { get; }

		private Image GetImage(CollectibleTypes collectibleType)
		{
			switch (collectibleType)
			{
				case CollectibleTypes.Crystal: return Resources.Crystal;
				case CollectibleTypes.ClearGem: return Resources.ClearGem;
				case CollectibleTypes.RedGem: return Resources.RedGem;
				case CollectibleTypes.BlueGem: return Resources.BlueGem;
				case CollectibleTypes.GreenGem: return Resources.GreenGem;
				case CollectibleTypes.YellowGem: return Resources.YellowGem;
				case CollectibleTypes.PurpleGem: return Resources.PurpleGem;
				case CollectibleTypes.Relic: return Resources.Relic;
			}

			return null;
		}
	}
}
