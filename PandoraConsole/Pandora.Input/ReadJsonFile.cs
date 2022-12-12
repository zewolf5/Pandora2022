using Newtonsoft.Json;
using Pandora.Input.Model;

namespace Pandora.Input
{
    public class ReadJsonFile
    {
        public void ReadAllData()
        {
           
            var jsonText = File.ReadAllText("C:\\Users\\ab12229\\Source\\Repos\\Pandora2022-1\\PandoraConsole\\Pandora.Input\\Resorces\\nøkkelinfo_200.json");
            var sponsors = JsonConvert.DeserializeObject<Fildata>(jsonText);
        }
    }
        
}