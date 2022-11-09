using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Localization;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ApprovisionnmentTestDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        public MessageBienvenue Get()
        {
            var message = new MessageBienvenue();
            message.message = "Bienvenu sur fleuron industrie";
            return message;

        }
            
    }
}

