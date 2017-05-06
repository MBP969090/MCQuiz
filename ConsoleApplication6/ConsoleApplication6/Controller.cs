using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication6
{
	/// <summary>
	/// This class is the main controller for Questionnaire
	/// </summary>
	public class Controller
	{
		private Questionnaire questionnaire;
		private ConfigurationForm config_form;
		private QuestionForm ques_form;
		private EvaluationForm eval_form;
		private StartForm start_form;
		private Configuration configuration;

		//private string sqlString = "server=Erde2008;database=Krebs_DB015;User id=Krebs015;Password=pKrebs015";
		private string sqlString = "Data Source=DESKTOP-4DTNI3N;Initial Catalog=master;Integrated Security=true;";

		/// <summary>
		/// Constructor for Controller object
		/// Initialises GUI
		/// </summary>
		public Controller()
		{
			//this.CreateHistoryTable();
			this.configuration = new Configuration();
			this.config_form = new ConfigurationForm(this);
			this.eval_form = new EvaluationForm(this);
			this.start_form = new StartForm(this);
			this.start_form.GetNameLabel().Text = this.configuration.NameOfProgram;

			string[] myList = GetDictionaryIds().ToArray();
			this.start_form.GetListBoxQuestionnaire().Items.AddRange(myList);

			SetHistoryListView();
			this.start_form.ShowDialog();
		}

		/// <summary>
		/// Initialise questionnaire with id out of database
		/// </summary>
		/// <param name="id"></param>
		/// <returns>success</returns>
		public bool InitQuestionnaire(int id, string type)
		{
			bool success = false;
			this.questionnaire = new Questionnaire(id);
			using (SqlConnection connection = new SqlConnection(sqlString))
			{
				string query = "";
				if (type == "Binnen")
				{
					query = "SELECT FragebogenNr, P_Id, Frage, Antwort1, Antwort2, Antwort3, Antwort4, RichtigeAntwort FROM T_Fragebogen_unter_Maschine LEFT JOIN T_SBF_Binnen ON (F_Id_SBF_Binnen=P_id) WHERE FragebogenNr=" + id;
				}
				else if(type == "Funk")
				{
					query = "SELECT FragebogenNr, Id, Frage, AntwortA, AntwortB, AntwortC, AntwortD, RichtigeAntwort FROM T_Funk_UBI LEFT JOIN T_Fragebogen_Funk_UBI ON (F_id_Funk_UBI=Id) WHERE FragebogenNr=" + id;
				}
				else
				{
					return false;
				}
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3) && !reader.IsDBNull(4) && !reader.IsDBNull(5) && !reader.IsDBNull(6) && !reader.IsDBNull(7))
						{
							success = true;
							List<Dictionary<string, bool>> answers = new List<Dictionary<string, bool>>();
							for (int i = 3; i <= 6; i++)
							{
								if (type == "Binnen")
								{
									if (reader.GetByte(7) == i - 2)
									{
										answers.Add(new Dictionary<string, bool> { { reader.GetString(i), true } });
									}
									else
									{
										answers.Add(new Dictionary<string, bool> { { reader.GetString(i), false } });
									}
								}
								else
								{
									string rightAnswerString = reader.GetString(7);
									int rightAnswer = 0;
									switch(rightAnswerString){
										case "A":
											rightAnswer = 1;
											break;
										case "B":
											rightAnswer = 2;
											break;
										case "C":
											rightAnswer = 3;
											break;
										case "D":
											rightAnswer = 4;
											break;
										default:
											break;
									}
									if (rightAnswer == i - 2)
									{
										answers.Add(new Dictionary<string, bool> { { reader.GetString(i), true } });
									}
									else
									{
										answers.Add(new Dictionary<string, bool> { { reader.GetString(i), false } });
									}
								}

							}

							this.questionnaire.AddQuestion(reader.GetInt32(1), reader.GetString(2), answers);
						}
					}
				}
				connection.Close();
			}
			return success;
		}

		/// <summary>
		/// Create new questionnaire with hard coded data
		/// </summary>
		/// <returns></returns>
		public bool InitDemoQuestionnaire()
		{
			this.questionnaire = new Questionnaire(1);
			string[] questions = new string[5];
			questions[4] = "Was ist zu tun, wenn vor Antritt der Fahrt nicht feststeht, wer Fahrzeugführer ist?";
			questions[1] = "In welchen Fällen darf weder ein Sportboot geführt noch dessen Kurs oder Geschwindigkeit selbstständig bestimmt werden?";
			questions[2] = "Wann ist ein Fahrzeug in Fahrt?";
			questions[3] = "Wie lang ist die Dauer eines kurzen Tons(•) ?";
			questions[0] = "Welche Bedeutung hat folgendes Tafelzeichen ?  {Binnen17.gif}";

			List<List<Dictionary<string, bool>>> answers = new List<List<Dictionary<string, bool>>>();
			answers.Add(new List<Dictionary<string, bool>>());
			answers[0].Add(new Dictionary<string, bool>());
			answers[0][0].Add("Begegnungsverbot.", false);
			answers[0][0].Add("Begegnungsverbot für Fahrzeuge über 20 m Länge.", false);
			answers[0][0].Add("Überholverbot für Fahrzeuge unter 20 m Länge.", false);
			answers[0][0].Add("Überholverbot.", true);

			answers.Add(new List<Dictionary<string, bool>>());
			answers[1].Add(new Dictionary<string, bool>());
			answers[1][0].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 0,3 ‰ oder mehr im Körper vorhanden ist.", false);
			answers[1][0].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 0,5 ‰ oder mehr im Körper vorhanden ist.", true);
			answers[1][0].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 0,8 ‰ oder mehr im Körper vorhanden ist.", false);
			answers[1][0].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 1,0 ‰ oder mehr im Körper vorhanden ist.", false);

			answers.Add(new List<Dictionary<string, bool>>());
			answers[2].Add(new Dictionary<string, bool>());
			answers[2][0].Add("Wenn es weder an Land festgemacht ist noch vor Anker liegt noch Fahrt durchs Wasser macht.", false);
			answers[2][0].Add("Wenn es weder auf Grund sitzt noch vor Anker liegt noch manövrierbehindert oder manövrierunfähig ist.", false);
			answers[2][0].Add("Wenn es weder vor Anker liegt noch an Land festgemacht ist noch auf Grund sitzt.", true);
			answers[2][0].Add("Wenn es weder vor Anker liegt noch an Land festgemacht ist noch Fahrt über Grund macht.", false);

			answers.Add(new List<Dictionary<string, bool>>());
			answers[3].Add(new Dictionary<string, bool>());
			answers[3][0].Add("Weniger als 1 Sekunde.", false);
			answers[3][0].Add("Etwa 2 Sekunden.", false);
			answers[3][0].Add("Etwa 1 Sekunde.", true);
			answers[3][0].Add("Weniger als 4 Sekunden.", false);

			answers.Add(new List<Dictionary<string, bool>>());
			answers[4].Add(new Dictionary<string, bool>());
			answers[4][0].Add("Der verantwortliche Fahrzeugführer muss bestimmt werden.", true);
			answers[4][0].Add("Ein Inhaber des Sportbootführerscheins muss die Fahrzeugführung übernehmen.", false);
			answers[4][0].Add("Der verantwortliche Fahrzeugführer muss gewählt werden.", false);
			answers[4][0].Add("Ein Inhaber des Sportbootführerscheins übernimmt die Verantwortung.", false);

			for (int i = 0; i < questions.Length; i++)
			{
				this.questionnaire.AddQuestion(i + 1, questions[i], answers[i]);
			}
			return true;
		}

		/// <summary>
		/// Execute GetNextQuestion from questionnaire
		/// </summary>
		/// <returns>question</returns>
		public Question GetNextQuestion()
		{
			return this.questionnaire.GetNextQuestion();
		}

		/// <summary>
		/// Execute GetPreviousQuestion from questionnaire
		/// </summary>
		/// <returns>question</returns>
		public Question GetPreviousQuestion()
		{
			return this.questionnaire.GetPreviousQuestion();
		}

		/// <summary>
		/// Execute GetFirstQuestion from questionnaire
		/// </summary>
		/// <returns>question</returns>
		public Question GetFirstQuestion()
		{
			return this.questionnaire.GetFirstQuestion();
		}

		/// <summary>
		/// Execute GetCurrentQuestion from questionnaire
		/// </summary>
		/// <returns>question</returns>
		public Question GetCurrentQuestion()
		{
			return this.questionnaire.GetCurrentQuestion();
		}

		/// <summary>
		/// Execute Evaluate funktion form questionnaire
		/// </summary>
		/// <returns></returns>
		public double Evaluate()
		{
			return this.questionnaire.Evaluate();
		}

		//Startform functions

		/// <summary>
		/// Action if StartButton in startform is clicked
		/// hide start_form
		/// init questionform
		/// </summary>
		public void StartButtonClicked(ListBox listbox)
		{
			string select = Convert.ToString(listbox.SelectedItem);
			int selectedId = Convert.ToInt32(Regex.Match(select, "(\\d+)\\s(\\w+)").Groups[1].Value);
			string selectedQuestionnaire = Regex.Match(select, "(\\d+)\\s(\\w+)").Groups[2].Value;
			this.InitQuestionnaire(selectedId, selectedQuestionnaire);
			this.ques_form = new QuestionForm(this);
			start_form.Hide();
			ques_form.ShowDialog();
		}

		/// <summary>
		/// Action if ConfigButton in startform is clicked
		/// hide start_form
		/// set labels in configurationform
		/// init configurationform
		/// </summary>
		public void ConfigButtonClicked()
		{
			start_form.Hide();
			config_form.GetSuccessHurdleTextbox().Text = "" + this.configuration.SuccessHurdle;
			config_form.GetNameOfProgramTextbox().Text = this.configuration.NameOfProgram;
			config_form.ShowDialog();
		}

		private void SetHistoryListView()
		{
			List<string> history = GetHistoryString();
			ListView history_listview = this.start_form.GetListViewHistory();
			history_listview.Items.Clear();
			foreach (var item in history)
			{
				history_listview.Items.Add(item);
			}
		}

		//Configurationform functions

		/// <summary>
		/// Action if SaveButton in configurationform is clicked
		/// hide config_form
		/// sets configuration object to entered data
		/// sets label in start_form
		/// </summary>
		public void SaveButtonClicked()
		{
			config_form.Hide();
			string name = config_form.GetNameOfProgramTextbox().Text;
			int successHurdle = Convert.ToInt32(config_form.GetSuccessHurdleTextbox().Text);

			this.configuration.NameOfProgram = name;
			this.configuration.SuccessHurdle = successHurdle;

			this.start_form.GetNameLabel().Text = name;
			SetHistoryListView();
			start_form.Show();
		}

		public void ResetHistoryButtonClicked()
		{
			this.DeleteHistory();
		}

		//Evaluationform functions

		/// <summary>
		/// Action if BackToMenuButton in evaluationform is clicked
		/// hide evaluationform
		/// show start_form
		/// </summary>
		public void BackToMainMenuButtonClicked()
		{
			SetHistoryListView();
			eval_form.Hide();
			start_form.Show();
		}

		//Questionform functions

		/// <summary>
		/// initialise textboxes and radiobuttons for first question
		/// </summary>
		public void InitializeQuestionForm(TextBox textbox, RadioButton[] radios, PictureBox pictureBox)
		{
			this.UpdateQuestionPage(GetFirstQuestion(), textbox, radios, pictureBox);
		}

		/// <summary>
		/// initialise textboxes and radiobuttons for next question
		/// set choice for current question
		/// </summary>
		public void ForwardButtonClicked(TextBox textbox, RadioButton[] radios, PictureBox pictureBox)
		{
			SetSelectedAnswer(radios);
			CreateNextPageQuestionForm(textbox, radios, pictureBox);
		}

		/// <summary>
		/// initialise textboxes and radiobuttons for next question
		/// set choice for current question
		/// </summary>
		public void BackButtonClicked(TextBox textbox, RadioButton[] radios, PictureBox pictureBox)
		{
			SetSelectedAnswer(radios);
			CreatePreviousPageQuestionForm(textbox, radios, pictureBox);
		}

		/// <summary>
		/// set choosen answer of current question
		/// </summary>
		/// <param name="radios"></param>
		private void SetSelectedAnswer(RadioButton[] radios)
		{
			for (int i = 0; i < radios.Length; i++)
			{
				if (radios[i].Checked) {
					this.GetCurrentQuestion().AnswerQuestion(i);
				}
			}
		}

		/// <summary>
		/// initialise questionform for next question if exists
		/// else initialise evaluationform
		/// </summary>
		/// <param name="textbox"></param>
		/// <param name="radios"></param>
		private void CreateNextPageQuestionForm(TextBox textbox, RadioButton[] radios, PictureBox pictureBox)
		{
			Question q;
			if ((q = GetNextQuestion()) == null)
			{
				this.SaveResultInHistory();
				this.ques_form.Hide();
				this.eval_form.SetSuccessLabel(configuration.SuccessHurdle <= this.Evaluate());
				this.eval_form.SetResultLabel(this.questionnaire.GetEvaluateString());
				this.eval_form.SetWrongAnswerTextbox(this.questionnaire.GetWrongAnswerString());
				this.eval_form.ShowDialog();
			}
			else
			{
				this.UpdateQuestionPage(q, textbox, radios, pictureBox);
			}
		}

		private void UpdateQuestionPage(Question q, TextBox textbox, RadioButton[] radios, PictureBox pictureBox)
		{
			SetRadios(radios, q);
			for (int i = 0; i < radios.Length; i++)
			{
				radios[i].Text = q.GetAnswer(i).GetText();
			}
			textbox.Text = q.GetText();
			pictureBox.ImageLocation = q.GetPictureLocation();
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
		}

		/// <summary>
		/// initialise questionform for previous question if exists
		/// </summary>
		/// <param name="textbox"></param>
		/// <param name="radios"></param>
		private void CreatePreviousPageQuestionForm(TextBox textbox, RadioButton[] radios, PictureBox pictureBox)
		{
			Question q;
			if ((q = GetPreviousQuestion()) != null)
			{
				this.UpdateQuestionPage(q, textbox, radios, pictureBox);
			}
		}

		/// <summary>
		/// set radiobuttons like the answers of given question
		/// </summary>
		/// <param name="radios"></param>
		/// <param name="q"></param>
		private void SetRadios(RadioButton[] radios, Question q)
		{
			for (int i = 0; i < radios.Length; i++)
			{
				if (q.GetAnswer(i).IsChoosen()) {
					radios[i].Checked = true;
				} else {
					radios[i].Checked = false;
				}
			}
		}

		private void CreateHistoryTable()
		{
			using (SqlConnection connection = new SqlConnection(sqlString))
			{
				connection.Open();
				string query = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='History' AND xtype='U') CREATE TABLE History (id Integer IDENTITY(1,1) PRIMARY KEY, questionnaire_id Integer, questionnaire_name VARCHAR(30), success BIT)";
				SqlCommand command;
				using (command = new SqlCommand(query, connection)) ;
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		private List<string> GetHistoryString()
		{
			CreateHistoryTable();
			List<string> output = new List<string>();
			using (SqlConnection connection = new SqlConnection(sqlString))
			{
				string query = "SELECT questionnaire_id, questionnaire_name, success FROM History";
				SqlCommand command;
				using (command = new SqlCommand(query, connection)) ;
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string name = reader.GetString(1);
						string success = reader.GetBoolean(2) == true ? "Bestanden" : "Nicht bestanden";
						output.Add(name + " (Fragebogen " + id + ")" + " - " + success);
					}
				}
				connection.Close();
			}
			return output;
		}

		private void SaveResultInHistory()
		{
			int success = Evaluate() > this.configuration.SuccessHurdle ? 1 : 0;
			using (SqlConnection connection = new SqlConnection(sqlString))
			{
				connection.Open();
				string query = "INSERT INTO HISTORY (questionnaire_id, questionnaire_name, success) VALUES ('" + this.questionnaire.GetID() + "','" + this.configuration.NameOfProgram + "','" + success + "')";
				SqlCommand command;
				using (command = new SqlCommand(query, connection)) ;
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		private void DeleteHistory()
		{
			using (SqlConnection connection = new SqlConnection(sqlString))
			{
				connection.Open();
				string query = "TRUNCATE TABLE History";
				SqlCommand command;
				using (command = new SqlCommand(query, connection)) ;
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		private List<string> GetDictionaryIds()
		{
			List<string> dictionaryIds = new List<string>();
			using (SqlConnection connection = new SqlConnection(sqlString))
			{
				string query = "(SELECT DISTINCT(CONCAT(FragebogenNr, ' ','Binnen')) FROM T_Fragebogen_unter_Maschine) UNION (SELECT DISTINCT(CONCAT(FragebogenNr, ' ', 'Funk')) FROM T_Fragebogen_Funk_UBI)";
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						dictionaryIds.Add(""+reader.GetString(0));
					}
				}
				connection.Close();
			}
			return dictionaryIds;
		}
	}
}