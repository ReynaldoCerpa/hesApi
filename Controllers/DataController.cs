using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http.Cors;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace apiHes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public SqlConnection connectDB()
        {
            SqlConnection conSQL = connectDB();
        }

        // GET api/value
        [HttpGet]
        public IActionResult Get()
        {

            return Ok("Connected to apii");

        }

        [HttpGet]
        [Route("userID/{id}")]
        public ActionResult<string> Get(int id)
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select * from accion where idReporte = " + id;
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("getUsers/")]
        public ActionResult<string> GetUsers()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select * from empleado";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("tipoMejora/{id}")]
        public ActionResult<string> GetMejora(int id)
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select * from tipoMejora where idTipoMejora = " + id;
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("tiposMejora/")]
        public ActionResult<string> GetMejora()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select * from tipoMejora";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpPost("addMejora/")]
        [Produces("application/json")]
        public bool addMejora([FromBody] dynamic data)
        {
            string values = data.body;
            var datos = (JObject)JsonConvert.DeserializeObject(values);

            try
            {

                //"2021-09-07"
                SqlConnection conSQL = connectDB();
                SqlCommand cmd = new SqlCommand("insert into accion values (@idReporte, @idEmpleado, @fechaLimite, @fechaRealizado, null, @descripcion)", conSQL);
                cmd.Parameters.Add(new SqlParameter("@idReporte", datos["idReporte"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@idEmpleado", datos["idEmpleado"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@fechaLimite", datos["fechaLimite"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@fechaRealizado", datos["fechaRealizado"].ToString()));
                cmd.Parameters.Add(new SqlParameter("@descripcion", datos["descripcion"].ToString()));
                conSQL.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conSQL.Close();

                Console.WriteLine("----------------------------\n Rows added: " + rowsAffected + "\n----------------------------");

                return (rowsAffected > 0) ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine("----------------------------\n Oh no! something went wrong... \n\n" + e + "\n----------------------------");
                return false;
            }

        }

        [HttpGet("awards/topThree/")]
        public ActionResult<string> GetMejora()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select titulo as 'title', idPropositor as 'author', propuesta as 'description' from reporteidea r limit 3";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("awards/table/")]
        public ActionResult<string> GetMejora()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select idReporte as numProp, 'FOO' as nombre, 'FOO' as areaPropone, titulo from reporteidea";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("indicators/verti/")]
        public ActionResult<string> GetMejora()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select MONTH(fechaElaboracion) as 'mes', count(idReporte) from reporteidea group by mes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("indicators/hori/")]
        public ActionResult<string> GetMejora()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select idPropositor, count(idReporte) from reporteidea group by idPropositor;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("indicators/pie/")]
        public ActionResult<string> GetMejora()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select count(idReporte) as 'cuenta', 100 - count(idReporte) from reporteidea";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        [HttpGet("dashboard/")]
        public ActionResult<string> GetMejora()
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = connectDB();

                DataSet ds = new DataSet();
                string query = "select idReporte as 'numProp', MONTH(fechaElaboracion) as 'mes', fechaElaboracion as 'fecha', idReporte as 'areaPropone', titulo as 'titulo', idReporte as 'areaMejora', idReporte as 'tipoMejora', idReporte as 'gerente' from reporteidea";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conSQL);

                adapter.Fill(ds, "ConsultaDS");
                if (ds.Tables.Count >= 1)
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

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
