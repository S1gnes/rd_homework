using Logger;

CustomLogger logger = new CustomLogger("log.txt");

logger.AddLog("This is a log message");

logger.AddLog("This is a warning message", LogSeverity.Warning);

logger.AddLog("This is an error message", LogSeverity.Error);

logger.AddLog("This is a log message");

logger.AddLog("This is a log message");

logger.SaveLog();

AnalysisResult result = LogAnalyzer.Analyze("log.txt");

result.WriteToFile("summary.txt");

Console.WriteLine(result);