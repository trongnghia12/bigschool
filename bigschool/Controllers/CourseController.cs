using bigschool.Models;
using bigschool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bigschool.Controllers
{
    public class CourseController : Controller  
    {
        private readonly ApplicationDbContext _dbContext;
            public CourseController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Create
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}