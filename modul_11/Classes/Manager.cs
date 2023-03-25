using System.Diagnostics.SymbolStore;
using static System.Console;
namespace modul_11.Classes;

public class Manager : Consultant, IWorkableWithFile,ISetableData
{
    /// <summary>
    /// Конструтор Менаджера
    /// </summary>
    public Manager()
    {
       var _persons = new List<Person>();
    }

    /// <summary>
    /// Метод добавляет нового человека в список
    /// </summary>
    public void AddNewPerson()
    {
        Person person;
        string name;
        while (flag)
        {
            WriteLine("\nВведите Имя >>> ");
            name = ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                WriteLine("Поле 'Имя' нужно обязательно заполнить!");
                return;
            }
        }
        string lastname; 
        while (flag) 
        { 
            WriteLine("\nВведите Фамилию >>>"); 
            lastname = ReadLine(); 
            if (string.IsNullOrEmpty(lastname)) 
            { 
                WriteLine("Поле 'Фамилия' нужно обязательно заполнить!"); 
                return;
            }
        }
        string surname; 
        while (flag)
        {
            WriteLine("\nВведите отчество >>>");
            surname = ReadLine();
            if (string.IsNullOrEmpty(surname))
            {
                WriteLine("Поле 'Отчество' нужно обязательно заполнить!");
            }
            
        }
        short numberPhone;
        while (flag)
        {
            WriteLine("\nВведите номер телефона >>>");
            string userInput = ReadLine();
            bool checkUserInput = short.TryParse(userInput, out short result);
            if (checkUserInput | userInput.Length == 11)
            {
                numberPhone = result;
                flag = false;
            }
            WriteLine("Номер телефона состоит из 11 цифр!");
            return;
        }
        string seriesAndNumberPassport;
        while (flag)
        {
            WriteLine("\nВведите серию и номер паспорта\nФормат ввода  1234|456789");
            string userInput = ReadLine();
            char[] chars = userInput.ToArray();
            if (chars[4] == '|' | chars.Length == 11 )
            {
                seriesAndNumberPassport = userInput;
                flag = false;
            }
            WriteLine("Некоректный ввод!");
            return;
        }    
        






        
    }
}