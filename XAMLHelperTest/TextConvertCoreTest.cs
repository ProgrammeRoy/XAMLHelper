using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAMLHelperCore;
using Xunit;

namespace XAMLHelperTest
{
  public class TextConvertCoreTest
  {
    [Fact]
    public void OnlyDataTypeTest()
    {
      // datos
      var dato = "<Grid>";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\"></Style>";
      Assert.Equal(String.Empty, expected);
    }

    [Fact]
    public void OnlyDataTypeEnclosingTest()
    {
      // datos
      var dato = "<Grid></Grid>";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\"></Style>";
      Assert.Equal(String.Empty, expected);
    }

    [Fact]
    public void GridControl_WithOneParameter()
    {
      // datos
      var dato = "<Grid Margin=\"3\">";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\"><Setter Property=\"Margin\" Value=\"3\" /></Style>";
      Assert.Equal(String.Empty, expected);
    }

    [Fact]
    public void GridControlEnclosing_WithOneParameter()
    {
      // datos
      var dato = "<Grid Margin=\"3\"></Grid>";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\"><Setter Property=\"Margin\" Value=\"3\" /></Style>";
      Assert.Equal(String.Empty, expected);
    }
  }
}
