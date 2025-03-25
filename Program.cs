using System.Text.Json;
using System.Text.Json.Nodes;

namespace JSON;

public class Person{
    //luokkapohjainen tapa (? nullable valitus pois)
    //nimet tulee vastata JSON-tiedoston avaimia
    public string? nimi { get; set; }
    public int ika { get; set; }
    public bool elossa { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string fileNameAndPath = "./testi.json"; //jos kansion juuressa
        string readMessage = "onnistui";

        try{
            Console.WriteLine($"Yritän lukea: {fileNameAndPath}");
            
            //valmistellaan Person lista populoitavaksi
            //List<Person>? data = new List<Person>();
            JsonNode data;

            using ( StreamReader r = new StreamReader(fileNameAndPath) ){
                string json = r.ReadToEnd();
                //data = JsonSerializer.Deserialize<List<Person>>(json);
                data = JsonNode.Parse(json)!;
            }

            Console.WriteLine(data[0]);
            //tarkista tieto
            string response = "Jurkkia ei ole olemassa!"; 
            //if(data[0].elossa)
            if((bool)data![0]["elossa"])
                response = "Jurkki on olemassa";

            Console.WriteLine(response);
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
            readMessage = "epäonnistui";
        }
        finally{
            Console.WriteLine($"Tiedoston lukeminen: {readMessage}");
        }
    }
}
