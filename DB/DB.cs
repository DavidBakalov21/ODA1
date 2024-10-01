namespace DB;

public interface IDataBase
{
    //need to remove path
    String FilePath { get; set; }
    void Save(List<String> tasks);
    List<String> Load();
}

public class Database: IDataBase {

    //need to remove path
    public string FilePath { get; set; }  = "tasks.txt";

    public void Save(List<String> tasks){
      
            File.WriteAllLines(FilePath, tasks);
        
    }
    public List<String> Load(){
        if (File.Exists(FilePath))
        {
            var tasks = File.ReadAllLines(FilePath);
            return new List<string>(tasks);
        }
        else
        {
            return [];
        }
    }

}