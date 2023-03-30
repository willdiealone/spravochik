namespace modul_11.Classes;

public interface ISetableData
{
    #region PublicMethods
    
    /// <summary>
    /// метод добавляет человека в список
    /// </summary>
    public void AddNewPerson();

    /// <summary>
    /// метод изменяет данные пользователя по айди
    /// </summary>
    public void ChangeDataPersonById();

    #endregion
}