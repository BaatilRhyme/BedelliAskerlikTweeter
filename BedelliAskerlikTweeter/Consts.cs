using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedelliAskerlikTweeter
{
    public class Consts
    {
        #region Project Parameters key
        internal const string SYSTEM_NAME = "ProfSocial.FacebookDataCollector";
        internal const string BASE_URL = "https://graph.facebook.com/search";
        internal const string BASE_URI = "https://graph.facebook.com";
        internal const string WORDS_KEY = "words";
        internal const string PROVIDER_KEY = "Provider";
        internal const string WORD = "Word";
        internal const string GEOX = "Geox";
        internal const string GEOY = "Geoy";
        internal const string DISTANCE = "Distance";
        internal const string PROJECT_NAME = "ProjectCode";
        internal const int MAX_RESULT = 500;
        internal const string TYPE = "FacebookSearchType";
        internal const string TRACE_LOG_KEY = "TraceLog";
        #endregion
        #region Provider keys
        internal const string LIMIT_KEY = "limit";
        internal const string QUERY_KEY = "q";
        internal const string UNTIL_KEY = "until";
        internal const string SINCE_KEY = "since";
        internal const string CENTER_KEY = "center";
        internal const string DISTANCE_KEY = "distance";
        internal const string DATA_KEY = "data";
        internal const string PAGING_KEY = "paging";
        internal const string NEXT_PAGE_KEY = "next";
        internal const string TYPE_KEY = "type";
        internal const string DEFAULT_OBJECT_TYPE = "post";
        internal static string[] OBJECT_TYPES = { "post", "user", "page", "event", "application", "group", "place" };
        #endregion
        internal const char COMMA_SEPERATOR = ',';


        internal const string DESCRIPTION = "description";

        internal const string MESSAGE = "message";
    }
}
