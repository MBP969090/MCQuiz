using System;
using System.Collections.Generic;

namespace ConsoleApplication6
{
	public class Questionaire
	{
		private List<Question> questions = new List<Question>();
		private int id;
		private int question_pointer;

		public Questionaire(int id)
		{
			this.id = id;
			this.question_pointer = 0;
		}

		public void AddQuestion(int id, string text, Dictionary<string, bool> answers)
		{
			List<Answer> answer_list = new List<Answer>();
			foreach (var item in answers)
			{
				Answer answer = new Answer(item.Key, item.Value);
				answer_list.Add(answer);
			}
			Question question = new Question(id, text, answer_list);
			this.questions.Add(question);
		}

		public List<Question> GetQuestions()
		{
			return this.questions;
		}

		public Question GetQuestion(int question_id)
		{
			foreach (Question q in this.questions)
			{
				if(q.GetId() == question_id)
				{
					return q;
				}
			}
			return null;
		}

		public override string ToString()
		{
			string output = "";
			foreach (Question question in this.questions)
			{
				output += question.ToString()+"\n";
			}
			return output;
		}

		public Question GetFirstQuestion()
		{
			return this.questions[0];
		}

		public Question GetNextQuestion()
		{
			if (question_pointer < QuestionCount() - 1) {
				return this.questions[++question_pointer];
			}
			return null;
		}

		public Question GetPreviousQuestion()
		{
			if(question_pointer > 0)
			{
				return this.questions[--question_pointer];
			}
			return null;
		}

		private int QuestionCount()
		{
			return this.questions.Count;
		}

		public double Evaluate()
		{
			int correct_answers = 0;
			foreach (Question question in this.questions)
			{
				if (question.IsRight())
				{
					correct_answers++;
				}
			}
			return 100*(double)correct_answers / QuestionCount();
		}
	}
}