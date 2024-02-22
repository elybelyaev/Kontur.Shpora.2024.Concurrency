using System.Collections.Concurrent;

namespace LogParsing.LogParsers;

public class ParallelLogParser : ILogParser
{
    private readonly FileInfo file;
    private readonly Func<string, string> tryGetIdFromLine;

    public ParallelLogParser(FileInfo file, Func<string, string> tryGetIdFromLine)
    {
        this.file = file;
        this.tryGetIdFromLine = tryGetIdFromLine;
    }

    public string[] GetRequestedIdsFromLogFile()
    {
        throw new NotImplementedException();
    }
}

public class PLinqLogParser : ILogParser
{
    private readonly FileInfo file;
    private readonly Func<string, string> tryGetIdFromLine;

    public PLinqLogParser(FileInfo file, Func<string, string> tryGetIdFromLine)
    {
        this.file = file;
        this.tryGetIdFromLine = tryGetIdFromLine;
    }

    public string[] GetRequestedIdsFromLogFile()
    {
        throw new NotImplementedException();
    }
}