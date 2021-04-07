using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using mongoDIO.Data.Collections;

namespace MongoDIO.Data
{

    public class MongoDB
    {
        public IMongoDatabase DB { get; }

        public MongoDB(IConfiguration configuration) 
        {
             try 
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                Mapclasses();
            }
            catch (Exception ex) 
            {
                throw new MongoException("It not possible do conect to MongoDB", ex);
            }
        }

        private void Mapclasses()
        {
            var conventionPack = new ConventionPack {new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectados)))
            {
                BsonClassMap.RegisterClassMap<Infectados>(i => {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}