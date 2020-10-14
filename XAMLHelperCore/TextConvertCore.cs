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
      if (spacePosition == -1 || equalPosition == -1)
        return $"<Style TargetType=\"{content}\"></Style>";

      //Get TAG Name
      var startTag = 0;
      var endTag = spacePosition - 1;
      var Tag = content.Substring(startTag, endTag - startTag + 1);

      string textReturn = "";
      for (int i = 0; i < content.Length; i++)
      {
        if (content[i] == '=')
        {
          //Get Attribute
          int startAttribute = -1;
          int recorreAttribute = i - 1;
          while (content[recorreAttribute] != ' ')
          {
            startAttribute = recorreAttribute;
            recorreAttribute--;
          }
          int endAttribute = i - 1;
          string Attribute = content.Substring(startAttribute, endAttribute - startAttribute + 1);

          //Get Value
          int endValue = -1;
          int recorreValue = i + 2;
          while (content[recorreValue] != '\"')
          {
            endValue = recorreValue;
            recorreValue++;
          }
          int startValue = i + 2;
          string Value = content.Substring(startValue, endValue - startValue + 1);

          //Add Attrubutes and Values
          textReturn += $"\r\n<Setter Property=\"{Attribute}\" Value=\"{Value}\" />";
        }
      }
      return $"<Style TargetType=\"{Tag}\">"+textReturn+ "\r\n</Style>";

    }
  }

  class AttributeAndValue
  {
    public string Attribute { get; set; }
    public string Value { get; set; }
  }
}
