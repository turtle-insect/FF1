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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

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
	}
}
