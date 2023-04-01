namespace modul_11.Classes;
public abstract class Human
{
    #region PublicFieds
    
    public Person person = new();

    #endregion

    #region ProtectedFields

    protected List<Person> _persons = new();
    protected bool isValidInput = true;
    protected bool check = true;

    #endregion

    #region PublicAbstractMethods
    
    /// <summary>
    /// метод выводит всех пользователей на экране
    /// </summary>
    public abstract void GetAllContact();
    
    #endregion

    #region ProtectedAbstractMethods

    /// <summary>
    /// Метод выводит поьзователя в заданном формате
    /// </summary>
    /// <param name="item"></param>
    protected abstract void WriteToConsole(Person item);

    #endregion

}