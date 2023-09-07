namespace Logger;

public static class LogAnalyzer
{
    public static AnalysisResult Analyze(String filePath)
    {
        StreamReader sr = new StreamReader(filePath);

        AnalysisResult result = new AnalysisResult();
            
        try
        {
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine()!;
                result.LogCount++;

                int index = line.IndexOf("]", StringComparison.Ordinal);
                
                String timeString = line.Substring(line.IndexOf("[", StringComparison.Ordinal) + 1, index - 1);
                
                String severityString = line.Substring(line.IndexOf("]", StringComparison.Ordinal) + 1, line.Substring(index).IndexOf(":", StringComparison.Ordinal) - 1).Replace(" ", "");

                switch(severityString)
                {
                    case "Info":
                        result.InfoCount++;
                        break;
                    case "Warning":
                        result.WarningCount++;
                        break;
                    case "Error":
                        result.ErrorCount++;
                        break;
                }
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
        
        return result;
    }
}