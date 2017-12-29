using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FF1
{
	class Charactor
	{
		public ObservableCollection<MagicGroup> Magics { get; set; } = new ObservableCollection<MagicGroup>();
		private readonly uint mAddress;
		public Charactor(uint address)
		{
			mAddress = address;

			for (uint i = 0; i < 8; i++)
			{
				Magics.Add(new MagicGroup(address + 51 + i * 3) { Name = "Lv" + (i + 1) });
			}
		}

		public String Name { get; set; }

		public uint Job
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 16, 1);
			}

			set
			{
				SaveData.Instance().WriteNumber(mAddress + 16, 1, value);
			}
		}

		public uint Lv
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 18, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 18, 1, value, 1, 99);
			}
		}

		public uint Exp
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 22, 4);
			}

			set
			{
				Util.WriteNumber(mAddress + 22, 4, value, 0, 9999999);
			}
		}

		public uint HP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 26, 2);
			}

			set
			{
				Util.WriteNumber(mAddress + 26, 2, value, 0, 999);
			}
		}

		public uint MaxHP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 28, 2);
			}

			set
			{
				Util.WriteNumber(mAddress + 28, 2, value, 0, 999);
			}
		}

		public uint MP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 30, 2);
			}

			set
			{
				Util.WriteNumber(mAddress + 30, 2, value, 0, 999);
			}
		}

		public uint MaxMP
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 32, 2);
			}

			set
			{
				Util.WriteNumber(mAddress + 32, 2, value, 0, 999);
			}
		}

		public uint MagicLv
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 34, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 34, 1, value, 0, 8);
			}
		}

		public uint Power
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 35, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 35, 1, value, 0, 255);
			}
		}

		public uint Speed
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 36, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 36, 1, value, 0, 255);
			}
		}

		public uint Intelligence
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 37, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 37, 1, value, 0, 255);
			}
		}

		public uint Strength
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 38, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 38, 1, value, 0, 255);
			}
		}

		public uint Luck
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 39, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 39, 1, value, 0, 255);
			}
		}
	}
}
