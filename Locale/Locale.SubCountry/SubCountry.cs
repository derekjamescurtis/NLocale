using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locale.SubCountry
{
  class SubCountry
  {


    //package Locale::SubCountry;
    //our $VERSION = '1.61';

    //#-------------------------------------------------------------------------------
    //# Initialization code must be run first to create global data structure.
    //# Read in the list of abbreviations and full names defined in the
    //# Locale::SubCountry::Data package

    //{

    //    unless ( $Locale::SubCountry::Data::xml_data )
    //    {
    //      die "Could not locate Locale::SubCountry::Data::xml_data variable";
    //    }

    //    # Get all the data from the Locale::SubCountryData pakage and place into an array of lines
    //    my @lines = split(/\n/,$Locale::SubCountry::Data::xml_data);

    //    while ( @lines )
    //    {
    //        my $current_line = shift(@lines);

    //        # Data is in XML format, use a simple parser to extract it
    //        my ($country_name,$country_code);
    //        if ( $current_line =~ /<country>/ )
    //        {
    //            # start of a  <country> .. </country> block
    //            my $country_finished = 0;
    //            until ( $country_finished )
    //            {
    //                $current_line = shift(@lines);
    //                if ( $current_line =~ /\s*<name>(.*)<\/name>/ )
    //                {
    //                    $country_name = $1;
    //                }
    //                elsif ( $current_line =~ /\s*<code>(.*)<\/code>/ )
    //                {
    //                    $country_code = $1;
    //                }
    //                elsif ( $current_line =~ /<subcountry>/ )
    //                {
    //                    my $sub_country_finished = 0;

    //                    my ($sub_country_name,$sub_country_code,$category,$regional_division,$FIPS_code);
    //                    until ( $sub_country_finished )
    //                    {
    //                        $current_line = shift(@lines);
    //                        if ( $current_line =~ /\s*<name>(.*)<\/name>/ )
    //                        {
    //                            $sub_country_name = $1;
    //                        }
    //                        elsif ( $current_line =~ /\s*<code>(.*)<\/code>/ )
    //                        {
    //                            $sub_country_code = $1;
    //                        }
    //                        elsif ( $current_line =~ /\s*<FIPS>(.*)<\/FIPS>/ )
    //                        {
    //                            $FIPS_code = $1;
    //                        }
    //                        elsif ( $current_line =~ /\s*<category>(.*)<\/category>/ )
    //                        {
    //                            $category = $1;
    //                        }
    //                        elsif ( $current_line =~ /\s*<regional_division>(.*)<\/regional_division>/ )
    //                        {
    //                            $regional_division = $1;
    //                        }
    //                        elsif ( $current_line =~ /<\/subcountry>/ )
    //                        {

    //                            $sub_country_finished = 1;

    //                            # Some sub countries have no ISO code, such as Shariff Kabunsuan in the
    //                            # Phillipines. Only index sub country if it has a code
    //                            if ( defined $sub_country_code )
    //                            {
    //                                # Insert into doubly indexed hash, grouped by country for ISO 3166-2
    //                                # codes. One hash is keyed by abbreviation and one by full name. Although
    //                                # data is duplicated, this provides the fastest lookup and simplest code.

    //                                $Locale::SubCountry::subcountry_lookup{$country_name}{_code_keyed}{$sub_country_code} = $sub_country_name;
    //                                $Locale::SubCountry::subcountry_lookup{$country_name}{_full_name_keyed}{$sub_country_name} = $sub_country_code;
    //                            }

    //                            if ( $category )
    //                            {
    //                                $Locale::SubCountry::subcountry_lookup{$country_name}{$sub_country_code}{_category} = $category;
    //                            }

    //                            if ( $regional_division )
    //                            {
    //                                $Locale::SubCountry::subcountry_lookup{$country_name}{$sub_country_code}{_regional_division} = $regional_division;
    //                            }

    //                            if ( $FIPS_code )
    //                            {
    //                                # Insert into doubly indexed hash, grouped by country for FIPS 10-4 codes
    //                                $Locale::SubCountry::subcountry_lookup{$country_name}{_FIPS10_4_code_keyed}{$FIPS_code} = $sub_country_code;
    //                                $Locale::SubCountry::subcountry_lookup{$country_name}{_ISO3166_2_code_keyed}{$sub_country_code} = $FIPS_code;
    //                            }
    //                        }
    //                        elsif ( $current_line =~ /\w.*/ )
    //                        {
    //                            die "Badly formed XML sub country data in $country_name\nData: $current_line\n";
    //                        }
    //                    }
    //                }
    //                elsif ( $current_line =~ /<\/country>/ )
    //                {
    //                    $country_finished = 1;

    //                    # Create doubly indexed hash, keyed by  country code and full name.
    //                    # The user can supply either form to create a new sub_country
    //                    # object, and the objects properties will hold both the countries
    //                    # name and it's code.

    //                    $Locale::SubCountry::country_lookup{_code_keyed}{$country_code} = $country_name;
    //                    $Locale::SubCountry::country_lookup{_full_name_keyed}{$country_name} = $country_code;

    //                }
    //                elsif ( $current_line =~ /\w.*/ )
    //                {
    //                    die "Badly formed XML country data in $country_name\nData: $current_line\n";
    //                }
    //            }
    //        }
    //    }
    //}

    //#-------------------------------------------------------------------------------
    //# Create new instance of a sub country object


    public void SubCountry(string country_or_code)
    {

      if (country_or_code.Length == 2)
      {

        //        $country_or_code = uc($country_or_code); # lower case codes may be used, so fold to upper case
        country_or_code = country_or_code.ToUpper();



        //        if ( $Locale::SubCountry::country_lookup{_code_keyed}{$country_or_code} )
        //        {
        //            $country_code = $country_or_code;
        //            # set country to it's full name
        //            $country = $Locale::SubCountry::country_lookup{_code_keyed}{$country_code};
        //         }
        //        else
        //        {
        //          warn "Invalid country code: $country_or_code chosen";
        //          return(undef);
        //        }
      }
      else
      {
        //        if ( $Locale::SubCountry::country_lookup{_full_name_keyed}{$country_or_code} )
        //        {
        //            $country = $country_or_code;
        //            $country_code = $Locale::SubCountry::country_lookup{_full_name_keyed}{$country};
        //        }
        //        else
        //        {
        //            warn "Invalid country name: $country_or_code chosen, names must be in title case";
        //            return(undef);

      }


      //    my ($country,$country_code);


      //    # Country may be supplied either as a two letter code, or the full name
      //    if ( length($country_or_code) == 2 )
      //    {

      //    }
      //    else
      //    {

      //        }
      //    }

      //    my $sub_country = {};
      //    bless($sub_country,$class);
      //    $sub_country->{_country} = $country;
      //    $sub_country->{_country_code} = $country_code;


      //    return($sub_country);

    }






    //#-------------------------------------------------------------------------------
    //# Returns the current country of the sub country object

    //sub country
    //{
    //    my $sub_country = shift;
    //    return( $sub_country->{_country} );
    //}
    //#-------------------------------------------------------------------------------
    public string country { get; private set; }


    //# Returns the current country code of the sub country object

    //sub country_code
    //{
    //    my $sub_country = shift;
    //    return( $sub_country->{_country_code} );
    //}
    public string country_code { get; private set; }

    //#-------------------------------------------------------------------------------
    //# Given the full name for a sub country, return the ISO 3166-2 code

    public string code
    {
      get
      {

        //sub code
        //{
        //    my $sub_country = shift;
        //    my ($full_name) = @_;

        //    my $orig = $full_name;

        //    $full_name = _clean($full_name);

        //    my $code = $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_full_name_keyed}{$full_name};

        //    # If a code wasn't found, it could be because the user's capitalization
        //    # does not match the one in the look up data of this module. For example,
        //    # the user may have supplied the sub country "Ag R" (in Turkey) but the
        //    # ISO standard defines the spelling as "Ag r".

        //    unless ( defined $code )
        //    {
        //        # For every sub country, compare upper cased full name supplied by user
        //        # to upper cased full name from lookup hash. If they match, return the
        //        # correctly cased full name from the lookup hash.

        //        my @all_names = $sub_country->all_full_names;
        //        my $current_name;
        //        foreach $current_name ( @all_names )
        //        {
        //            if ( uc($full_name) eq uc($current_name) )
        //            {
        //                $code = $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_full_name_keyed}{$current_name};
        //            }
        //        }
        //    }

        //    if ( defined $code )
        //    {
        //        return($code);
        //    }
        //    else
        //    {
        //        return('unknown');
        //    }
        //}

        return _code;
      }
      private set
      {
        _code = value;
      }
    }
    private string _code;


    //#-------------------------------------------------------------------------------
    //# Given the ISO 3166-2 code for a sub country, return the FIPS 104-4 code.

    //sub FIPS10_4_code
    //{
    //    my $sub_country = shift;
    //    my ($code) = @_;

    //    $code = _clean($code);
    //    $code = uc($code);

    //    my $FIPS_code = $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_ISO3166_2_code_keyed}{$code};

    //    if ( $FIPS_code )
    //    {
    //        return($FIPS_code);
    //    }
    //    else
    //    {
    //        return('unknown');
    //    }
    //}





    //#-------------------------------------------------------------------------------
    //# Given the FIPS 10-4 code for a sub country, return the ISO 3166-2 code.

    //sub ISO3166_2_code
    //{
    //    my $sub_country = shift;
    //    my ($FIPS_code) = @_;

    //    $FIPS_code = _clean($FIPS_code);

    //    my $code = $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_FIPS10_4_code_keyed}{$FIPS_code};

    //    if ( $code )
    //    {
    //        return($code);
    //    }
    //    else
    //    {
    //        return('unknown');
    //    }
    //}
    //#-------------------------------------------------------------------------------
    //# Given the ISO 3166-2 code for a sub country, return the category,
    //# being state, province, city, council etc

    //sub category
    //{
    //    my $sub_country = shift;
    //    my ($code) = @_;

    //    $code = _clean($code);

    //    my $category = $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{$code}{_category};

    //    if ( $category )
    //    {
    //        return($category);
    //    }
    //    else
    //    {
    //        return('unknown');
    //    }
    //}

    //#-------------------------------------------------------------------------------
    //# Given the ISO 3166-2 code for a sub country, return the regional division,

    //sub regional_division
    //{
    //    my $sub_country = shift;
    //    my ($code) = @_;

    //    $code = _clean($code);

    //    my $regional_division = $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{$code}{_regional_division};

    //    if ( $regional_division )
    //    {
    //        return($regional_division);
    //    }
    //    else
    //    {
    //        return('unknown');
    //    }
    //}

    //#-------------------------------------------------------------------------------
    //# Given the ISO 3166-2 code for a sub country, return the full name.
    //# Parameters are the code and a flag, which if set to true
    //# will cause the full name to be uppercased

    //sub full_name
    //{
    //    my $sub_country = shift;
    //    my ($code,$uc_name) = @_;

    //    $code = _clean($code);
    //    $code = uc($code);

    //    my $full_name =
    //        $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_code_keyed}{$code};
    //    if ( $uc_name )
    //    {
    //        $full_name = uc($full_name);
    //    }

    //    if ( $full_name )
    //    {
    //        return($full_name);
    //    }
    //    else
    //    {
    //        return('unknown');
    //    }
    //}
    //#-------------------------------------------------------------------------------
    //# Returns 1 if the current country has sub countries. otherwise 0.

    //sub has_sub_countries
    //{
    //    my $sub_country = shift;
    //    if ( $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_code_keyed} )
    //    {
    //        return(1);
    //    }
    //    else
    //    {
    //        return(0);
    //    }
    //}
    //#-------------------------------------------------------------------------------
    //# Returns a hash of code/full name pairs, keyed by sub country code.

    //sub code_full_name_hash
    //{
    //    my $sub_country = shift;
    //    if ( $sub_country->has_sub_countries )
    //    {
    //        return( %{ $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_code_keyed} } );
    //    }
    //    else
    //    {
    //        return(undef);
    //    }
    //}
    //#-------------------------------------------------------------------------------
    //# Returns a hash of name/code pairs, keyed by sub country name.

    //sub full_name_code_hash
    //{
    //    my $sub_country = shift;
    //    if ( $sub_country->has_sub_countries )
    //    {
    //        return( %{ $Locale::SubCountry::subcountry_lookup{$sub_country->{_country}}{_full_name_keyed} } );
    //    }
    //    else
    //    {
    //        return(undef);
    //    }
    //}
    //#-------------------------------------------------------------------------------
    //# Returns sorted array of all sub country full names for the current country

    //sub all_full_names
    //{
    //    my $sub_country = shift;
    //    if ( $sub_country->full_name_code_hash )
    //    {
    //        my %all_full_names = $sub_country->full_name_code_hash;
    //        if ( %all_full_names )
    //        {
    //            return( sort keys %all_full_names );
    //        }
    //    }
    //    else
    //    {
    //        return(undef);
    //    }
    //}
    //#-------------------------------------------------------------------------------
    //# Returns sorted array of all sub country ISO 3166-2 codes for the current country

    //sub all_codes
    //{
    //    my $sub_country = shift;

    //    if ( $sub_country->code_full_name_hash )
    //    {
    //        my %all_codes = $sub_country->code_full_name_hash;
    //        return( sort keys %all_codes );
    //    }
    //    else
    //    {
    //        return(undef);
    //    }
    //}

    //#-------------------------------------------------------------------------------
    //sub _clean
    //{
    //    my ($input_string) = @_;

    //    if ( $input_string =~ /[\. ]/ )
    //    {
    //        # remove dots
    //        $input_string =~ s/\.//go;

    //        # remove repeating spaces
    //        $input_string =~ s/  +/ /go;

    //        # remove any remaining leading or trailing space
    //        $input_string =~ s/^ //;
    //        $input_string =~ s/ $//;
    //    }

    //    return($input_string);
    //}

    //return(1);

    private void _clean(string input_string)
    {




      // remove any leading or trailing spaces
      input_string = input_string.Trim();

    }




  }
}
