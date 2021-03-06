using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace mongoDIO.Data.Collections
{
    public class Infectados
    {
        public Infectados(DateTime dataNascimento, string sexo, double latitude, double longitude) 
        {
            this.DataNascimento = dataNascimento;
            
            this.Sexo = sexo;

            this.Localizacao = new GeoJson2DGeographicCoordinates (longitude, latitude);
        }

        public DateTime DataNascimento {get; set;}
        
        public string Sexo {get; set;}

        public GeoJson2DGeographicCoordinates Localizacao {get; set;}
    }
}