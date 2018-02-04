using System.Collections.ObjectModel;

namespace FF1
{
	class DataContext
    {
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Importance> Importances { get; set; } = new ObservableCollection<Importance>();

		public DataContext()
		{
			for (uint i = 0; i < 4; i++)
			{
				Party.Add(new Charactor(0x1A + 92 * i) { Name = (i + 1) + "人目" });
			}

			for (uint i = 0; i < 186; i++)
			{
				Items.Add(new Item(0x17C + i * 3));
			}

			foreach (var imp in Info.Instance().Importances)
			{
				Importances.Add(new Importance(0x6C8, 31 - imp.Value) { Name = imp.Name });
			}
		}

		public uint PlayHour
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3B0, 4) / 3600;
			}

			set
			{
				uint minute = SaveData.Instance().ReadNumber(0x3B0, 4) / 60 % 60;
				SaveData.Instance().WriteNumber(0x3B0, 4, value * 3600 + minute * 60);
			}
		}

		public uint PlayMinute
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3B0, 4) / 60 % 60;
			}

			set
			{
				uint hour = SaveData.Instance().ReadNumber(0x3B0, 4) / 3600;
				SaveData.Instance().WriteNumber(0x3B0, 4, value * 60 + hour * 3600);
			}
		}

		public uint Gill
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3AC, 4);
			}

			set
			{
				Util.WriteNumber(0x3AC, 4, value, 0, 9999999);
			}
		}

		public uint Step
		{
			get
			{
				return SaveData.Instance().ReadNumber(0x3B4, 4);
			}

			set
			{
				Util.WriteNumber(0x3B4, 4, value, 0, 9999999);
			}
		}

		public bool Ship
		{
			get
			{
				return SaveData.Instance().ReadBit(0x6AC, 1);
			}

			set
			{
				SaveData.Instance().WriteBit(0x6AC, 1, value);
			}
		}

		public bool RedCrystal
		{
			get
			{
				return SaveData.Instance().ReadBit(0x6AE, 3);
			}

			set
			{
				SaveData.Instance().WriteBit(0x6AE, 3, value);
			}
		}

		public bool YellowCrystal
		{
			get
			{
				return SaveData.Instance().ReadBit(0x6AE, 1);
			}

			set
			{
				SaveData.Instance().WriteBit(0x6AE, 1, value);
			}
		}

		public bool BlueCrystal
		{
			get
			{
				return SaveData.Instance().ReadBit(0x6AF, 5);
			}

			set
			{
				SaveData.Instance().WriteBit(0x6AF, 5, value);
			}
		}

		public bool GreenCrystal
		{
			get
			{
				return SaveData.Instance().ReadBit(0x6B0, 6);
			}

			set
			{
				SaveData.Instance().WriteBit(0x6B0, 6, value);
			}
		}
	}
}
