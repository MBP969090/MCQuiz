using System;
using System.Collections.Generic;

namespace ConsoleApplication6
{
	public class Question
	{
		private string text;
		private List<Answer> answers;
		private int question_id;
		public Question(string text, List<Answer> answers, int question_id)
		{
			this.text = text;
			this.answers = answers;
			this.question_id = question_id;
		}

		public Question(string text)
		{
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
			output = this.text;
			foreach(Answer answer in this.answers)
			{
				output += "\n\t"+answer.GetText() + "(Ausgewählt: "+answer.IsChoosen()+") " + answer.IsCorrect();
			}
			output += "\nAuswertung: " + Result() + " %";
			return output;
		}

		public void AnswerQuestion(int[] choosen_answers)
		{
			for (int i = 0; i < choosen_answers.Length; i++)
			{
				if(choosen_answers[i] == 1) {
					this.answers[i].SetChoosen();
				} 
			}
		}

		internal int GetId()
		{
			return this.question_id;
		}

		// returns success in percents
		public double Result()
		{
			int answer_count = this.answers.Count;
			int correct_answers = 0;
			foreach (Answer answer in answers)
			{
				if(answer.IsCorrect() == answer.IsChoosen()) {
					correct_answers++;
				}
			}
			return (double)(100 * correct_answers / answer_count);
		}
	}
}