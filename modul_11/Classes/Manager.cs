using static System.Console;
using static System.DateTime;
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
            bool checkNumber = short.TryParse(numberPhone, out short result);
            if (checkNumber)
            {
                if (numberPhone.Length != 11) WriteLine("\nНомер телефона состоит из 11 цифр, попробуйте снова");
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
        string dateAndTimeChanged = Now.ToShortTimeString();
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
        _persons.Add(person); 
        _persons.OrderBy(p => p.Id).ToList(); 
        SeriaizationToJson(_persons);
        WriteLine("\nПользователь добавлен в список!");

    }

    /// <summary>
    /// Метод выводит всех сохраненных людей
    /// </summary>
    public void GetAllContact()
    {
        _persons = DeseriaizationToJson();
        
        if (_persons.Count() == 0)
        {
            WriteLine("Нет контактов");
        }
        else
        {
            foreach (var item in _persons)
            {
                WriteToConsole(item);
            }
        }
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
        
    /// <summary>
    /// метод возвращает человека по айди
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Person ReturnPersonById(short id)
    {
        Person person = _persons.Where(p => p.Id == id).FirstOrDefault();
        return person;
    }

    public void ChangePersonById()
    {
        if (_persons == null)
        {
            WriteLine("\nНет контактов");
        }

        while (isValidInput)
        {
            Write("\nВведите ади того чьи данные хотите изменить >>> ");
            string idInput = ReadLine();
            if (short.TryParse(idInput, out short result))
            {
                var person = ReturnPersonById(result);
                if (person == null)
                {
                    WriteLine("\nТакого контакто нет, попробуйте еще раз");
                    return;
                }
                if(person != null)
                {
                    WriteLine($"\nНайден контакт по вами введенному айди - {idInput}:\n");
                    WriteToConsole(person);
                }
                while (isValidInput)
                {
                  Write("\nВведите номер поля которое хотите изменить:\nName - 1 || LastName - 2 ||" +
                            "Surname - 3 || Number Phone - 4 || Series and Number Passport - 5 ||" +
                            " Чтобы выйте нажмите - 0\n>>> ");
                  string input = ReadLine();
                  if (input == "0") isValidInput = false;
                  string newName;
                  string newLastName;
                  string newSurname ;
                  string newNumberPhone;
                  string newSeriesAndNumberPassport;
                  switch (input)
                  {
                      case "1":
                          Write("\nВведите новое имя >>> ");
                          newName = ReadLine();
                          if (!string.IsNullOrWhiteSpace(newName) && newName != "0")
                          {
                              person.Name = newName;
                              person.DateAndTimeChanged = Now.ToShortTimeString();
                              person.WhatDataChanged = "Изменение имени";
                              person.WhoDataChed = "Менеджер";
                              Clear();
                              WriteLine($"\nИзменено имя у пользователя с айди - {idInput}:\n");
                              WriteToConsole(person);
                          }
                          else WriteLine("\nНовое имя введено не корректно, попробуйте снова");
                          
                          break;
                      case "2": Write("\nВведите новую фамилию >>> ");
                          newLastName = ReadLine();
                          if (!string.IsNullOrWhiteSpace(newLastName) && newLastName != "0")
                          {
                              person.LastName = newLastName;
                              person.DateAndTimeChanged = Now.ToShortTimeString();;
                              person.WhatDataChanged = "Изменение фамилии";
                              person.WhoDataChed = "Менеджер";
                              Clear();
                              WriteLine($"\nИзменена фамилия у пользователя с айди - {idInput}\n");
                              WriteToConsole(person);
                          }
                          else WriteLine("\nНовая фамилия введена некорректно, попробуйте сначала");
                          break;
                      case "3": 
                          Write("Введите новое отчество >>> ");
                          newSurname = ReadLine();
                          if (!string.IsNullOrWhiteSpace(newSurname) && newSurname != "0")
                          {
                              person.Surname = newSurname;
                              person.DateAndTimeChanged = Now.ToShortTimeString();;
                              person.WhatDataChanged = "Изменение отчества";
                              person.WhoDataChed = "Менеджер";
                              Clear();
                              WriteLine($"\nИзменено отчество у пользователя с айди - {idInput}\n");
                              WriteToConsole(person);
                          }
                          else WriteLine("\nНовое отчество введено некорректно, попробуйте снова");
                          break;
                      case "4": 
                          Write("\nВведите новый номер телефона >>> ");
                          newNumberPhone = ReadLine();
                          bool checkResult = short.TryParse(newNumberPhone, out short checkNumber);
                          if (checkResult)
                          {
                              if (newNumberPhone.Length == 11)
                              {
                                  person.NumberPhone = newNumberPhone;
                                  person.DateAndTimeChanged = Now.ToShortTimeString();;
                                  person.WhatDataChanged = "Изменение номера телефона";
                                  person.WhoDataChed = "Менеджер";
                                  Clear();
                                  WriteLine($"Изменен номер телефона у пользователя с айди - {idInput}\n");
                                  WriteToConsole(person);
                              }
                              else WriteLine("\nНомер телефона состоит из 11 цифр, попробуйте снова");
                          }
                          break;
                      case "5": 
                          Write("\nВведите новые серию и номер пасспорта (Формат ввода: 1234|123456) >>> ");
                          newSeriesAndNumberPassport = ReadLine();
                          char[] array = newSeriesAndNumberPassport.ToArray();
                          if (array[4] == '|')
                          {
                              if (array.Count() == 11)
                              {
                                  person.SeriesAndNumberPassport = newSeriesAndNumberPassport;
                                  person.DateAndTimeChanged = Now.ToShortTimeString();;
                                  person.WhatDataChanged = "Изменение серии и номера паспорта";
                                  person.WhoDataChed = "Менеджер";
                              }
                          }
                          else WriteLine("\nНовые серрия и номе рпасспорта введены не корректно, попробуйте снова");
                          break;
                          default: 
                              WriteLine("\nТакого номера нет в списке, попробйте снова");
                              break;
                  }
                }
            }
            else
            {
                WriteLine("\nНекорректно введен айди пользвателя, попробуйте сначала");
                return;
            }
        }
    }
    
    #endregion
}