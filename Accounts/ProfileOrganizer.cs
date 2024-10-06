namespace Accounts;

public interface IProfileOrganizer
{
    List<Profile> userProfiles { get; set; }

    AccountsOrganizer accountsOrganizer { get; set; }

    void setOrganizer(AccountsOrganizer organizer);
}

public class ProfileOrganizer : IProfileOrganizer
{
    public List<Profile> userProfiles { get; set; }

    public AccountsOrganizer accountsOrganizer { get; set; }

    public void setOrganizer(AccountsOrganizer organizer)
    {
        accountsOrganizer = organizer;
    }

    public void setPorfiles(List<Profile> profiles)
    {
        userProfiles = profiles;
    }
}
