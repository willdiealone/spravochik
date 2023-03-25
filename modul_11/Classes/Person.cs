namespace modul_11.Classes;

public class Person
{
    
    #region Propeties

    /// <summary>
    /// Свойтсво айди
    /// </summary>
    private short Id { get; set; }
    
    /// <summary>
    /// Свойство имя
    /// </summary>
    private string Name { get; set; }
    
    /// <summary>
    /// Свойство фамилия
    /// </summary>
    private string LastName { get; set; }
    
    /// <summary>
    /// Свойство отчество
    /// </summary>
    private string Surname { get; set; }
    
    /// <summary>
    /// Свойство номера телефона
    /// </summary>
    private short NumberPhone { get;set; }
    
    /// <summary>
    /// Свойство серии и номера паспорта
    /// </summary>
    private string SeriesAndNumberPassport { get; set; }
    
    #endregion
    
    #region Constructor

     /// <summary>
     /// Конструктор класа Person
     /// </summary>
     /// <param name="name"></param>
     /// <param name="lastName"></param>
     /// <param name="surname"></param>
     /// <param name="numberPhone"></param>
     /// <param name="seriesAndNumberPassport"></param>
    public Person(string name,string lastName,string surname,short numberPhone, string seriesAndNumberPassport)
    {
        Name = name;
        LastName = lastName;
        Surname = surname;
        NumberPhone = numberPhone;
        SeriesAndNumberPassport = seriesAndNumberPassport;
    }
    
    #endregion
}