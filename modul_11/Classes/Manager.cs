using static System.Console;
using static System.DateTime;
namespace modul_11.Classes;
using static WorkableWithFile;

public class Manager : Human, ISetableData
{
    #region PublicDelegate
    
    public delegate void SerializeDelegate(List<Person> _persons);
    public event DeserializeDelegate DeserializeEvent;

    #endregion
    
    #region PublicEvent
    public event SerializeDelegate SerializeEvent;
    public delegate List<Person> DeserializeDelegate();

    #endregion

    #region PublicConstructor

    public Manager()
    {
        DeserializeEvent += DeseriaizationToJson;
        SerializeEvent += SeriaizationToJson;
        _persons = DeserializeEvent?.Invoke();
    }

    #endregion

    #region PublicOverrideMethods

    /// <summary>
    /// переопределенный мтод выводит всех пользователей на экран
    /// </summary>
    public override void GetAllContact()
    {
        if (_persons.Count >= 1)
        {
            WriteLine($"На данный момент пользователей в списке: {_persons.Count}\n");

            foreach (var item in _persons)
            {
                WriteToConsole(item);
            }
        }
        if (_persons.Count < 1)
        {
            WriteLine($"На данный момент пользователей в списке: {_persons.Count}\n");
        }
    }

    #endregion

    #region ProtectedOverrideMethods

    /// <summary>
    /// переопределенный метод который выводит пользователя в определенном формате
    /// </summary>
    /// <param name="item"></param>
    protected override void WriteToConsole(Person item)
    {
        WriteLine("Айди: {0}\nИмя: {1}\nФамилия: {2}\nОтчество: {3}\nНомер телефона: {4}" +
                  "\nCеррия и номер паспорта: {5}" +
                  "\nДата изменений: {6}\nТип изменений: {7}\nКто внес изменения: {8}\n",
            item.Id,
            item.Name,
            item.LastName,
            item.Surname,
            item.NumberPhone,
            item.SeriesAndNumberPassport,
            item.DateAndTimeChanged,
            item.WhatDataChanged,
            item.WhoDataChenged);
    }
    
    #endregion
    
    #region PublicMethods

    /// <summary>
    /// Метод создает и добавляет нового человека в список
    /// </summary>
    public void AddNewPerson()
    {
        while (check)
        { 
            string name = default;
            isValidInput = true;
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
                if (numberPhone.Length == 11 && numberPhone.All(char.IsDigit))
                {
                    isValidInput = false;
                }
                else 
                {
                    WriteLine("\nНомер телефона состоит из 11 цифр, попробуйте снова");
                }
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
            
            // проверка на индивидуальность пользователя
            if (_persons.Any(p => p.Equals(person)))
            {
                WriteLine("\nТакой пользователь уже существует, введите другие данные");
                AddNewPerson();
                return;
            }
            _persons.Add(person); 
            _persons.OrderBy(p => p.Id).ToList(); 
            SerializeEvent?.Invoke(_persons);
            WriteLine("\nПользователь добавлен в список!");
            isValidInput = true;
            if (isValidInput)
            {
                Write("\nЕсли хотите добавить еще одного пользователя нажмите 1, для выхода нажмите 0 >>> ");
                string inputForChange = ReadLine();
                if (inputForChange == "1")
                {
                    AddNewPerson();
                }

                if (inputForChange == "0")
                {
                    isValidInput = false;
                    check = false;
                }
            }
        }
    }
    
    /// <summary>
    /// метод возвращает пользователя по айди
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Person ReturnPersonById(short id)
    {
        Person person = _persons.Where(p => p.Id == id).FirstOrDefault();
        return person;
    }

    /// <summary>
    /// Метод изменения пользователя по айди
    /// </summary>
    public void ChangeDataPersonById()
    {
        if (_persons.Count < 1)
        {
            Write("\nНет контактов, если хотите их добавить нажмите 1, для выхода нажмите 0 >>> ");
            string inputForChange = ReadLine();
            if (inputForChange == "1")
            {
                AddNewPerson();
            }
            if (inputForChange == "0")
            {
                return;
            }
        }
        else
        {
            while (isValidInput) 
            { 
                Write("\nВведите ади того чьи данные хотите изменить >>> "); 
                string idInput = ReadLine(); 
                if (short.TryParse(idInput, out short result)) 
                { 
                    Person person = ReturnPersonById(result); 
                    if (person == null) 
                    { 
                        WriteLine("\nТакого пользователь нет, попробуйте еще раз"); 
                        return; 
                    } 
                    if(person != null) 
                    { 
                        WriteLine($"\nНайден пользователь по вами введенному айди - {idInput}:\n"); 
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
                        string newSurname; 
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
                                    person.WhoDataChenged = "Менеджер"; 
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
                                    person.WhoDataChenged = "Менеджер"; 
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
                                    person.WhoDataChenged = "Менеджер"; 
                                    Clear(); 
                                    WriteLine($"\nИзменено отчество у пользователя с айди - {idInput}\n"); 
                                    WriteToConsole(person); 
                                }
                                else WriteLine("\nНовое отчество введено некорректно, попробуйте снова"); 
                                break; 
                            case "4": 
                                Write("\nВведите новый номер телефона >>> "); 
                                newNumberPhone = ReadLine(); 
                                if (newNumberPhone.Length == 11 && newNumberPhone.All(char.IsDigit)) 
                                { 
                                    if (newNumberPhone.Length != 11 | !newNumberPhone.All(char.IsDigit)) 
                                    { 
                                        WriteLine("\nНомер телефона состоит из 11 цифр, попробуйте снова"); 
                                    } 
                                    person.NumberPhone = newNumberPhone; 
                                    person.DateAndTimeChanged = Now.ToShortTimeString();; 
                                    person.WhatDataChanged = "Изменение номера телефона"; 
                                    person.WhoDataChenged = "Менеджер"; 
                                    Clear(); 
                                    WriteLine($"\nИзменен номер телефона у пользователя с айди - {idInput}\n"); 
                                    WriteToConsole(person); 
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
                                        person.WhoDataChenged = "Менеджер"; 
                                    } 
                                }
                                else WriteLine("\nНовые серрия и номе рпасспорта введены не корректно, попробуйте снова"); 
                                break; 
                            case "0": 
                                isValidInput = false; 
                                break; 
                            default: 
                                WriteLine("\nТакого номера нет в списке, попробйте снова"); 
                                break; 
                        } 
                    } 
                    SerializeEvent.Invoke(_persons); 
                }
                else 
                { 
                    WriteLine("\nНекорректно введен айди пользвателя, попробуйте сначала"); 
                    return; 
                } 
            }
        }
    }

    /// <summary>
    /// Метод сортирует пользователей по имени
    /// </summary>
    public void SrotForName()
    {
        if (_persons != null)
        {
            _persons = _persons.OrderBy(p => p.Name).ToList();
            foreach (var item in _persons)
            {
                WriteToConsole(item);
            }
        }
    }

    #endregion

}