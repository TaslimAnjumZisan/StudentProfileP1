using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentProfileP1.Manager.ManagerImplenentation;
using StudentProfileP1.Manager.ManagerInterface;
using StudentProfileP1.ViewModel;

namespace StudentProfileP1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentsManager _studentManager;

        public StudentController(IStudentsManager studentManager)
        {
            _studentManager = studentManager;
        }

        public async Task<IActionResult> Index()
        {
            var studentList = await _studentManager.GetAllStudentsAsync();
            return View(studentList);
        }

        public IActionResult Create()
        {
            var model =new StudentCreateModel();
            model.DepartmentList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select Department",Value=""},
                new SelectListItem(){Text="CSE",Value="CSE"},
                new SelectListItem(){Text="EEE",Value="EEE"},
                new SelectListItem(){Text="CIVIL",Value="CIVIL"},
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boolean result = await _studentManager.CreateStudentAsync(obj);
                    if (result)
                    {
                        //ToDo Need to Incorporate Flash Message
                    }
                    return RedirectToAction("Index");
                }

                obj.DepartmentList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select Department",Value=""},
                new SelectListItem(){Text="CSE",Value="CSE"},
                new SelectListItem(){Text="EEE",Value="EEE"},
                new SelectListItem(){Text="CIVIL",Value="CIVIL"},
            };

                return View(obj);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }  
}
