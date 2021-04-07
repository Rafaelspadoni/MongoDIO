using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using mongoDIO.Data.Collections;
using MongoDIO.Model;



namespace MongoDIO.Controllers
{
    public class InfectadosController
    {
        [ApiController]
        [Route("[controller]")]

        public class infectadosController : ControllerBase
        {
            Data.MongoDB _MongoDB;

            IMongoCollection<Infectados> _infectadosCollection;

            public infectadosController(Data.MongoDB mongoDB)
            {
                _MongoDB = mongoDB;
                _infectadosCollection = _MongoDB.DB.GetCollection<Infectados>(typeof(Infectados).Name.ToLower());

            }

            [HttpPost]
            public ActionResult SalvarInfectado([FromBody] InfectadosDto dto) 
            {
                var Infectados = new Infectados(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.longitude);

                _infectadosCollection.InsertOne(Infectados);

                return StatusCode(201, "Infectado adicionado com sucesso");

            }

            [HttpGet]
            
            public ActionResult ObterInfectados()
            {
                var Infectados = _infectadosCollection.Find(Builders<Infectados>.Filter.Empty).ToList();

                return Ok(Infectados);
            }
        }
    }
}