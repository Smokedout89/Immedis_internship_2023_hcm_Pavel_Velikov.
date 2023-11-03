using Microsoft.AspNetCore.Mvc;

namespace HCM.Web.Areas.Admin.Controllers;

public class DepartmentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}