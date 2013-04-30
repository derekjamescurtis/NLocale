using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;

namespace NLocale
{
  public class Country
  {


    public Country(string countryNameOrCode)
    {
      
      // make sure something was actually provided to our parameter
      if (String.IsNullOrWhiteSpace(countryNameOrCode))
        throw new ArgumentException("Country constructor requires a non-empty string argument");

      // convert input to lower-case so we can do a case-insensitive search
      var lcCountryNameOrCode = countryNameOrCode.ToLowerInvariant();
      if (lcCountryNameOrCode.Length == 2)
      {
        // search our country codes collection -- make sure our provided name actually exists
        string code = AllCodes.Where(e => e.ToLower() == lcCountryNameOrCode).FirstOrDefault();

        if (code == null)
          throw new ArgumentException("Invalid Country Code.");

        _countryNode = AllCountryData.DocumentElement.SelectSingleNode(string.Format("country[code=\"{0}\"]", code));

      }
      else
      {
        // search our code names collection -- make sure our provided name actually exists 
        string name = AllFullNames.Where(e => e.ToLowerInvariant() == lcCountryNameOrCode).FirstOrDefault();

        if (name == null)
          throw new ArgumentException("Invalid Country Name");

        _countryNode = AllCountryData.DocumentElement.SelectSingleNode(string.Format("country[name=\"{0}\"]", name));

      }

      if (_countryNode == null)
        throw new Exception("you fucked up your xpath");

    }
    readonly XmlNode _countryNode;


    public string Code
    {
      get 
      {
        if (_code == null)        
          _code = _countryNode.SelectSingleNode("code").InnerText;
        

        return _code;
      }
    }
    string _code;

    public string FullName
    {
      get 
      {
        if (_fullName == null)
          _fullName = _countryNode.SelectSingleNode("name").InnerText;

        return _fullName;
      }
    }
    string _fullName;

    public ReadOnlyCollection<SubCountry> SubCountries
    {
      get
      {
        if (_subCountries == null)
        {

          var subcountries = new List<SubCountry>();

          var subcountryNodes = _countryNode.SelectNodes("subcountry");
          foreach (XmlNode node in subcountryNodes)
          {
            subcountries.Add(new SubCountry(node, this));
          }

          _subCountries = new ReadOnlyCollection<SubCountry>(subcountries);
        }

        return _subCountries;
      }
    }
    ReadOnlyCollection<SubCountry> _subCountries;
    


    /** <summary>Returns a list of all known country codes in alphabetical order.  NOTE:  This is not the same order as AllFullNames.</summary>
     * <returns>A string array of all known country codes.</returns>
     */
    public static ReadOnlyCollection<string> AllCodes
    {
      get
      {
        if (_allCodes == null)
        {

          // select all the country code nodes
          var root = Country.AllCountryData.DocumentElement;

          XmlNodeList codeNodes = root.SelectNodes("country/code");

          // add to arry, sort in alphabetical order
          string[] countryCodes = new string[codeNodes.Count];

          for (int i = 0; i < codeNodes.Count; i++)
            countryCodes[i] = codeNodes[i].InnerText;

          // sort the array in the proper order
          Array.Sort(countryCodes);

          // populate our read-only collection
          _allCodes = new ReadOnlyCollection<string>(countryCodes);
        }

        return _allCodes;
      }
    }
    static ReadOnlyCollection<string> _allCodes;

    /** <summary></summary>
     * <returns></returns>
     */
    public static ReadOnlyCollection<string> AllFullNames
    {
      get
      {
        if (_allFullNames == null)
        {

          var root = Country.AllCountryData.DocumentElement;

          // find all the top-level country names
          XmlNodeList nameNodes = root.SelectNodes("country/name");

          // add to an array, then sort in alphabetical order
          string[] countryNames = new string[nameNodes.Count];
          
          for (int i = 0; i < nameNodes.Count; i++)
            countryNames[i] = nameNodes[i].InnerText;

          Array.Sort(countryNames);

          // populate our read-only collection field
          _allFullNames = new ReadOnlyCollection<string>(countryNames);
        }

        return _allFullNames;
      }
    }
    static ReadOnlyCollection<string> _allFullNames;


    public static ReadOnlyCollection<Country> AllCountries
    {
      get
      {

        if (_allCountries == null)
        {
          Country[] tempCountries = new Country[AllFullNames.Count];

          for (int i = 0; i < AllFullNames.Count; i++)
            tempCountries[i] = new Country(AllFullNames[i]);

          _allCountries = new ReadOnlyCollection<Country>(tempCountries);

        }

        return _allCountries;
      }
    }
    static ReadOnlyCollection<Country> _allCountries;

    static XmlDocument AllCountryData
    {
      get
      {
        if (_allCountryData == null)
        {

          var str = string.Empty;

          using (Stream stream = Type.GetType("NLocale.Country", true).Assembly.GetManifestResourceStream("NLocale.Data.xml"))
          {
            using (StreamReader sr = new StreamReader(stream))
            {
              str = sr.ReadToEnd();
            }
          }
          _allCountryData = new XmlDocument();
          _allCountryData.LoadXml(str);

        }

        return _allCountryData;
      }
    }
    static XmlDocument _allCountryData;


    /*

    new Locale::SubCountry::World
full_name_code_hash (for world objects)
code_full_name_hash for world objects)


country
country_code
code
     
full_name
category
regional_division
has_sub_countries
FIPS10_4_code
ISO3166_2_code
     * 
     * 
     * 
full_name_code_hash (for subcountry objects)
code_full_name_hash (for subcountry objects)
all_full_names (for subcountry objects)
all_codes (for subcountry objects)
     * 
     * */

  }
}
