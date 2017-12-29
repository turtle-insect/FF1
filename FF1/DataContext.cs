using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FF1
{
    class DataContext
    {
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();

		public DataContext()
		{
			for (uint i = 0; i < 4; i++)
			{
				Party.Add(new Charactor(0x1A + 92 * i) { Name = (i + 1) + "人目" });
			}
		}
	}
}
