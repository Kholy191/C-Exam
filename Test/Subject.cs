using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Subject
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public Exam? exam { get; set; }

        public Subject(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void ExamCreating() // Exam Creating
        {
            ExamTypes type = new ExamTypes();
            object? obj;
            /*Type Of Exam*/
            Console.WriteLine("Write the Type of Exam");
            while (!(Enum.TryParse(typeof(ExamTypes), Console.ReadLine(), true, out obj)))
            {
                Console.WriteLine("Write the Type of Exam");
            }
            type = (ExamTypes)obj;

            /*After Type Determined*/

            if (type == ExamTypes.Final)
            {
                FinalExam finalexam = new FinalExam();
                finalexam.Subject = this;
                finalexam.ExamTypes = ExamTypes.Final;

                TimeCountSetter(finalexam);
                finalexam.QuestionAdder();

                exam = finalexam;
            }

            if (type == ExamTypes.Practical)
            {
                PractialExam practialexam = new PractialExam();
                practialexam.ExamTypes = ExamTypes.Practical;
                practialexam.Subject = this;

                TimeCountSetter(practialexam);
                practialexam.QuestionAdder();

                exam = practialexam;
            }



        }

        private void TimeCountSetter(Exam ex)
        {
            int time;
            int Qnumber;

            #region Number of Q set
            Console.WriteLine("Write the Number of Questions");
            while (!(int.TryParse(Console.ReadLine(), out Qnumber)))
            {
                Console.WriteLine("Write the Number of Questions");
            }
            ex.QuestionsCount = Qnumber;
            #endregion

            #region Time set
            Console.WriteLine("Write the Time of the TEST between 30 : 180");
            while (!(int.TryParse(Console.ReadLine(), out time)) || (time > 180) || (time < 0))
            {
                Console.WriteLine("Write the Time of the TEST");
            }
            ex.ExamTime = time;
            #endregion
        }

        public void TakeExam()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int Marks = 0;
            int totalMarks = 0;
            if (exam != null)
            {
                if (exam.Questions != null)
                {
                    byte[] Ans = new byte[exam.Questions.Length];

                    for (int i = 0; i < exam.Questions.Length; i++)
                    {
                        if (exam.Questions[i].answers is not null)
                        {
                            this.exam.Questions[i].ToString();
                            Console.WriteLine("Enter the index of your answer");
                            while (!(byte.TryParse(Console.ReadLine(), out Ans[i])) || (Ans[i] > (exam.Questions[i].answers?.Length - 1)) || (Ans[i] < 0))
                            {
                                Console.WriteLine("Enter the index of your answer");
                            }
                            if (Ans[i] == this.exam.Questions[i].RightAnswerIndex)
                            {
                                Marks = Marks + this.exam.Questions[i].Mark;
                            }
                            else
                            {
                                //Do Nothing
                            }
                            totalMarks += this.exam.Questions[i].Mark;
                        }
                    }
                    stopwatch.Stop();
                    Console.Clear();
                    exam.ExamResult(Ans, Marks, totalMarks);
                    Console.WriteLine($"Time Taken is {stopwatch}");
                }



            }
        }

    }

    public enum ExamTypes
    {
        Final, Practical
    }
}

