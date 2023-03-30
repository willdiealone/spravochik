using static System.Console;
using static modul_11.Classes.WorkableWithFile;
using static System.DateTime;

namespace modul_11.Classes;

public class Consultant : Human
{
    #region Delegate
    
    public delegate void SerializeDelegate(List<Person> _persons);
    public event DeserializeDelegate DeserializeEvent;

    #endregion
    
    #region event
    public event SerializeDelegate SerializeEvent;
    public delegate List<Person> DeserializeDelegate();

    #endregion
    
    #region Construct
    public Consultant()
    {
        DeserializeEvent += DeseriaizationToJson;
        SerializeEvent += SeriaizationToJson;
        GetAllContact();
    }

    #endregion

    #region PublicOverrideMethods
    
    public override void GetAllContact()
    {
        _persons = DeserializeEvent?.Invoke();
        
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
            item.NumberPhone,
            "************");
    }

    #endregion

    #region PublicMethods

    public void ChangeNumberPersonById()
    {
        if (_persons != null)
        {
            Write("\nВведите айди пользователя чей номер хотите изменить >>> ");
            int input = int.Parse(ReadLine());
            Person person = RerturnPersonById(input);
            if (person != null)
            {
                WriteLine($"\nНайден пользователь по вами введенному айди - {input}:\n");
                WriteToConsole(person);
                while (isValidInput)
                {
                    Write("\nВведите новый номер телефона >>> ");
                    string newNumberInput = ReadLine();
                    if (newNumberInput.Length == 11 && newNumberInput.All(char.IsDigit))
                    {
                        person.NumberPhone = newNumberInput;
                        person.WhatDataChanged = Now.ToShortTimeString();
                        person.WhatDataChanged = "Номер телефона";
                        person.WhoDataChenged = "Консультант";
                        if (_persons != null)
                        {
                            SerializeEvent?.Invoke(_persons);
                            WriteLine("\nИзменения сохранены!");
                            isValidInput = false;
                        }
                    }
                    else
                    {
                        WriteLine("\nНомер телефна состоит из 11 цифр, попробуйте снова");
                    }
                }
                
            }
        }
    }
    
    /// <summary>
    /// метод возвращает пользователя по айди
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public Person RerturnPersonById(int input)
    {
        person = _persons.Where(p => p.Id == input).FirstOrDefault();
        return person;
    }

    #endregion
}