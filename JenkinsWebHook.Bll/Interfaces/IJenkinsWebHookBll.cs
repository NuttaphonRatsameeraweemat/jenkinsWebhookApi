using System;
using System.Collections.Generic;
using System.Text;

namespace JenkinsWebHook.Bll.Interfaces
{
    public interface IJenkinsWebHookBll
    {
        /// <summary>
        /// Post event url webhook.
        /// </summary>
        /// <param name="guidUrl"></param>
        void PostWebHook(string guidUrl);
    }
}
