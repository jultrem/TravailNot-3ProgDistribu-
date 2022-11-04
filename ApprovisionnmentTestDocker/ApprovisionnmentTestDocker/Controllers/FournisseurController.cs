﻿using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApprovisionnmentTestDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class fournisseurController : ControllerBase
    {

        private readonly MySqlConnection _connection;

        public fournisseurController()
        {
            _connection = new MySqlConnection("server=localhost;user id=root;password=toor;database=fleuron");
            _connection.Open();
        }


        [HttpGet(Name = "GetFournisseurs")]
        public IEnumerable<Fournisseurs> Get([FromQuery(Name = "id")] int id)
        {
            var retour = Enumerable.Empty<Fournisseurs>();

            if (HttpContext.Request.Query.TryGetValue("id", out var queryVal))
            {
                int idQuery = Int32.Parse(queryVal);
                var req = _connection.CreateCommand();
                req.CommandText = "SELECT f.FournisseurID, f.Nom FROM fournisseurs as f INNER JOIN fournisseurs_sites as fs ON f.FournisseurID = fs.FournisseurID WHERE fs.SiteID = @id";
                req.Parameters.AddWithValue("id", idQuery);
                var reader = req.ExecuteReader();
                var liste = new List<Fournisseurs>();
                while (reader.Read())
                {
                    var f = new Fournisseurs
                    {
                        id = reader.GetInt32("FournisseurID"),
                        fournisseurs = reader.GetString("Nom")
                    };
                    liste.Add(f);
                }
                retour = liste;
            }
            else
            {
                var req = _connection.CreateCommand();
                req.CommandText = "SELECT FournisseurID, Nom FROM fournisseurs";
                var reader = req.ExecuteReader();
                var liste = new List<Fournisseurs>();
                while (reader.Read())
                {
                    var f = new Fournisseurs
                    {
                        id = reader.GetInt32("FournisseurID"),
                        fournisseurs = reader.GetString("Nom")
                    };
                    liste.Add(f);
                }
                retour = liste;
            }
            return retour;
        }
    }
}