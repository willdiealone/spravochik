namespace modul_11.Classes;
public abstract class Human
{
    protected List<Person> _persons = new();
    public Person person = new();
    protected bool isValidInput = true;
    protected bool check = true;

    public abstract void GetAllContact();
    
    protected abstract void WriteToConsole(Person item);

}