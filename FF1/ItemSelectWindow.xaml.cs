using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FF1
{
    /// <summary>
    /// ItemSelectWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ItemSelectWindow : Window
    {
		public enum eKind
		{
			eItem,
			eMagic,
			eWeapon,
			eArmor,
		};
		public uint ID { get; set; }
		public eKind Kind { get; set; }

		public ItemSelectWindow()
        {
            InitializeComponent();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateItemList("");
			foreach (var item in ListBoxItem.Items)
			{
				NameValueInfo info = item as NameValueInfo;
				if (info.Value == ID)
				{
					ListBoxItem.SelectedItem = item;
					ListBoxItem.ScrollIntoView(item);
					break;
				}
			}
		}

		private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			CreateItemList(TextBoxFilter.Text);
		}

		private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ButtonDecision.IsEnabled = ListBoxItem.SelectedIndex >= 0;
		}

		private void ButtonDecision_Click(object sender, RoutedEventArgs e)
		{
			NameValueInfo info = ListBoxItem.SelectedItem as NameValueInfo;
			if (info == null) return;
			ID = info.Value;
			Close();
		}

		private void CreateItemList(String filter)
		{
			ListBoxItem.Items.Clear();
			List<NameValueInfo> items = null;
			if (Kind == eKind.eItem) items = Info.Instance().Items;
			if (Kind == eKind.eMagic) items = Info.Instance().Magics;
			if (Kind == eKind.eWeapon) items = Info.Instance().Wepons;
			if (Kind == eKind.eArmor) items = Info.Instance().Armors;
			foreach (var item in items)
			{
				if (String.IsNullOrEmpty(filter) || item.Name.IndexOf(filter) >= 0)
				{
					ListBoxItem.Items.Add(item);
				}
			}
		}
	}
}
