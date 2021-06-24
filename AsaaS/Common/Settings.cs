using System.ComponentModel.Design;

namespace AsaaS.Common
{
    public class Settings
    {
        public string AccessToken { get; set; }
        public bool Sandbox { get; set; }
        public string Url => Sandbox ? Urls.SandboxApiUrl : Urls.ApiUrl;
    }
}