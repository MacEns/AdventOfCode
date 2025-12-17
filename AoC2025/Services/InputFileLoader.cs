namespace AoC2025.Services;

public class InputFileLoader
{
    private readonly IWebHostEnvironment _environment;

    public InputFileLoader(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<List<string>> LoadInputAsync(string fileName)
    {
        var filePath = Path.Combine(_environment.WebRootPath, fileName);

        if (!File.Exists(filePath))
        {
            return new List<string>();
        }

        var lines = await File.ReadAllLinesAsync(filePath);
        return lines.ToList();
    }
}

