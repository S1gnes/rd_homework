namespace Logger;

public class AnalysisResult
{
    public int LogCount;
    public int InfoCount;
    public int WarningCount;
    public int ErrorCount;
    
    public AnalysisResult(int logCount = 0, int infoCount = 0, int warningCount = 0, int errorCount = 0)
    {
        LogCount = logCount;
        InfoCount = infoCount;
        WarningCount = warningCount;
        ErrorCount = errorCount;
    }
    
    public void WriteToFile(String filePath)
    {
        StreamWriter sw = new StreamWriter(filePath);
        
        try
        {
            sw.WriteLine(this);
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


    public override string ToString()
    {
        return $"LogCount: {LogCount}, InfoCount: {InfoCount}, WarningCount: {WarningCount}, ErrorCount: {ErrorCount}";
    }
}