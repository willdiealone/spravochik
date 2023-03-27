using System.Xml.Linq;
using System.Xml.Serialization;
namespace modul_11.Classes;

public  class WorkableWithFile 
{
    private static readonly string PathDir = "/Users/lilrockstar/Desktop/MyDir";
    private static readonly string FileName = "data.xml";
    protected List<Person> _persons = new();
    protected bool isValidInput = true;


    public  WorkableWithFile()
    {
        List<Person> allPersons = DeseriaizationToXml();
        
        if (_persons is null)
        {
            _persons = allPersons;
        }
    }
    public void SeriaizationToXml(List<Person> person)
    {
        if (_persons is null)
        {
            return;
        }
        string path = Path.Combine(PathDir + FileName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
        Stream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
        var _person = person.OrderBy(p => p.Id).ToList();
        xmlSerializer.Serialize(fs,_person);
        fs.Close();
    }

    public List<Person> DeseriaizationToXml()
    {
        List<Person> readPerson = new List<Person>();
        if (!Directory.Exists(PathDir))
        {
            Directory.CreateDirectory(PathDir);
        }
        string path = Path.Combine(PathDir, FileName);
        if (File.Exists(path))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                readPerson = xmlSerializer.Deserialize(stream) as List<Person>;
            }
        }
        return readPerson;
    }

}