using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NLocale
{
  public class SubCountry
  {


    protected internal SubCountry(XmlNode node, Country parent)
    {

      // just a reference back to the parent country
      this.Parent = parent;


      // these two nodes should be present for every sub country
      FullName  = node.SelectSingleNode("name").InnerText;

      Code      = node.SelectSingleNode("code").InnerText;


      // the following three nodes are not present for all subcountry object
      // category node
      var categoryNode = node.SelectSingleNode("category");
      if (categoryNode != null)
        Category = categoryNode.InnerText;

      // regional division
      var regionNode = node.SelectSingleNode("regional_division");
      if (regionNode != null)
        RegionalDivision = regionNode.InnerText;

      // FIPS
      var fipsNode = node.SelectSingleNode("FIPS");
      if (fipsNode != null)
        FIPS4_10 = fipsNode.InnerText;

    }


    public string FullName { get; private set; }
    public string Code { get; set; }

    public string Category { get; private set; }
    public string RegionalDivision { get; private set; }
    public string FIPS4_10 { get; private set; }
    

    public Country Parent { get; private set; }

  }
}
