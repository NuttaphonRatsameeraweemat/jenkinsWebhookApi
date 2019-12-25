using JenkinsWebHook.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JenkinsWebHook.Bll
{
    public class JenkinsWebHookBll : IJenkinsWebHookBll
    {

        #region [Fields]

        /// <summary>
        /// The HttpClient request.
        /// </summary>
        private readonly HttpClient _client;
        /// <summary>
        /// The base address url jenkins webhook.
        /// </summary>
        private const string BaseAddress = "http://172.16.3.20:8080/webhook-step/";

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="JenkinsWebHookBll" /> class.
        /// </summary>
        public JenkinsWebHookBll()
        {
            _client = new HttpClient();
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Post event url webhook.
        /// </summary>
        /// <param name="guidUrl"></param>
        public void PostWebHook(string guidUrl)
        {
            using (HttpResponseMessage response = _client.PostAsync($"{BaseAddress}{guidUrl}", null).Result)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }

        #endregion

    }
}
