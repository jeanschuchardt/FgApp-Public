using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FGApp.API
{
    [Route("api/[controller]")]
    public class CargosController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public CargosController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{ano}")]
        public JsonResult Get(int ano)
        {
            List<int> listaAnos = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            List<RegioesCargos> listaPartidoServidores = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new RegioesCargos() { DataCargos = new DateTime(ano, 1, 1) });

            return Json(listaPartidoServidores.Select(x => new { x.Partido, x.TotalCargos }).ToArray());
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
