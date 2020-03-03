using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: /<controller>/
        public string list()
        {
            return "Departments中的list()方法";
        }

        public string part()
        {
            return "Departments中的part()方法";
        }
    }
}
