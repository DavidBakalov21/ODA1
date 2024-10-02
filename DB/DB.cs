using Accounts;

namespace DB;



public class FileAccountStorage: IAccountStorage {

    
    public string FilePath { get;  }

    public FileAccountStorage(String filePath)
    {
        FilePath = filePath;
    }

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