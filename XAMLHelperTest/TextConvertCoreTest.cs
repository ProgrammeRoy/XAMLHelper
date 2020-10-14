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
      Assert.Equal(expected, result);
    }

    [Fact]
    public void OnlyDataType_AnotherControlTest()
    {
      // datos
      var dato = "<Text>";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Text\"></Style>";
      Assert.Equal(expected, result);
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
      Assert.Equal(expected, result);
    }

    [Fact]
    public void GridControl_WithOneAttributes()
    {
      // datos
      var dato = "<Grid Margin=\"3\">";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\"><Setter Property=\"Margin\" Value=\"3\" /></Style>";
      Assert.Equal(expected, result);
    }

    [Fact]
    public void GridControlEnclosing_WithOneAttributes()
    {
      // datos
      var dato = "<Grid Margin=\"5\"></Grid>";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\"><Setter Property=\"Margin\" Value=\"5\" /></Style>";
      Assert.Equal(expected, result);
    }

    [Fact]
    public void GridControl_WithTwoAttributes()
    {
      // datos
      var dato = "<Grid Margin=\"3\" Padding=\"2\">";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\"><Setter Property=\"Margin\" Value=\"3\" /><Setter Property=\"Padding\" Value=\"2\" /></Style>";
      Assert.Equal(expected, result);
    }
     
  }
}
