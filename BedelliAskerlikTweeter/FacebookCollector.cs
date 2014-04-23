using BedelliAskerlikTweeter.FluentHttp.Authenticators;
using FluentHttp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TweetSharp;

namespace BedelliAskerlikTweeter
{
    public class FacebookCollector
    {
        string filenameFormat = "{0}.bedellifacebook";
        private string m_baseUrl;
        private string m_untilValue;
        private readonly TwitterService _twitterService;
        private readonly Form1 _form;
        public FacebookCollector(TwitterService service, Form1 form)
        {
            m_baseUrl = Consts.BASE_URL;
            IsStarted = false;
            _twitterService = service;
            _form = form;
        }
        public bool IsStarted;
        public void Stop()
        {
            IsStarted = false;
        }
        private string additionalString;
        public void Start(string keyword, string addString)
        {
            IsStarted = true;
            additionalString=addString;
            var posts = GetPublicPosts(keyword);
            
            IsStarted = false;
        }
        private IList<string> GetPublicPosts(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return new List<string>();

            var projectparameters = new Dictionary<string, object>();
            projectparameters.Add(Consts.WORD, keyword);
            var query = this.BuildQuery(projectparameters);
            query.Add(Consts.SINCE_KEY, GetSinceValue(keyword));
            query.Add(Consts.TYPE_KEY, Consts.DEFAULT_OBJECT_TYPE);
            List<string> results = new List<string>();
            GetAllResultsRecursive(m_baseUrl, query, results, projectparameters);
            return results;
        }
        private string GetFacebookToken()
        {
            var oauthuri = Consts.BASE_URI + "/oauth/access_token?client_id=******&client_secret=****&grant_type=client_credentials";
            using (var responseSaveStream = new MemoryStream())
            {

                var request = new FluentHttpRequest()
                       .BaseUrl(oauthuri)
                       .Method("GET")
                       .Proxy(WebRequest.DefaultWebProxy)
                       .OnResponseHeadersReceived((o, e) => e.SaveResponseIn(responseSaveStream));
                var ar = request.Execute();

                var response = ar.Response;

                // seek the save stream to beginning.
                response.SaveStream.Seek(0, SeekOrigin.Begin);

                var token = FluentHttpRequest.ToString(response.SaveStream);
                return token.Split('=')[1];
            }
        }
        private void WriteSince(string keyword, string since)
        {
            var filename = string.Format(filenameFormat, keyword);
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(since);
            writer.Close();
        }
        private void GetAllResultsRecursive(string uri, IDictionary<string, object> query, List<string> results, IDictionary<string, object> projectparameters)
        {
            if (!IsStarted)
                return;
            string json = string.Empty;
            try
            {
                using (var responseSaveStream = new MemoryStream())
                {

                    var request = new FluentHttpRequest()
                           .BaseUrl(uri)
                           .Method("GET")
                           .QueryStrings(q => q
                                                   .Add(query)  //add all query strings
                                                   )
                           .Proxy(WebRequest.DefaultWebProxy)
                           .OnResponseHeadersReceived((o, e) => e.SaveResponseIn(responseSaveStream));
                    request.AuthenticateUsing(new OAuth2AuthorizationRequestHeaderBearerAuthenticator(GetFacebookToken()));
                    var ar = request.Execute();

                    var response = ar.Response;

                    // seek the save stream to beginning.
                    response.SaveStream.Seek(0, SeekOrigin.Begin);

                    json = FluentHttpRequest.ToString(response.SaveStream);

                    Dictionary<string, object> responseobject = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    if (responseobject.ContainsKey(Consts.DATA_KEY) && responseobject[Consts.DATA_KEY].HasValue())
                    {
                        IList<object> datas = JsonConvert.DeserializeObject<IList<object>>(responseobject[Consts.DATA_KEY].ToString());
                        if (datas.Count > 0)
                        {
                            for (int i = 0; i < datas.Count; i++)
                            {
                                IDictionary<string, object> resultdic = JsonConvert.DeserializeObject<Dictionary<string, object>>(datas[i].ToString());
                                //resultdic.Add(Consts.WORDS_KEY, projectparameters);
                                //resultdic.Add(Consts.PROVIDER_KEY, "FaceBook");
                                if (resultdic.ContainsKey(Consts.DESCRIPTION))
                                {
                                    var message = HttpUtility.HtmlDecode(resultdic[Consts.DESCRIPTION].ToString());
                                    results.Add(message.Substring(0, message.Length < 140 ? message.Length : 140));
                                }
                                //else if (resultdic.ContainsKey(Consts.MESSAGE))
                                //{
                                //   var message = HttpUtility.HtmlDecode(resultdic[Consts.MESSAGE].ToString());
                                //  results.Add(message.Substring(0, message.Length < 140 ? message.Length : 140));
                                // }
                                //results.Add(JsonConvert.SerializeObject(resultdic));
                                resultdic = null;
                            }
                            foreach (var post in results)
                            {
                                if (!IsStarted)
                                    return;
                                string p = string.Empty;
                                if (!string.IsNullOrEmpty(additionalString))
                                {
                                    if (140 - post.Length > additionalString.Length + 1)
                                        p = post + " " + additionalString;
                                    else
                                        p = post.Substring(0, post.Length - additionalString.Length + 1) + " " + additionalString;
                                }
                                _twitterService.SendTweet(new SendTweetOptions { Status = p });
                                _form.Log(post);
                                System.Threading.Thread.Sleep(2000);//twitter kızmasın
                            }
                            if (responseobject.ContainsKey(Consts.PAGING_KEY) && responseobject[Consts.PAGING_KEY].HasValue())
                            {
                                IDictionary<string, string> nextprevuri = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseobject[Consts.PAGING_KEY].ToString());
                                if (nextprevuri.ContainsKey(Consts.NEXT_PAGE_KEY) && nextprevuri[Consts.NEXT_PAGE_KEY].HasValue())
                                {
                                    Uri urim = new Uri(nextprevuri[Consts.NEXT_PAGE_KEY].ToString());
                                    var querystrings = ToDictionary(HttpUtility.ParseQueryString(urim.Query));
                                    urim = null;
                                    GetAllResultsRecursive(m_baseUrl, querystrings, results, projectparameters);
                                    if (string.IsNullOrEmpty(m_untilValue) && querystrings[Consts.UNTIL_KEY].HasValue())
                                    {
                                        m_untilValue = querystrings[Consts.UNTIL_KEY].ToString();
                                        WriteSince(querystrings[Consts.QUERY_KEY].ToString(), m_untilValue);
                                    }
                                }
                            }

                        }
                    }
                    request = null;
                    GC.Collect();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private string GetSinceValue(string keyword)
        {
            var filename = string.Format(filenameFormat, keyword);
            string id = "0";
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                var line = reader.ReadLine();
                reader.Close();
                if (string.IsNullOrEmpty(line))
                    return id;
                else
                    id = line;
            }
            else
            {
                File.Create(filename);
            }
            return id;

        }
        private IDictionary<string, object> BuildQuery(IDictionary<string, object> parameters)
        {
            IDictionary<string, object> query = new Dictionary<string, object>();
            string q = string.Empty;
            if (parameters.ContainsKey(Consts.WORD) && parameters[Consts.WORD].HasValue())
                q = parameters[Consts.WORD].ToString();
            query.Add(Consts.QUERY_KEY, q);

            if (parameters.ContainsKey(Consts.GEOX) && parameters.ContainsKey(Consts.GEOY)
             && parameters[Consts.GEOX].HasValue()
             && parameters[Consts.GEOY].HasValue())
                query.Add(Consts.CENTER_KEY, String.Join(Consts.COMMA_SEPERATOR.ToString(), parameters[Consts.GEOX].ToString(), parameters[Consts.GEOY].ToString()));
            if (parameters.ContainsKey(Consts.DISTANCE)
                && parameters[Consts.DISTANCE].HasValue())
                query.Add(Consts.DISTANCE_KEY, parameters[Consts.DISTANCE]);
            query.Add(Consts.LIMIT_KEY, Consts.MAX_RESULT);
            return query;
        }
        public IDictionary<string, object> ToDictionary(NameValueCollection source)
        {
            return source.Cast<string>()
                         .Select(s => new { Key = s, Value = source[s] })
                         .ToDictionary(p => p.Key, p => p.Value as object);
        }
    }
}
