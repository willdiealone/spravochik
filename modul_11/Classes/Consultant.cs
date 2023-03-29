using static System.Console;
using static modul_11.Classes.WorkableWithFile;

namespace modul_11.Classes;

public class Consultant : Human
{
    #region Construct
    public Consultant()
    {
        DeserializeEvent += DeseriaizationToJson;
    }

    #endregion

    #region PublicOverrideMethods
    
    public override void GetAllContact()
    {
        base.GetAllContact();
        
        if (_persons.Count() == 0)
        {
            WriteLine("Нет контактов");
        }
        if (_persons.Count() != null)
        {
            int count = _persons.Count();
            WriteLine($"На данный момент пользователей в списке: {count}\n");
        }
        else
        {
            foreach (var item in _persons)
            {
                WriteToConsole(item);
            }
        }
    }
    
    #endregion

    #region ProtectedOverrideMethods
    
    protected override void WriteToConsole(Person item)
    {
        WriteLine("Айди: {0}\nИмя: {1}\nФамилия: {2}\nОтчество: {3}\nНомер телефона: {4}\nCеррия и номер паспорта: {5}\n",
            item.Id,
            item.Name,
            item.LastName,
            item.Surname,
            "************",
            item.SeriesAndNumberPassport);
    }

    #endregion
}