Name
====
NLocale - v 0.01

Synopsis
====
use NLocale;

// List all countries
foreach (var country in Country.AllCountries)      
  Console.WriteLine("Country {0} has {1} subcountries", country.FullName, country.SubCountries.Count);
      
	  
try {

  // Both of these will work just fine. -- creates two instances with value equality.
  var america = new Country("US");
  var americaAlso = new Country("United States");
  
  // Prints the number of states/territories - 57
  Console.WriteLine("America has {0} subcountries", america.SubCountries.Count);
  Console.WriteLine("America has {0} subcountries", americaAlso.SubCountries.Count);
  
  
  // An unknown name/country code will thrown an exception (like this)
  var whatIsThis = new Country("BLAHRGHERR");

}
catch(ArgumentException ex) {
  Console.WriteLine("Invalid country code!!");
}
	  
	  

Description
===
This is a port of the perl module Locale::SubCountry 1.61

The original module (and source) can be found here: https://metacpan.org/module/Locale::SubCountry

I've renamed things according to .NET conventions.. and although I say it's a port, it's really a port of the interface only. 
I made no attempt to modify the original code.. I just dropped it and duplicated the methods provided (the original code
does thinks like manually parse the XML document as a string using regex, which I know they did to eliminate dependency on
another CPAN module, but since .NET comes with things like XML parsers included, I take advantage of them).

Note
===
'Shariff Kabunsuan' has been commented out of the original xml document as it doesn't have an iso code associated with it, and no longer exists (since 2008).  Otherwise, the XML document matches the 
above-mentioned perl module version

Author
====
Derek J. Curtis

djcurtis@summersetsoftware.com

Summerset Software, LLC

Although I've written the C# code, a TON of credit goes to the original module authors (whose work I've used in my Perl projects) for the idea
of this module and for compiling the XML data that runs this library.

License
====
This library is free software; you can redistribute it and/or modify it under the same terms as Perl.  http://dev.perl.org/licenses/