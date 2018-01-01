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
	}
}
