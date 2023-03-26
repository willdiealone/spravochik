using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using static System.Console;
namespace modul_11.Classes;

public class Manager : Consultant, IWorkableWithFile,ISetableData
{
    #region Methods

    /// <summary>
    /// Метод добавляет нового человека в список
    /// </summary>
    public void AddNewPerson()
    {
        string name = default;
        while (flag)
        {
            Write("\nВведите Имя >>> ");
            name = ReadLine();
            if (name is not null & name is not "0" & name is not "" ) flag = false;
            if (flag) WriteLine("\nИмя введено не корректно, попробуйте сначала");
        }
        flag = true;
        string lastName = default;
        while (flag)
        {
            Write("\nВведите Фамилию >>> ");
            lastName = ReadLine();
            if (lastName is not null & lastName is not "0" & lastName is not "" ) flag = false;
            if (flag) WriteLine("\nФамилия введена не корректно, попробуйте сначала");
        }
        flag = true;
        string surname = default;
        while (flag)
        {
            Write("\nВведите Отчество >>> ");
            surname = ReadLine();
            if (surname is not null & surname is not "0" & surname is not "" ) flag = false;
            if (flag) WriteLine("\nОтчество введено не корректно, попробуйте сначала");
        }
        flag = true;
        string numberPhone = default;
        while (flag)
        {
            Write("\nВведите номер телефона >>> ");
            numberPhone = ReadLine();
            char[] array = numberPhone.ToArray();
            bool checkNumber = short.TryParse(numberPhone, out short result);
            if (checkNumber)
            {
                if (array.Count() is not 11) WriteLine("\nНомер телефона состоит из 11 цифр, попробуйте снова");
            }
            if (array.Count() is 11) flag = false;
        }
        flag = true;
        string seriesAndNumberPassport = default;
        while (flag)
        {
            Write("\nВведите номер и серию пасспорта (Формат ввода: 1234|123456) >>> ");
            seriesAndNumberPassport = ReadLine();
            char[] array = seriesAndNumberPassport.ToArray();
            if (array.Count() is 11)
            {
                if (array[4] is '|')
                {
                    flag = false;
                }
            }
            if (array.Count() is not 11) WriteLine("Серия и номер пасспорта введены не корректно, попробуйте снова");
        }
        DateTime dateAndTimeChanged = DateTime.Now;
        string whatDataChanged = "Создание пользователя";
        string whoDataChed = "Менеджер";
        short id = default;
        if (_persons?.Count == null) id = 1;
        if (_persons?.Count != null) id = Convert.ToInt16(_persons.Count + 1);
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
        if (userInput is "1") _persons?.Add(person); 
        WriteLine("\nПользователь добавлен в список!");

    }
    
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