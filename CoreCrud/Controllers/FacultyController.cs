using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreCrud.Controllers
{
    public class FacultyController : Controller
    {
        private readonly MyModel contex;
        IHostEnvironment environment;
        public FacultyController(MyModel newContext, IHostEnvironment env = null)
        {
            this.contex = newContext;
            this.environment = env;
        }
        public IActionResult Index()
        {
            return View(contex.Faculties.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                if (faculty.Picture != null)
                {
                    // var ext = Path.GetExtension(faculty.Picture.FileName);
                    var rootPath = this.environment.ContentRootPath;
                    var fileToSave = Path.Combine(rootPath, "wwwroot/Pictures", faculty.Picture.FileName);
                    using (var fileStream = new FileStream(fileToSave, FileMode.Create))
                    {
                        faculty.Picture.CopyToAsync(fileStream);
                    }
                    faculty.PicPath = "~/Pictures/" + faculty.Picture.FileName;

                    contex.Faculties.Add(faculty);
                    if (contex.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please Provide Profile Picture");
                    return View(faculty);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));
                ModelState.AddModelError("",  message);
            }

            return View(faculty);
        }
    }
}
