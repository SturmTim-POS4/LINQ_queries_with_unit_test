using PersonDbLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LinqCsvDemo
{
  public class LinqQueries
  {
    private readonly PersonContext db;

    public LinqQueries(PersonContext db)
    {
      this.db = db;
    }

    public List<string> MalesStreetNrLessThan10()
    {
      return new();
    }

    public List<string> FirstnamesInChina()
    {
      return new();
    }

    public int MaxStreetNrInCountry(string country)
    {
      return -1;
    }

    public List<string> CountriesWithEmailEndingWithOrg()
    {
      return new();
    }

    public List<Person> PersonsFromIndonesia()
    {
      return new();
    }
  }
}
