namespace modul_11.Classes;
public abstract class Human
{
    protected List<Person> _persons = new();
    protected bool isValidInput = true;
    public delegate List<Person> DeserializeDelegate();
    public event DeserializeDelegate DeserializeEvent;
    private Manager _manager;
    private Consultant _consultant;

    public virtual void GetAllContact()
    {
       _persons = DeserializeEvent?.Invoke();
    }
    
    
    protected abstract void WriteToConsole(Person item);

}