using System.IO;
using Fxcm.Api.Client.Rest;
using Newtonsoft.Json;

namespace Fxcm.Api.Client.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalSettings = JsonConvert.DeserializeObject<PersonalSettings>(File.ReadAllText("personalSettings.json"));
            IRestApiClient client = new FxcmRestApiClient(personalSettings.Environment, personalSettings.Token);
        }
    }
}
