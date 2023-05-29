using Microsoft.AspNetCore.Mvc;
using TestTaskLasmart.Models;

namespace TestTaskLasmart.Controllers
{
    public class PointRepositoryController : Controller
    {
        IPointRepository _repository;
        public PointRepositoryController(IPointRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetPoints()
        {
            return Json(_repository.GetPoints().ToList());
        }
        [HttpPost]
        public JsonResult RemovePoint(int pointid)
        {
            if (_repository.RemovePoint(pointid))
                return Json(true);
            return Json(false);
        }
    }
}
