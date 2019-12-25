using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JenkinsWebHook.Bll.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenkinsWebHook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenkinsWebHookController : ControllerBase
    {

        #region [Fields]

        /// <summary>
        /// The jenkins webhook manager provides jenkins webhook functionality.
        /// </summary>
        private readonly IJenkinsWebHookBll _jenkins;

        #endregion

        #region [Constructors]

        /// <summary>
        ///  Initializes a new instance of the <see cref="JenkinsWebHookController" /> class.
        /// </summary>
        /// <param name="approval"></param>
        public JenkinsWebHookController(IJenkinsWebHookBll jenkins)
        {
            _jenkins = jenkins;
        }

        #endregion

        #region [Methods]

        [HttpGet]
        [Route("ApproveWebHookDeploy/{guidUrl}")]
        public IActionResult ApproveWebHookDeploy(string guidUrl)
        {
            _jenkins.PostWebHook(guidUrl);
            return Ok();
        }

        #endregion

    }
}