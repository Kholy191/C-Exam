using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Answers
    {
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }

        public override string ToString()
        {
            return $"({AnswerId}) {AnswerText}";
        }
    }
}
