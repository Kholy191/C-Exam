using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal abstract class Exam
    {
        public int ExamTime { get; set; }
        public int QuestionsCount { get; set; }
        public ExamTypes ExamTypes { get; set; }
        public Subject? Subject { get; set; }
        public Question[]? Questions { get; set; }
        public abstract void QuestionAdder();
        public void ExamResult(byte[] Ans, int Marks, int TotalMarks)
        {
            {
                if (Questions != null)
                {
                    for (int i = 0; i < Questions.Length; i++)
                    {
                        Questions[0].ToString();
                        Console.WriteLine($"Your Answer is {Ans[i]}");
                        Console.WriteLine($"The Right answer is {Questions[0].RightAnswerIndex}");
                    }
                }
                Console.WriteLine($"Final = {Marks} of {TotalMarks}");
            }
        }

    }

    internal class FinalExam : Exam
    {
        public override void QuestionAdder()
        {
            byte type;
            byte Mark;
            byte index;
            Questions = new Question[QuestionsCount];
            for (int i = 0; i < QuestionsCount; i++)
            {
                Console.WriteLine($"Enter the Type of the queestion {i} ( 1 for Mcq // 2 for T/F");
                while (!(byte.TryParse(Console.ReadLine(), out type)) || (type != 1 && type != 2))
                {
                    Console.WriteLine("Enter the Type of the queestions( 1 for Mcq 2 for T/F");
                }
                if (type == 1)
                {
                    MCQ McqQ = new MCQ();
                    Console.WriteLine("Enter the Head of the Q");
                    McqQ.Header = Console.ReadLine();
                    Console.WriteLine("Enter the Body of the Q");
                    McqQ.Body = Console.ReadLine();
                    Console.WriteLine("Enter the Mark of the Q");
                    while (!(byte.TryParse(Console.ReadLine(), out Mark)))
                    {
                        Console.WriteLine("Enter the Mark of the Q");
                    }
                    McqQ.Mark = Mark;

                    McqQ.answers = new Answers[4];
                    #region Answers Taking
                    for (int j = 0; j < McqQ.answers.Length; j++)
                    {
                        Answers ans = new Answers();
                        ans.AnswerId = j;
                        Console.WriteLine($"Write Answer number {j}");
                        ans.AnswerText = Console.ReadLine();
                        McqQ.answers[j] = ans;
                    }

                    Console.WriteLine("Enter the valid Answer index");
                    while (!(byte.TryParse(Console.ReadLine(), out index)) || !(index >= 0 && index < 4))
                    {
                        Console.WriteLine("Enter the valid Answer index");
                    }
                    McqQ.RightAnswerIndex = index;
                    #endregion

                    Questions[i] = McqQ;
                }

                else if (type == 2)
                {
                    TrueOrFalse T_Fq = new TrueOrFalse();
                    Console.WriteLine("Enter the Head of the Q");
                    T_Fq.Header = Console.ReadLine();
                    Console.WriteLine("Enter the Body of the Q");
                    T_Fq.Body = Console.ReadLine();
                    Console.WriteLine("Enter the Mark of the Q");
                    while (!(byte.TryParse(Console.ReadLine(), out Mark)))
                    {
                        Console.WriteLine("Enter the Mark of the Q");
                    }
                    T_Fq.Mark = Mark;

                    #region Answers Taking
                    T_Fq.answers = new Answers[2];
                    T_Fq.answers[0] = new Answers { AnswerId = 0, AnswerText = "True" };
                    T_Fq.answers[1] = new Answers { AnswerId = 1, AnswerText = "False" };

                    Console.WriteLine("Enter the valid Answer index 0 for True and 1 for False");
                    while (!(byte.TryParse(Console.ReadLine(), out index)) || (index != 0 && index != 1))
                    {
                        Console.WriteLine("Enter the valid Answer index");
                    }
                    T_Fq.RightAnswerIndex = index;
                    #endregion

                    Questions[i] = T_Fq;
                }
            }
        }

    }

    internal class PractialExam : Exam
    {
        public override void QuestionAdder()
        {
            byte Mark;
            byte index;
            Questions = new MCQ[QuestionsCount];

            for (int i = 0; i < QuestionsCount; i++)
            {
                MCQ McqQ = new MCQ();
                Console.WriteLine("Enter the Head of the Q");
                McqQ.Header = Console.ReadLine();
                Console.WriteLine("Enter the Body of the Q");
                McqQ.Body = Console.ReadLine();
                Console.WriteLine("Enter the Mark of the Q");
                while (!(byte.TryParse(Console.ReadLine(), out Mark)))
                {
                    Console.WriteLine("Enter the Type of the queestions( 1 for Mcq 2 for T/F");
                }
                McqQ.Mark = Mark;

                McqQ.answers = new Answers[4];
                #region Answers Taking
                for (int j = 0; j < McqQ.answers.Length; j++)
                {
                    Answers ans = new Answers();
                    ans.AnswerId = j;
                    Console.WriteLine($"Write Answer number {j}");
                    ans.AnswerText = Console.ReadLine();
                    McqQ.answers[j] = ans;
                }

                Console.WriteLine("Enter the valid Answer index");
                while (!(byte.TryParse(Console.ReadLine(), out index)) || !(index >= 0 && index < 4))
                {
                    Console.WriteLine("Enter the valid Answer index");
                }
                McqQ.RightAnswerIndex = index;
                #endregion

                Questions[i] = McqQ;
            }
        }
    }
}


