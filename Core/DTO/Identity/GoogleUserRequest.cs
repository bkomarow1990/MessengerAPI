﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.DTO.Identity
{
    public class GoogleUserRequest
    {
        public const string PROVIDER = "google";
        [JsonProperty("idToken")]
        [Required]
        public string IdToken { get; set; }
    }
}
