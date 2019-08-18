using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Test.Token.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> GetToken(TokenModel model)
        {
            var time = DateTime.Now;
            var token = RayPIToken.IssueJWT(new TokenModel()
            {
                Uid = model.Uid,
                Sub = model.Sub
            }, new TimeSpan(time.Day, time.Hour, time.Minute + model.expireMinutes), new TimeSpan(time.Day, time.Hour, time.Minute + model.expireMinutes));
            return token;
        }
       
    }
}
