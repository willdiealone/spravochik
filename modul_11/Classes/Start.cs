using static System.Console;
namespace modul_11.Classes;

public class Start
{
    #region PririvateFields
    
    private bool checkMenu = true;
    private string key;
    private string[] managerOrConsultant = { "1", "2" };
    private string consultantInput;
    private string checkPassword;

    #endregion

    #region PublicMethods
    
    /// <summary>
    /// консольное меню приложения. Пароль: skillbox
    /// </summary>
    public void MethodonStart()
    {
        while (checkMenu)
        {Write("\nЕсли вы менеджер нажмите  - 1\nЕсли вы консультант нажмите - 2\nДля выхода нажмите - 0\n>>> ");
            key = ReadLine();
            if (key == "0")
            {
                WriteLine("\nGood Bye");        
                return;
        
            }
            if (!managerOrConsultant.Contains(key))
            {
                Error();        
            }
            if (managerOrConsultant.Contains(key))
            {
                switch (key)
                {
                    case "0": continue;
                    case "1":
                        Clear();
                      //  Write("Введите пароль >>> ");
                        //checkPassword = ReadLine();
                       // if (checkPassword == "skillbox") 
                        //{
                            Clear();
                            Human manager = new Manager();
                            Write("\nЧтобы добавить нового пользователя нажмите - 1" +
                                  "\nЧтобы изменить данные пользователя нажмите - 2" +
                                  "\nЧтобы отсортировать пользователей по имени нажмите - 3" +
                                  "\nЧтобы выйти нажмите - 0\n>>> ");
                            key = ReadLine();
                            switch (key)
                            {
                                case "1": Clear(); (manager as Manager).AddNewPerson(); break;
                                case "2": Clear(); (manager as Manager).ChangeDataPersonById(); break;                 
                                case "3": Clear(); (manager as Manager).SrotForName(); break;
                                case "0": Clear(); continue;
                            
                                default:Error();break;
                            }
                            
                        //}
                        //else
                        //{
                          //  WriteLine("\nПароль неверный, попробуйте снова");
                        //}
                        break;
                       
                    case "2":
                        Clear();
                        Human consultant = new Consultant();
                        Write("\nЧтобы вывести всех пользователей нажмите - 1\nЧтобы изменить пользователя нажмите - 2" +
                              "\nДля выхода нажмите - 0\n>>> ");
                        consultantInput = ReadLine();
                        switch (consultantInput)
                        {
                            case "1": Clear(); (consultant as Consultant).GetAllContact(); break;
                            case "2": Clear(); (consultant as Consultant).ChangeNumberPersonById(); break;
                            case "0": Clear(); continue;
                            default:Error();break;
                        }
                        break;

                    default:Error();break;
                }
            }
        }
    }
    
    /// <summary>
    /// метод выводит сообщение об ошибке
    /// </summary>
    public void Error()
    {
        Clear();
        WriteLine("\nВы ошиблись, попробуйте снова\n");
    }
    
    #endregion
    
}