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
  }
}
