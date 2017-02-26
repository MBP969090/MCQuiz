using System;
using System.Collections.Generic;

namespace ConsoleApplication6
{
	public class Question
	{
		private string text;
		private List<Answer> answers;
		private int id;
		public Question(int id, string text, List<Answer> answers)
		{
			this.text = text;
			this.answers = answers;
			this.id = id;
		}

		public Question(int id, string text)
		{
			this.id = id;
			this.text = text;
			this.answers = new List<Answer>();
		}

		public void AddAnswer(string text, bool correct)
		{
			Answer answer = new Answer(text, correct);
			this.answers.Add(answer);
		}

		public void AddAnswer(Answer answer)
		{
			this.answers.Add(answer);
		}

		public override string ToString()
		{
			string output = "";
			output = this.id + ": " +this.text;
			int answer_id = 1;
			foreach(Answer answer in this.answers)
			{
				output += "\n\t#"+answer_id+++": "+answer.GetText() + "(Ausgewählt: "+answer.IsChoosen()+") " + answer.IsCorrect();
			}
			output += "\nAuswertung: " + (IsRight() ? 1 : 0);
			return output;
		}

		public void AnswerQuestion(int number)
		{
			this.answers[number - 1].SetChoosen();
		}

		internal int GetId()
		{
			return this.id;
		}

		// returns success in percents
		public bool IsRight()
		{
			bool correct = false;
			foreach (Answer answer in answers)
			{
				if(answer.IsCorrect() && answer.IsChoosen()) {
					correct = true;
				}
			}
			return correct;
		}
	}
}