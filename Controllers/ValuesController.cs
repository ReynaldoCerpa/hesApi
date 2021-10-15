using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace apiHes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = new SqlConnection("Data source=LAPTOP-REY" + ";Initial Catalog=hutchinson" + ";User ID=root" + ";Password=pass" + ";");
                conSQL.Open();

                DataSet ds = new DataSet();
                string query = "select * from accion";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if(ds.Tables.Count >= 1)
                {
                    Resultado = JsonConvert.SerializeObject(ds.Tables[0]);
                }
                return Resultado;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
