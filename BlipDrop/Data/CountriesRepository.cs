﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlipDrop.Data
{
    public class CountriesRepository
    {
        public IEnumerable<SelectListItem> GetCountries()
        {
            using (var context = new ApplicationDbContext())
            {
                IEnumerable<SelectListItem> countries = context.Countries.AsNoTracking()
                    .OrderBy(n => n.CountryNameEnglish)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Iso3.ToString(),
                            Text = n.CountryNameEnglish
                        }).ToList();
                return new SelectList(countries, "Value", "Text");
            }
        }
    }
}