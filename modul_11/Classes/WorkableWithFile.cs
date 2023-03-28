using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace modul_11.Classes;

public  class WorkableWithFile 
{
    private const string pathDir = "/Users/lilrockstar/Desktop/MyDir";
    private const string fileName = "data.json";
    protected List<Person> _persons = new();
    protected bool isValidInput = true;


    public  WorkableWithFile()
    {
        List<Person> allPersons = DeseriaizationToJson();
        
        if (allPersons != null)
        {
            _persons = allPersons;
            Console.WriteLine(" => Ctor WorkableWithFile");
        }
    }
    public void SeriaizationToJson(List<Person> person)
    {
        if (_persons is null)
        {
            return;
        }
        string path = Path.Combine(pathDir, fileName);
        _persons = person.OrderBy(p => p.Id).ToList();
        string json = JsonConvert.SerializeObject(_persons,Formatting.Indented);
        File.WriteAllText(path,json);
        
    }

    public List<Person> DeseriaizationToJson()
    {
        string path = Path.Combine(pathDir, fileName);
        if (!Directory.Exists(pathDir))
        {
            Directory.CreateDirectory(pathDir);
        }
        bool checkFile = File.Exists(path);
        if (!checkFile)
        {
            File.Create(path).Close();
        }
        string json = File.ReadAllText(path);
        var _people = JsonConvert.DeserializeObject<List<Person>>(json);
        if (_people is not null)
        {
            _people = _people.OrderBy(a => a.Id).ToList();
        }
        return _people;
    }
    
}