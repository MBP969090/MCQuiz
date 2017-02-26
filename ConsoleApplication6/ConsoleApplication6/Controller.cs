using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
		}

		public void InitQuestionaire(int id)
		{
			this.questionaire = new Questionaire(id);
			using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4DTNI3N;Initial Catalog=master;Integrated Security=true;"))
			{
				string query = "SELECT FragebogenNr, P_Id, Frage, Antwort1, Antwort2, Antwort3, Antwort4, RichtigeAntwort FROM T_Fragebogen_unter_Maschine LEFT JOIN T_SBF_Binnen ON (F_Id_SBF_Binnen=P_id) WHERE FragebogenNr="+id;
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3) && !reader.IsDBNull(4) && !reader.IsDBNull(5) && !reader.IsDBNull(6) && !reader.IsDBNull(7))
						{
							Dictionary<string, bool> answers = new Dictionary<string, bool>();
							for (int i = 3; i <= 6; i++)
							{
								try {
									if (reader.GetByte(7) == i - 2)
									{
										answers.Add(reader.GetString(i), true);
									}
									else
									{
										answers.Add(reader.GetString(i), false);
									}
								}catch(ArgumentException e)
								{
									Console.WriteLine("Doppelte Antwort");
								}
								
							}
							
							this.questionaire.AddQuestion(reader.GetInt32(1), reader.GetString(2), answers);
						}
					}
				}
				connection.Close();
			}
		}

		public Question GetNextQuestion()
		{
			return this.questionaire.GetNextQuestion();
		}

		public Question GetFirstQuestion()
		{
			return this.questionaire.GetFirstQuestion();
		}

		public bool AnswerQuestion(int question_id, int number)
		{
			try {
				this.questionaire.GetQuestion(question_id).AnswerQuestion(number);
				return true;
			}catch(NullReferenceException e)
			{
				return false;
			}
		}

		public Question GetQuestion(int id)
		{
			return this.questionaire.GetQuestion(id);
		}
		public override string ToString()
		{
			return this.questionaire.ToString();
		}

		public double Evaluate()
		{
			return this.questionaire.Evaluate();
		}
	}
}
