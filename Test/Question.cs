using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Question
    {
        public string? Header { get; set; }
        public string? Body { get; set; }
        public byte Mark { get; set; }
        public byte RightAnswerIndex { get; set; }
        public Answers[]? answers { get; set; }
        public override string ToString()
        {
            Console.WriteLine($"{Header}\n {Body}          Mark: {Mark}");
            if (answers != null)
            {
                for (int i = 0; i < answers.Length; i++)
                {
                    Console.WriteLine(answers[i]);
                }
                return "Answers The Question";
            }

            else
            {
                return "No Answers";
            }
        }
    }

    internal class TrueOrFalse : Question
    {

    }

    internal class MCQ : Question
    {

    }
}
