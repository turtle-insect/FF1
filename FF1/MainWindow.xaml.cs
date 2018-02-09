using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FF1
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;
			if (!System.IO.File.Exists(files[0])) return;

			if (SaveData.Instance().Open(files[0]) == false)
			{
				MessageBox.Show("読込失敗");
				return;
			}
			Init();
			MessageBox.Show("読込成功");
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			Load();
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().SaveAs(dlg.FileName) == true) MessageBox.Show("書込成功");
			else MessageBox.Show("書込失敗");
		}

		private void MenuItemExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ToolBarFileOpen_Click(object sender, RoutedEventArgs e)
		{
			Load();
		}

		private void ToolBarFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void ToolBarAdventure_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			SaveData.Instance().Adventure = (uint)cb?.SelectedIndex;
			Init();
		}

		private void ButtonMagic1_Click(object sender, RoutedEventArgs e)
		{
			SelectMagic(((sender as Button).DataContext as MagicGroup).Magic1);
		}

		private void ButtonMagic2_Click(object sender, RoutedEventArgs e)
		{
			SelectMagic(((sender as Button).DataContext as MagicGroup).Magic2);
		}

		private void ButtonMagic3_Click(object sender, RoutedEventArgs e)
		{
			SelectMagic(((sender as Button).DataContext as MagicGroup).Magic3);
		}

		private void ButtonWeapon_Click(object sender, RoutedEventArgs e)
		{
			Charactor ch = (sender as Button).DataContext as Charactor;
			if (ch == null) return;

			ItemSelectWindow window = new ItemSelectWindow();
			window.Kind = ItemSelectWindow.eKind.eWeapon;
			window.ID = ch.Weapon;
			window.ShowDialog();
			ch.Weapon = window.ID;
		}

		private void ButtonShield_Click(object sender, RoutedEventArgs e)
		{
			Charactor ch = (sender as Button).DataContext as Charactor;
			if (ch == null) return;

			ItemSelectWindow window = new ItemSelectWindow();
			window.Kind = ItemSelectWindow.eKind.eArmor;
			window.ID = ch.Shield;
			window.ShowDialog();
			ch.Shield = window.ID;
		}

		private void ButtonHead_Click(object sender, RoutedEventArgs e)
		{
			Charactor ch = (sender as Button).DataContext as Charactor;
			if (ch == null) return;

			ItemSelectWindow window = new ItemSelectWindow();
			window.Kind = ItemSelectWindow.eKind.eArmor;
			window.ID = ch.Head;
			window.ShowDialog();
			ch.Head = window.ID;
		}

		private void ButtonBody_Click(object sender, RoutedEventArgs e)
		{
			Charactor ch = (sender as Button).DataContext as Charactor;
			if (ch == null) return;

			ItemSelectWindow window = new ItemSelectWindow();
			window.Kind = ItemSelectWindow.eKind.eArmor;
			window.ID = ch.Body;
			window.ShowDialog();
			ch.Body = window.ID;
		}

		private void ButtonArm_Click(object sender, RoutedEventArgs e)
		{
			Charactor ch = (sender as Button).DataContext as Charactor;
			if (ch == null) return;

			ItemSelectWindow window = new ItemSelectWindow();
			window.Kind = ItemSelectWindow.eKind.eArmor;
			window.ID = ch.Arm;
			window.ShowDialog();
			ch.Arm = window.ID;
		}

		private void ButtonItem_Click(object sender, RoutedEventArgs e)
		{
			Item item = (sender as Button).DataContext as Item;
			if (item == null) return;

			ItemSelectWindow window = new ItemSelectWindow();
			window.Kind = ItemSelectWindow.eKind.eItem;
			window.ID = item.ID;
			window.ShowDialog();
			item.ID = window.ID;
			if (item.ID != 0 && item.Count == 0) item.Count = 1;
		}

		private void Init()
		{
			DataContext = new DataContext();
		}

		private void Load()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().Open(dlg.FileName) == false)
			{
				MessageBox.Show("読込失敗");
				return;
			}
			Init();
			MessageBox.Show("読込成功");
		}

		private void Save()
		{
			if (SaveData.Instance().Save() == true) MessageBox.Show("書込成功");
			else MessageBox.Show("書込失敗");
		}

		private void SelectMagic(Magic magic)
		{
			if (magic == null) return;

			ItemSelectWindow window = new ItemSelectWindow();
			window.Kind = ItemSelectWindow.eKind.eMagic;
			window.ID = magic.ID;
			window.ShowDialog();
			magic.ID = window.ID;
		}
	}
}
