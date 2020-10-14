using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMLHelperCore
{
  public class TextConvertCore
  {
    public string ExtractStyle(string text)
    {
      if (string.IsNullOrEmpty(text))
        return "";
    
      if (text.Length - 2 > 1)
      {
        var start = text.IndexOf('<') + 1;
        var end = text.IndexOf('>') - 1;
        var onlyText = text.Substring(start, end);
        return $"<Style TargetType=\"{onlyText}\"></Style>";
      }
      else
      {
        return "";
      }
    }

  }
}
