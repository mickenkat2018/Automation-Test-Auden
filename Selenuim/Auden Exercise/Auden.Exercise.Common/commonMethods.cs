
namespace Auden.Exercise.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;

    public class CommonMethods
    {
        public CommonMethods()
        {
        }

        public string GetAppConfigPropertyValue(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                var reader = new AppSettingsReader();
                return (string)reader.GetValue(propertyName, typeof(string));
            }

            return string.Empty;
        }

        public string RandomString(int length)
        {
            //// just a random short string for testing purposes
            return Guid.NewGuid().ToString("n").Substring(0, length);
        }
    }
}
