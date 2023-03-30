using Newtonsoft.Json;

namespace modul_11.Classes;

public static class WorkableWithFile 
{
    #region PrivateConst
    
    private const string pathDir = "/Users/lilrockstar/Desktop/MyDir";
    private const string fileName = "data.json";

    #endregion

    #region PublicStaticMethods

    /// <summary>
    /// Метод сериализации
    /// </summary>
    /// <param name="_persons"></param>
    public static void SeriaizationToJson(List<Person> _persons)
    {
        if (_persons is null)
        {
            return;
        }
        string path = Path.Combine(pathDir, fileName);
        _persons = _persons.OrderBy(p => p.Id).ToList();
        string json = JsonConvert.SerializeObject(_persons,Formatting.Indented);
        File.WriteAllText(path,json);
    }

    /// <summary>
    /// Метод десериализации
    /// </summary>
    /// <returns></returns>
    public static List<Person> DeseriaizationToJson()
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
        List<Person> _persons = new List<Person>();
        string json = File.ReadAllText(path);
        if (!string.IsNullOrEmpty(json))
        {
            _persons = JsonConvert.DeserializeObject<List<Person>>(json);
            _persons = _persons.OrderBy(a => a.Id).ToList();
        }
        return _persons;
    }
    
    #endregion
}