using System;

namespace ConsoleApplication6
{
	public class Answer
	{
		private string text;
		private bool correct;
		private bool choosen;

		public Answer(string text, bool correct)
		{
			this.text = text;
			this.correct = correct;
			this.choosen = false;
		}

		public string GetText()
		{
			return this.text;
		}

		public bool IsChoosen()
		{
			return this.choosen;
		}

		internal void SetChoosen()
		{
			this.choosen = true;
		}

		public bool IsCorrect()
		{
			return this.correct;
		}

		public override string ToString()
		{
			return this.text;
		}
	}
}