namespace Logger;

public class CustomLogger
{
    String filePath;
    List<String> logs;
    
    
    public CustomLogger(String filePath)
    {
        this.filePath = filePath;
        logs = new List<String>();
    }

    public void LoadLog()
    {
        StreamReader sr = new StreamReader(filePath);
        try
        {
            while (!sr.EndOfStream)
            {
                logs.Add(sr.ReadLine()!);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        finally
        {
            sr.Close();
        }
    }
    
    public void AddLog(String log, LogSeverity severity = LogSeverity.Info)
    {
        String time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        logs.Add("["+ time + "] " + severity + ": " + log);
    }

    public void SaveLog()
    {
        StreamWriter sw = new StreamWriter(filePath);
        
        try
        {
            foreach (var log in logs)
            {
                sw.WriteLine(log);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be written:");
            Console.WriteLine(e.Message);
        }
        finally
        {
            sw.Close();
        }
    }
}