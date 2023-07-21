using System.Text.RegularExpressions;

namespace Catholic.Core.Helpers;

public static class Env
{
    public static void Load(string envFilename = ".env", bool swallowErrors = true)
    {
        try
        {
            LoadVariables(envFilename);
        }
        catch
        {
            if (!swallowErrors)
            {
                throw;
            }
        }
    }

    public static Dictionary<string, string> ParseConnectionString(this string connectionString) =>
        ((IEnumerable<string>) connectionString.Split(';', StringSplitOptions.RemoveEmptyEntries))
        .Select<string, string[]>((Func<string, string[]>) (t => t.Split(new char[1]
        {
            '='
        }, 2))).ToDictionary<string[], string, string>((Func<string[], string>) (t => t[0].Trim()),
            (Func<string[], string>) (t => t[1].Trim()),
            (IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase);

    private static void LoadVariables(string envFilename)
    {
        var filename = envFilename;

        if (!Path.IsPathFullyQualified(envFilename))
        {
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (dir != null && !dir.GetFiles(envFilename).Any())
            {
                dir = dir.Parent;
            }

            if (dir != null)
            {
                filename = Path.Combine(dir.FullName, filename);
            }
            else
            {
                throw new FileNotFoundException("Couldn't find the file", envFilename);
            }
        }

        File.ReadAllLines(filename)
            .Select((line, index) => (Line: line.Trim(), Index: index))
            .Where(entry => !string.IsNullOrWhiteSpace(entry.Line))
            .Where(entry => !entry.Line.StartsWith('#'))
            .ToList()
            .ForEach(entry =>
            {
                var (line, index) = entry;
                var indexOfEquality = line.IndexOf("=", StringComparison.Ordinal);
                if (indexOfEquality == -1)
                {
                    throw new InvalidOperationException($"Equality sign is missing on line {index}");
                }

                var name = line[..indexOfEquality].Trim();
                var value = line[(indexOfEquality + 1)..].Trim();

                if (string.IsNullOrWhiteSpace(name) ||
                    !Regex.Match(name, "^[a-zA-Z0-9_]*$", RegexOptions.Singleline).Success)
                {
                    throw new InvalidOperationException($"Bad environment variable name {name} on line {index}");
                }

                Environment.SetEnvironmentVariable(name, value);
            });
    }
}