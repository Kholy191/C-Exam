using System.Collections;
using System.Collections.Immutable;
//
namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject Subj = new Subject("Programming", 0) { Id = 0, Name = "Programming" };

            Subj.ExamCreating();
            Console.Clear();
            Console.WriteLine("Do u want to take the exam Y for yes N for No");
            if (Console.ReadLine() == "Y")
            {
                Subj.TakeExam();
            }
            else
            {
                return;
            }
            
            
            
        }
    }
}
