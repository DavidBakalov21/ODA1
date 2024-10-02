namespace Accounts;

public interface IAccountStorage
{
    void Save(List<String> tasks);
    List<String> Load();
}