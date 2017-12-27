using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF1
{
	class Charactor
	{
		private readonly uint mAddress;
		public Charactor(uint address)
		{
			mAddress = address;
		}

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
	}
}
