using Microsoft.AspNetCore.Mvc;

public class LibraryController : Controller
{
    private readonly LibraryService _libraryService;

    public LibraryController(LibraryService libraryService)
    {
        _libraryService = libraryService;
    }

    
    [HttpGet]
    public IActionResult Index()
    {
        return Content("Вітаємо у бібліотеці!");
    }

    
    [HttpGet]
    public IActionResult Books()
    {
        var books = _libraryService.GetBooks();
        return View(books); 
    }

    
    [HttpGet]
    public IActionResult Profile(int? id)
    {
        if (id.HasValue && id >= 0 && id <= 5)
        {
            var profile = _libraryService.GetUserProfile(id.Value);
            return View(profile); 
        }
        else
        {
            var profile = _libraryService.GetCurrentUserProfile();
            return View(profile);
        }
    }
}
