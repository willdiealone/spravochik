using static modul_11.Classes.WorkableWithFile;
using static System.Console;
namespace modul_11.Classes;

public class Manager : Consultant, ISetableData
{
    #region Methods

    /// <summary>
    /// Метод создает и добавляет нового человека в список
    /// </summary>
    public void AddNewPerson()
    {
        string name = default;
        while (isValidInput)
        {
            Write("\nВведите Имя >>> ");
            name = ReadLine();
            if (!string.IsNullOrWhiteSpace(name) && name != "0") isValidInput = false;
            else WriteLine("\nИмя введено не корректно, попробуйте сначала");
        }
        isValidInput = true;
        string lastName = default;
        while (isValidInput)
        {
            Write("\nВведите Фамилию >>> ");
            lastName = ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName) && lastName != "0") isValidInput = false;
            else WriteLine("\nФамилия введена не корректно, попробуйте сначала");
        }
        isValidInput = true;
        string surname = default;
        while (isValidInput)
        {
            Write("\nВведите Отчество >>> ");
            surname = ReadLine();
            if (!string.IsNullOrWhiteSpace(surname) && surname != "0") isValidInput = false;
            else WriteLine("\nОтчество введено не корректно, попробуйте сначала");
        }
        isValidInput = true;
        string numberPhone = default;
        while (isValidInput)
        {
            Write("\nВведите номер телефона >>> ");
            numberPhone = ReadLine();
            char[] array = numberPhone.ToArray();
            bool checkNumber = short.TryParse(numberPhone, out short result);
            if (checkNumber)
            {
                if (array.Count() is not 11) WriteLine("\nНомер телефона состоит из 11 цифр, попробуйте снова");
            }
            else isValidInput = false;
        }
        isValidInput = true;
        string seriesAndNumberPassport = default;
        while (isValidInput)
        {
            Write("\nВведите номер и серию пасспорта (Формат ввода: 1234|123456) >>> ");
            seriesAndNumberPassport = ReadLine();
            char[] array = seriesAndNumberPassport.ToArray();
            if (array.Count() is 11)
            {
                if (array[4] is '|')
                {
                    isValidInput = false;
                }
            }
            else WriteLine("Серия и номер пасспорта введены не корректно, попробуйте снова");
        }
        DateTime dateAndTimeChanged = DateTime.Now;
        string whatDataChanged = "Создание пользователя";
        string whoDataChed = "Менеджер";
        short id = 1;
        if (_persons != null)
        {
            id = Convert.ToInt16(_persons.Count + 1);
        }
        Person person = new Person(id,name, 
            lastName,
            surname,
            numberPhone,
            seriesAndNumberPassport,
            dateAndTimeChanged,
            whatDataChanged,
            whoDataChed);
        WriteLine("\nСоздан новый пользователь:\n");
        WriteToConsole(person);
        Write("\nНажмите 1 если хотите сохранить пользователя >>> ");
        string userInput = ReadLine();
        if (userInput is "1")
        {
            _persons.Add(person);
            _persons.OrderBy(p => p.Id).ToList();
            SeriaizationToXml(_persons);
        }
        WriteLine("\nПользователь добавлен в список!");

    }
    
    /// <summary>
    /// Метод выводит данные в консоль
    /// </summary>
    /// <param name="item"></param>
    protected override void WriteToConsole(Person item)
    {
        WriteLine("Айди: {0}\nИмя: {1}\nФамилия: {2}\nОтчество: {3}\nНомер телефона: {4}" +
                             "\nCеррия и номер паспорта: {5}" +
                             "\nДата изменений: {6}\nТип изменений: {7}\nКто внес изменения: {8}",
            item.Id,
            item.Name,
            item.LastName,
            item.Surname,
            item.NumberPhone,
            item.SeriesAndNumberPassport,
            item.DateAndTimeChanged,
            item.WhatDataChanged,
            item.WhoDataChed);
    }
    #endregion
}