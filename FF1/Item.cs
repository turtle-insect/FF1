using System.ComponentModel;

namespace FF1
{
	class Item : INotifyPropertyChanged
	{
		private readonly uint mAddress;
		public event PropertyChangedEventHandler PropertyChanged;

		public Item(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress, 2);
			}

			set
			{
				SaveData.Instance().WriteNumber(mAddress, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress + 2, 1);
			}

			set
			{
				Util.WriteNumber(mAddress + 2, 1, value, 0, 99);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}
	}
}
