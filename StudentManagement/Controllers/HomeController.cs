using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        //属性路由配置
        //[Route("abc/12")]
        [Route("")]
        public IActionResult Index()
        {
            var model = studentRepository.GetAllStudent();
            return View(model);
        }

        /*//ObjectResult遵循内容协商，可返回JSON和xml格式数据
        public ObjectResult Details()
        {
            Student model = studentRepository.GetStudent(1);
            return new ObjectResult(model);
        }*/

        public IActionResult Details(int? id)
        {
            Student student = studentRepository.GetStudent(id??1);
            HomeDetailsViewModels homeDetailsViewModels = new HomeDetailsViewModels()
            {
                PageTitle = "学生详情",
                Student = student
            };
            return View(homeDetailsViewModels);
        }

        //当方法出现重载时，需要为方法添加说明，当前方法为GET请求时执行
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //进行模型绑定并重定向，参数中数据为已绑定的模型
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = studentRepository.Add(student);
                return RedirectToAction("Details", new { newStudent.Id });
            }
            return View();
        }
    }
}