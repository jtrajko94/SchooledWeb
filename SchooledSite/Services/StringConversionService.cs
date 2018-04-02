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