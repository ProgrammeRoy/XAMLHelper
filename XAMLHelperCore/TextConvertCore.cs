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

      if (text.Length - 2 < 2)
        return "";

      var start = text.IndexOf('<') + 1;
      var end = text.IndexOf('>') - 1;
      var content = text.Substring(start, end).Trim();

      var spacePosition = content.IndexOf(" ");
      var equalPosition = content.IndexOf("=");
      if ( spacePosition == -1 || equalPosition == -1)
        return $"<Style TargetType=\"{content}\"></Style>";

      var startTag = 0;
      var endTag = spacePosition - 1;
      var Tag = content.Substring(startTag, endTag - startTag + 1);

      var startAttribute = spacePosition + 1;
      var endAttribute = equalPosition - 1;
      var Attribute = content.Substring(startAttribute, endAttribute - startAttribute + 1);

      var startValue = content.IndexOf("\"") + 1;
      var endValue = content.IndexOf("\"", startValue + 1) - 1;

      var Value = content.Substring(startValue, endValue - startValue + 1);

      return $"<Style TargetType=\"{Tag}\"><Setter Property=\"{Attribute}\" Value=\"{Value}\" /></Style>";

    }

  }
}
