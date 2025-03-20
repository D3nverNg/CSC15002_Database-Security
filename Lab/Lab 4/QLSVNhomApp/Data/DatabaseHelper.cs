using System.Configuration;

namespace QLSVNhomApp.Data
{
    public static class DatabaseHelper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["QLSVNhomConnection"].ConnectionString;
            }
        }
    }
}
