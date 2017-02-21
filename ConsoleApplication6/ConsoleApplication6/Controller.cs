using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
	class Controller
	{
		
		Questionaire questionaire;

		public Controller()
		{
			// this should happen with some sql thing!! --->
			Dictionary<string, Dictionary<string, bool>> d = new Dictionary<string, Dictionary<string, bool>>();
			d.Add("Wie heißt unser Bundeskanzler?", new Dictionary<string, bool>() {
				{ "Angela Merkel", true },
				{ "Heinrich Kohl", false },
				{ "Herbert Grönemeyer", false },
				{ "Susi Strolch", false }
			});

			d.Add("Was ergibt 1+1?", new Dictionary<string, bool>()
			{
				{"1", false },
				{"2", true },
				{"4", false }
			});
			// <-----;

			this.questionaire = new Questionaire(d);
		}

		public void AnswerQuestion(int question_id, int[] choosen_answers)
		{
			this.questionaire.GetQuestion(question_id).AnswerQuestion(choosen_answers);
		}

		public Question GetQuestion(int id)
		{
			return this.questionaire.GetQuestion(id);
		}
		public override string ToString()
		{
			return this.questionaire.ToString();
		}
	}
}
