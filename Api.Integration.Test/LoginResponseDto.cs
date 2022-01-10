﻿using Newtonsoft.Json;
using System;

namespace Api.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("authenticated")]
        public bool authenticated { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("expirationDate")]
        public DateTime expirationDate { get; set; }

        [JsonProperty("acessToken")]
        public string acessToken { get; set; }

        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
