using Nest;
using System;

namespace Console642.Class
{
    class Setting
    {
        public static string strConnectionString = @"http://localhost:9200";
        public static Uri Node
        {
            get
            {
                return new Uri(strConnectionString);
            }
        }
        public static ConnectionSettings ConnectionSettings
        {
            get
            {
                return new ConnectionSettings(Node).DefaultIndex("default");
            }
        }
    }
}
