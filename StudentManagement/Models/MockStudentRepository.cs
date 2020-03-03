using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRepository:IStudentRepository
    {
        private List<Student> students;

        public MockStudentRepository()
        {
            students = new List<Student>
            {
                new Student(){Id=1,Name="张三",ClassName="一年级",Email="sdh@qq.com"},
                new Student(){Id=2,Name="李四",ClassName="二年级",Email="sdh@qq.com"},
                new Student(){Id=3,Name="王麻子",ClassName="三年级",Email="sdh@qq.com"},
            };
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return students;
        }

        public Student GetStudent(int Id)
        {
            return students.FirstOrDefault(student => student.Id == Id);
        }
    }
}
