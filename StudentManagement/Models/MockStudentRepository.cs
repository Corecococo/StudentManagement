using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRepository:IStudentRepository
    {
        private readonly List<Student> students;

        public MockStudentRepository()
        {
            students = new List<Student>
            {
                new Student(){Id=1,Name="张三",ClassName=ClassNameEnum.一年级,Email="sdh@qq.com"},
                new Student(){Id=2,Name="李四",ClassName=ClassNameEnum.三年级,Email="sdh@qq.com"},
                new Student(){Id=3,Name="王麻子",ClassName=ClassNameEnum.二年级,Email="sdh@qq.com"},
            };
        }

        public Student Add(Student student)
        {
            student.Id = students.Max(student => student.Id) + 1;
            students.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            Student student = students.FirstOrDefault(s => s.Id == id);
            if(student != null)
            {
                students.Remove(student);
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return students;
        }

        public Student GetStudent(int Id)
        {
            return students.FirstOrDefault(student => student.Id == Id);
        }

        public Student Update(Student student)
        {
            Student upStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if(student != null)
            {
                upStudent.Name = student.Name;
                upStudent.ClassName = student.ClassName;
                upStudent.Email = student.Email;
            }
            return upStudent;
        }
    }
}
