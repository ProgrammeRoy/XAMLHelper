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
      var expected = "<Style TargetType=\"Grid\">" +
        "\r\n<Setter Property=\"Margin\" Value=\"3\" />" +
        "\r\n</Style>";
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
      var expected = "<Style TargetType=\"Grid\">" +
        "\r\n<Setter Property=\"Margin\" Value=\"5\" />" +
        "\r\n</Style>";
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
      var expected = "<Style TargetType=\"Grid\">" +
        "\r\n<Setter Property=\"Margin\" Value=\"3\" />" +
        "\r\n<Setter Property=\"Padding\" Value=\"2\" />" +
        "\r\n</Style>";
      Assert.Equal(expected, result);
    }

    [Fact]
    public void GridControl_WithTwoAttributes_example2()
    {
      // datos
      var dato = "<Grid Margin=\"3\" Padding=\"2\" Head=\"hola\">";
      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = "<Style TargetType=\"Grid\">" +
        "\r\n<Setter Property=\"Margin\" Value=\"3\" />" +
        "\r\n<Setter Property=\"Padding\" Value=\"2\" />" +
        "\r\n<Setter Property=\"Head\" Value=\"hola\" />" +
        "\r\n</Style>";
      Assert.Equal(expected, result);
    }

    [Fact]
    public void TextBlock_With4Attributes_WithExtraceSpace()
    {
      // datos
      var dato = @" <TextBlock       
      Height=""24""
      Margin=""64,0,0,0""
      VerticalAlignment=""Top"" /> ";

      // ejecutar
      var result = new TextConvertCore().ExtractStyle(dato);

      //probar
      var expected = @"<Style TargetType=""TextBlock"">
<Setter Property=""Height"" Value=""24"" />
<Setter Property=""Margin"" Value=""64,0,0,0"" />
<Setter Property=""VerticalAlignment"" Value=""Top"" />
</Style>";
      Assert.Equal(expected, result);
    }
  

  }
}
