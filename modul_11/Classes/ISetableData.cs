namespace modul_11.Classes;

public interface ISetableData
{
    /// <summary>
    /// метод добавляет человека в список
    /// </summary>
    public void AddNewPerson();

    /// <summary>
    /// метод изменяет данные по айди
    /// </summary>
    public void ChangePersonById();
}