using System.Net;

namespace StockCount.Tests
{
    public static class TestHelper
    {
        public static bool CheckConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
