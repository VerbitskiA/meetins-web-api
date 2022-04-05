using System;

namespace Meetins.Frontend.Model
{
    public class SecurityToken
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
