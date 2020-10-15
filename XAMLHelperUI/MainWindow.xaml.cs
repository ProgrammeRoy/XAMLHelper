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
using XAMLHelperCore;

namespace XAMLHelperUI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      lblError.Visibility = Visibility.Hidden;
    }

    private void CleanError()
    {
      lblError.Visibility = Visibility.Hidden;
    }
    private void ShowErrorError(string message)
    {
      lblError.Visibility = Visibility.Visible;
      lblError.Text = message;
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      CleanError();
      try
      {
        ExtractStyle();
      }
      catch (Exception ex)
      {
        ShowErrorError(ex.Message);
      }
    }

    private void btnConvert_Click(object sender, RoutedEventArgs e)
    {
      CleanError();
      try
      {
        ExtractStyle();
      }
      catch (Exception ex)
      {
        ShowErrorError(ex.Message);
      }
    }

    private void ExtractStyle()
    {
      var content = txtOrigen.Text;
      if (String.IsNullOrEmpty(content))
      {
        txtDestino.Text = "";
        return;
      }

      var result = new TextConvertCore().ExtractStyle(content, new List<string>()
      {
        "x:Name",
        "Name",
        "ItemsSource"
      });
      txtDestino.Text = result;
    }
  }
}
