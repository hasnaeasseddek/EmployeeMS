﻿namespace IntegrateKeycloak.API.Services
{
    public class CredentialDto
    {
        public string Type { get; set; } = "password";
        public string Value { get; set; } = string.Empty;
        public bool Temporary { get; set; } = false;
    }

}
