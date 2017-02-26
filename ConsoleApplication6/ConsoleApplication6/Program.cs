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
            ConfigurationForm config_form = new ConfigurationForm();
            QuestionForm ques_form = new QuestionForm(4);
            EvaluationForm eval_form = new EvaluationForm();
            StartForm start_form = new StartForm(config_form, ques_form, eval_form);

            start_form.ShowDialog();
            
            Controller c = new Controller();
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
			Console.Read();
            
        }
	}
}