using static System.Console;

namespace modul_11.Classes;

public class Consultant
{
    protected List<Person> _persons;
    protected readonly string PathDir = "/Users/lilrockstar/Desktop/MyDir";
    protected readonly string FineName = "data.xml";
    protected bool flag = true;


    protected virtual void WriteToConsole(Person item)
    {
        WriteLine("Имя {0}\nФамилия {1}\nОтчество {2}\nНомер телефона {3}\nCеррия и номер паспорта {4}",
            item.Name,
            item.LastName,
            item.Surname,
            "************",
            item.SeriesAndNumberPassport);
    }
}