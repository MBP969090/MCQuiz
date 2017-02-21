using System;
using System.Collections.Generic;

namespace ConsoleApplication6
{
	public class Questionaire
	{
		private List<Question> questions = new List<Question>();
		private int question_counter = 0;

		public Questionaire(Dictionary<string, Dictionary<string, bool>> questions)
		{
			foreach (var item in questions)
			{
				List<Answer> answer_list = new List<Answer>();
				foreach (var answer in item.Value)
				{
					Answer answer_object = new Answer(answer.Key, answer.Value);
					answer_list.Add(answer_object);
				}
				AddQuestion(item.Key, answer_list);
			}
		}

		public void AddQuestion(string text, List<Answer> answers)
		{
			Question question = new Question(text, answers, ++this.question_counter);
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
	}
}