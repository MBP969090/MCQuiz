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

		public bool AnswerQuestion(int number)
		{
			try {
				this.answers[number].SetChoosen();
				return true;
			}catch(ArgumentOutOfRangeException e)
			{
				return false;
			}
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

		public Answer GetAnswer(int i)
		{
			return this.answers[i];
		}

		public string GetText()
		{
			return this.text;
		}

		public Answer GetSelectedAnswer()
		{
			foreach (Answer answer in this.answers)
			{
				if (answer.IsChoosen())
				{
					return answer;
				}
			}
			return null;
		}

		public Answer GetCorrectAnswer()
		{
			foreach (Answer answer in this.answers)
			{
				if (answer.IsCorrect())
				{
					return answer;
				}
			}
			return null;
		}
	}
}