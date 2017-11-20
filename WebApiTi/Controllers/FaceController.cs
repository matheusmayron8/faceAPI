using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTi.Models;


namespace WebApiTi.Controllers
{
    [Produces("application/json")]
    [Route("api/face")]
    public class FaceController : Controller
    {
        //GET: api/face
        [HttpPost]
        public string Post([FromBody]Face json)
        {
            //BD bd = new BD();
            //bd.verificaUsuario(json).ToString();
            return Newtonsoft.Json.JsonConvert.SerializeObject(json);
        }
    }
}
