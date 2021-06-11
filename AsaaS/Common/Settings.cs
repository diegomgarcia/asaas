using System.ComponentModel.Design;

namespace AsaaS.Common
{
    public class Settings
    {
        public string AccessToken { get; set; }
        public bool Sandbox { get; set; }

        public string Url
        {
            get
            {
                if (Sandbox)
                  return Urls.SandboxApiUrl;
                
                return Urls.ApiUrl;
            }
        }
    }
}