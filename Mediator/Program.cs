using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator // arabulucu deseni. farklı sistemleri ileştirir.
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator); teacher.Name = "Engin Demiroğ";
            Student sultan = new Student(mediator); sultan.Name = "Sultan Demirci";
            Student serdar = new Student(mediator); serdar.Name = "Serdar Kemik";

            mediator.Teacher = teacher;
            mediator.Students = new List<Student> { sultan, serdar};

            teacher.SendNewImageUrl("slide1.jpg");
            teacher.RecieveQuestion("Is it true?", sultan);

            Console.ReadKey();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
            
        }
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine($"{Name} Received a Question From : {student.Name}, {question}");
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine($"{Name} Changed The Slide : {url}");
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion (string answer, Student student)
        {
            Console.WriteLine($"{Name} Answered The Question : {student.Name}, {answer}");
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
            
        }
        public string Name { get; set; }

        public void ReceiveImage(string url)
        {
            Console.WriteLine($"{Name} Received The Image : {url}");
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine($"{Name} Received The Answer : {answer}");
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }


}
