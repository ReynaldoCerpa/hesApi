using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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
        // GET api/value
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
        [HttpGet("userID/{id}")]
        public ActionResult<string> Get(int id)
        {
            string Resultado = "";
            try
            {
                SqlConnection conSQL = new SqlConnection("Data source=LAPTOP-REY" + ";Initial Catalog=hutchinson" + ";User ID=root" + ";Password=pass" + ";");
                conSQL.Open();

                DataSet ds = new DataSet();
                string query = "select * from accion where idReporte = "+id;
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
                SqlConnection conSQL = new SqlConnection("Data source=LAPTOP-REY" + ";Initial Catalog=hutchinson" + ";User ID=root" + ";Password=pass" + ";");
                conSQL.Open();

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
                SqlConnection conSQL = new SqlConnection("Data source=LAPTOP-REY" + ";Initial Catalog=hutchinson" + ";User ID=root" + ";Password=pass" + ";");
                conSQL.Open();

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
                SqlConnection conSQL = new SqlConnection("Data source=LAPTOP-REY" + ";Initial Catalog=hutchinson" + ";User ID=root" + ";Password=pass" + ";");
                conSQL.Open();

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



        


        // POST api/values
        [HttpPost("addMejora/")]
        public void AddAccion(Accion accion)
        {
            try
            {
                //"2021-09-07"
                SqlConnection conSQL = new SqlConnection("Data source=LAPTOP-REY" + ";Initial Catalog=hutchinson" + ";User ID=root" + ";Password=pass" + ";");
                SqlCommand cmd = new SqlCommand("insert into accion values (@idReporte, @idEmpleado, @fechaLimite, @fechaRealizado, null, @descripcion)", conSQL);
                cmd.Parameters.Add(new SqlParameter("@idReporte", accion.idReporte));
                cmd.Parameters.Add(new SqlParameter("@idEmpleado",accion.idEmpleado));
                cmd.Parameters.Add(new SqlParameter("@fechaLimite", accion.fechaLimite));
                cmd.Parameters.Add(new SqlParameter("@fechaRealizado", accion.fechaRealizado));
                cmd.Parameters.Add(new SqlParameter("@descripcion", accion.descripcion));
                conSQL.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conSQL.Close();

                Console.WriteLine("----------------------------\n Rows added: "+rowsAffected+ "\n----------------------------");

            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! something went wrong... \n" + e);
            }
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
