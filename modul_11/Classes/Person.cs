namespace modul_11.Classes;

public class Person
{
    
    #region Propeties

    /// <summary>
    /// Айди
    /// </summary>
    public short Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string Surname { get; set; }
    
    /// <summary>
    /// Номера телефона
    /// </summary>
    public string NumberPhone { get; set; }
    
    /// <summary>
    /// Серия и номера паспорта
    /// </summary>
    public string SeriesAndNumberPassport { get; set; }
    
    /// <summary>
    /// Дата и время изменений
    /// </summary>
    public DateTime DateAndTimeChanged { get; set; }
    
    /// <summary>
    /// Какие дынные изменены
    /// </summary>
    public string WhatDataChanged { get; set; }
    
    /// <summary>
    /// Kто изменил данные
    /// </summary>
    public string WhoDataChed { get; set; }
    
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
    public Person(short id = 0,string name = null,string lastName = null,string surname = null,string numberPhone = null, 
         string seriesAndNumberPassport = null,DateTime dateAndTimeChanged = default,string whatDataChanged = null,
         string whoDataChed = null) 
     { 
         Id = id;
         Name = name;
         LastName = lastName;
         Surname = surname;
         NumberPhone = numberPhone;
         SeriesAndNumberPassport = seriesAndNumberPassport;
         DateAndTimeChanged = dateAndTimeChanged;
         WhatDataChanged = whatDataChanged;
         WhoDataChed = whoDataChed;
     }

     public Person() {}
     
     #endregion
}