using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchooledSite.Services
{
    public static class StringConversionService
    {
        public static string NoNull(this string value)
        {
            return (value == null) ? "" : value.Trim();
        }
    }
}