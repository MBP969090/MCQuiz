using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleApplication6
{
	[TestFixture]
	class QuestionnaireTest
	{
		Questionnaire q = new Questionnaire(1);

		[SetUp]
		public void SetupQuestionnaire()
		{
			q.AddQuestion(1, "Warum nur?", new List<Dictionary<string, bool>>());
			q.AddQuestion(2, "Warum nicht?", new List<Dictionary<string, bool>>());
			q.AddQuestion(3, "Ja warum eigentlich nicht?", new List<Dictionary<string, bool>>());
		}

		[Test]
		public void GetQuestionTest()
		{
			Assert.AreEqual("Warum nur?",  q.GetCurrentQuestion().GetText());
		}

		[Test]
		public void NextQuestionTest()
		{
			Question nextQuestion = q.GetNextQuestion();
			Assert.AreEqual("Warum nicht?", nextQuestion.GetText());
			Question currentQuestion = q.GetCurrentQuestion();
			Assert.AreEqual("Warum nicht?", currentQuestion.GetText());
		}

		[Test]
		public void PreviousQuestionTest()
		{
			Assert.AreEqual("Warum nur?", q.GetPreviousQuestion().GetText());
			q.GetNextQuestion();
			q.GetNextQuestion();
			Assert.AreEqual("Warum nicht?", q.GetPreviousQuestion().GetText());
		}
	}
}
