namespace InternshipTask.Controllers
{
    public class StudentController : Controller
    {
        private readonly TaskDbContext _context;

        public StudentController(TaskDbContext context)
        {
            _context = context;
        }

        // Index: Display all students
        public async Task<IActionResult> Index()
        {
            try
            {
                var students = await _context.Students
                   .Include(s => s.Class)
                   .Select(s => new StudentView
                   {
                       Id = s.Id,
                       StudentName = s.StudentName,
                       Gender = s.Gender,
                       DOB = s.DOB,
                       ClassId = s.ClassId,
                       ClassName = s.Class.Name, 
                   })
                   .ToListAsync();

                return View(students);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }

        // Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var viewModel = new StudentView
                {
                    ClassList = await _context.Classes
                        .Select(c => new SelectListItem
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        })
                        .ToListAsync()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentView model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = new Student
                    {
                        Id = Guid.NewGuid(),
                        StudentName = model.StudentName,
                        Gender = model.Gender,
                        DOB = model.DOB,
                        ClassId = model.ClassId, 
                        CreatedDate = DateTime.Now,
                        ModificationDate = DateTime.Now
                    };

                    _context.Students.Add(student);
                    await _context.SaveChangesAsync();
                   TempData["msg"] =  NotifyService.Success("Student added successfully");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View("Error");
                }
            }

          return View(model);
        }

        // Edit: Show the form to edit a student
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                var viewModel = new StudentView
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    Gender = student.Gender,
                    DOB = student.DOB,
                    ClassId = student.ClassId,
                    ClassList = await _context.Classes
                        .Select(c => new SelectListItem
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        })
                        .ToListAsync()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }

        // Edit (POST): 
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, StudentView model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var student = await _context.Students.FindAsync(id);
                    if (student == null)
                    {
                        return NotFound();
                    }

                    student.StudentName = model.StudentName;
                    student.Gender = model.Gender;
                    student.DOB = model.DOB;
                    student.ClassId = model.ClassId;
                    student.ModificationDate = DateTime.Now;

                    _context.Students.Update(student);
                    await _context.SaveChangesAsync();
                    TempData["msg"] = NotifyService.Success("Data edited successfully");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View("Error");
                }
            }

            return View(model);
        }


        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var student = await _context.Students.Include(s=>s.Class).FirstOrDefaultAsync(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }

                var viewModel = new StudentView
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    Gender = student.Gender,
                    DOB = student.DOB,
                    ClassId = student.ClassId,
                    ClassName = student.Class.Name,
                    ClassList = await _context.Classes
                        .Select(c => new SelectListItem
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        })
                        .ToListAsync()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var student = await _context.Students.Include(s => s.Class).FirstOrDefaultAsync(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }

                var viewModel = new StudentView
                {
                    Id = student.Id,
                    StudentName = student.StudentName,
                    Gender = student.Gender,
                    DOB = student.DOB,
                    ClassId = student.ClassId,
                    ClassName = student.Class.Name,
                    ClassList = await _context.Classes
                        .Select(c => new SelectListItem
                        {
                            Value = c.Id.ToString(),
                            Text = c.Name
                        })
                        .ToListAsync()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, StudentView model)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                TempData["msg"] =  NotifyService.Error("Data deleted successfully");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }
    }
}
