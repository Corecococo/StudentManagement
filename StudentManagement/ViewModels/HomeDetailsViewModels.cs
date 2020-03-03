using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class HomeDetailsViewModels
    {
        public string PageTitle { get; set; }

        public Student Student { get; set; }
    }
}
