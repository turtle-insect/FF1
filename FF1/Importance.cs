using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FF1
{
	class Importance : INotifyPropertyChanged
	{
		private readonly uint mAddress;
		private readonly uint ID;
		public event PropertyChangedEventHandler PropertyChanged;

		public Importance(uint address, uint id)
		{
			mAddress = address;
			ID = id;
		}

		public String Name { get; set; }

		public bool Exist
		{
			get
			{
				return SaveData.Instance().ReadBit(mAddress + ID / 8, ID % 8);
			}

			set
			{
				SaveData.Instance().WriteBit(mAddress + ID / 8, ID % 8, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Exist)));
			}
		}
	}
}
