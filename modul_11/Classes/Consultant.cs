using static System.Console;

namespace modul_11.Classes;

public class Consultant : WorkableWithFile
{
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