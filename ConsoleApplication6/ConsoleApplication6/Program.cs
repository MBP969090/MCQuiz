using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
	class Program
	{
		static void Main(string[] args)
		{
            Controller c = new Controller();
			c.InitDemoQuestionaire();
            
			if (c.InitDemoQuestionaire())
			{
				Question q = c.GetFirstQuestion();
				do
				{
					Console.WriteLine(q);
					bool answer_success = false;
					while (!answer_success)
					{
						Console.Write("Antwort: ");
						int choosen_answer = Convert.ToInt32(Console.ReadLine());
						answer_success = q.AnswerQuestion(choosen_answer);
					}
				} while ((q = c.GetNextQuestion()) != null);
				Console.WriteLine(c.Evaluate() + " %");
			}
			else
			{
				Console.WriteLine("Initialisation failed");
			}
			//Console.Read();
            
        }
	}
}