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
			Dictionary<int, string> users = new Dictionary<int, string>();

            // For School "Data Source=KrebsDB015;Initial Catalog=[master];User id=Krebs015;Password=pKrebs015;
            ConfigurationForm config_form = new ConfigurationForm();
            QuestionForm ques_form = new QuestionForm(4);
            EvaluationForm eval_form = new EvaluationForm();
            StartForm start_form = new StartForm(config_form, ques_form, eval_form);

            start_form.ShowDialog();
            /*
            Controller c = new Controller();
			c.InitQuestionaire(3);
			Question q = c.GetFirstQuestion();
			do
			{
				Console.WriteLine(q);
				Console.Write("Antwort: ");
				int choosen_answer = Convert.ToInt32(Console.ReadLine());
				q.AnswerQuestion(choosen_answer);
			} while ((q = c.GetNextQuestion()) != null);
			Console.WriteLine(c.Evaluate()+" %");
			Console.Read();
            */
        }
	}
}