using System.ComponentModel;

namespace FF1
{
	class Magic : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		private readonly uint mAddress;

		public Magic(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get
			{
				return SaveData.Instance().ReadNumber(mAddress, 1);
			}

			set
			{
				SaveData.Instance().WriteNumber(mAddress, 1, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}
	}
}
