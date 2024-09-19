using Microsoft.Extensions.Configuration;

public class LibraryService
{
    private readonly IConfiguration _configuration;

    public LibraryService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    
    public List<string> GetBooks()
    {
        var booksSection = _configuration.GetSection("Books");
        return booksSection.Get<List<string>>() ?? new List<string>();
    }

    
    public Dictionary<string, string> GetUserProfile(int id)
    {
        var profileSection = _configuration.GetSection($"Profiles:{id}");
        return profileSection.Get<Dictionary<string, string>>() ?? new Dictionary<string, string>();
    }

    
    public Dictionary<string, string> GetCurrentUserProfile()
    {
        var profileSection = _configuration.GetSection("Profiles:currentUser");
        return profileSection.Get<Dictionary<string, string>>() ?? new Dictionary<string, string>();
    }
}
