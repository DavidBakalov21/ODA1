namespace Accounts;

public interface IProfile
{
    Plan plan {get; set;}
    String name {get; set;}
}
public class Profile: IProfile
{
    public Plan plan { get; set; }
    public string name { get; set; }

  public Profile(String name, Plan plan)
  {
      this.name = name;
      this.plan = plan;
  }
}