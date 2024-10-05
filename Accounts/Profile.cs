namespace Accounts;

public interface IProfile
{
    Plan plan { get; set; }
    String Name {get; set;}
    AccountsOrganizer Organizer {get; set;}
    
}
public class Profile: IProfile
{
    public Plan plan { get; set; }
   public string Name { get; set; }
    public AccountsOrganizer Organizer { get; set; }

  public Profile(String name, AccountsOrganizer organizer)
  {
      this.Name = name;
      this.Organizer = organizer;
  }
}