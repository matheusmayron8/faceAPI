using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTi.Controllers
{
    [Produces("application/json")]
    [Route("api/face")]
    public class FaceController : Controller
    {
        //GET: api/face
        [HttpPost]
        public string Post([FromBody]string json)
        {
            BD bd = new BD();
            return bd.verificaUsuario(json).ToString();
        }
    }
}
