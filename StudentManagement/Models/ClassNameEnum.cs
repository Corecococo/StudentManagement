using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public enum ClassNameEnum
    {
        [Display(Name = "一年级")]
        一年级,

        [Display(Name = "二年级")]
        二年级,

        [Display(Name = "三年级")]
        三年级

    }
}
