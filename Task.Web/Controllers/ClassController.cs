
namespace InternshipTask.Controllers
{
	public class ClassController : Controller
	{
		private readonly TaskDbContext _context;
        public ClassController(TaskDbContext context)
        {
			_context = context;
        }
        public async Task<IActionResult> Index()
		{
			try
			{
				var list = await _context.Classes.ToListAsync();

				return View(list);

			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return View("Error");
			}
		
		}
	}
}
