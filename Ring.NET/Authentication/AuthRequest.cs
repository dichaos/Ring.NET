﻿using Newtonsoft.Json;

namespace RingIntegration.Authentication
{
    public class AuthRequest
    {
        public readonly string client_id = "ring_official_android";
        public readonly string grant_type = "password";
        public readonly string password;
        public readonly string scope = "client";
        public readonly string username;

        public AuthRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static string GetRequest(string username, string password)
        {
            return new AuthRequest(username, password).ToString();
        }
    }
}