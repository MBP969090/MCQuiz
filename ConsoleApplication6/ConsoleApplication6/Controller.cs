using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication6
{
	public class Controller
	{
		Questionaire questionaire;
        ConfigurationForm config_form;
        QuestionForm ques_form;
        EvaluationForm eval_form;
        StartForm start_form;

		public Controller()
		{
            this.config_form = new ConfigurationForm(this);
            this.eval_form = new EvaluationForm();
            this.start_form = new StartForm(this);
            this.start_form.ShowDialog();
		}

		public bool InitQuestionaire(int id)
		{
			bool success = false;
			this.questionaire = new Questionaire(id);
			using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4DTNI3N;Initial Catalog=master;Integrated Security=true;"))
			//using (SqlConnection connection = new SqlConnection("Data Source=KrebsDB015;Initial Catalog=master;User id=Krebs015;Password=pKrebs015"))
			{
				string query = "SELECT FragebogenNr, P_Id, Frage, Antwort1, Antwort2, Antwort3, Antwort4, RichtigeAntwort FROM T_Fragebogen_unter_Maschine LEFT JOIN T_SBF_Binnen ON (F_Id_SBF_Binnen=P_id) WHERE FragebogenNr=" + id;
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3) && !reader.IsDBNull(4) && !reader.IsDBNull(5) && !reader.IsDBNull(6) && !reader.IsDBNull(7))
						{
							success = true;
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
								} catch (ArgumentException e)
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
			return success;
		}

		public bool InitDemoQuestionaire()
		{
			this.questionaire = new Questionaire(1);
			string[] questions = new string[5];
			questions[0] = "Was ist zu tun, wenn vor Antritt der Fahrt nicht feststeht, wer Fahrzeugführer ist?";
			questions[1] = "In welchen Fällen darf weder ein Sportboot geführt noch dessen Kurs oder Geschwindigkeit selbstständig bestimmt werden?";
			questions[2] = "Wann ist ein Fahrzeug in Fahrt?";
			questions[3] = "Wie lang ist die Dauer eines kurzen Tons(•) ?";
			questions[4] = "Welche Bedeutung hat folgendes Tafelzeichen ?  {Binnen17.gif}";

			Dictionary<string, bool>[] answers = new Dictionary<string, bool>[5];
			answers[0] = new Dictionary<string, bool>();
			answers[0].Add("Der verantwortliche Fahrzeugführer muss bestimmt werden.", true);
			answers[0].Add("Ein Inhaber des Sportbootführerscheins muss die Fahrzeugführung übernehmen.", false);
			answers[0].Add("Der verantwortliche Fahrzeugführer muss gewählt werden.", false);
			answers[0].Add("Ein Inhaber des Sportbootführerscheins übernimmt die Verantwortung.", false);

			answers[1] = new Dictionary<string, bool>();
			answers[1].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 0,3 ‰ oder mehr im Körper vorhanden ist.", false);
			answers[1].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 0,5 ‰ oder mehr im Körper vorhanden ist.", true);
			answers[1].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 0,8 ‰ oder mehr im Körper vorhanden ist.", false);
			answers[1].Add("Wenn man infolge körperlicher oder geistiger Mängel oder infolge des Genusses alkoholischer Getränke oder anderer berauschender Mittel in der sicheren Führung behindert ist oder wenn eine Blutalkoholkonzentration von 1,0 ‰ oder mehr im Körper vorhanden ist.", false);

			answers[2] = new Dictionary<string, bool>();
			answers[2].Add("Wenn es weder an Land festgemacht ist noch vor Anker liegt noch Fahrt durchs Wasser macht.", false);
			answers[2].Add("Wenn es weder auf Grund sitzt noch vor Anker liegt noch manövrierbehindert oder manövrierunfähig ist.", false);
			answers[2].Add("Wenn es weder vor Anker liegt noch an Land festgemacht ist noch auf Grund sitzt.", true);
			answers[2].Add("Wenn es weder vor Anker liegt noch an Land festgemacht ist noch Fahrt über Grund macht.", false);

			answers[3] = new Dictionary<string, bool>();
			answers[3].Add("Weniger als 1 Sekunde.", false);
			answers[3].Add("Etwa 2 Sekunden.", false);
			answers[3].Add("Etwa 1 Sekunde.", true);
			answers[3].Add("Weniger als 4 Sekunden.", false);

			answers[4] = new Dictionary<string, bool>();
			answers[4].Add("Begegnungsverbot.", false);
			answers[4].Add("Begegnungsverbot für Fahrzeuge über 20 m Länge.", false);
			answers[4].Add("Überholverbot für Fahrzeuge unter 20 m Länge.", false);
			answers[4].Add("Überholverbot.", true);
			for (int i = 0; i < questions.Length; i++)
			{
				this.questionaire.AddQuestion(i+1, questions[i], answers[i]);
			}
            Console.WriteLine("BLA");
			return true;
		}
		
		public Question GetNextQuestion()
		{
			return this.questionaire.GetNextQuestion();
		}

        public Question GetPreviousQuestion()
        {
            return this.questionaire.GetPreviousQuestion();
        }

		public Question GetFirstQuestion()
		{
			return this.questionaire.GetFirstQuestion();
		}

        public Question GetCurrentQuestion()
        {
            return this.questionaire.GetCurrentQuestion();
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

		public Questionaire GetQuestionaire()
		{
			return this.questionaire;
		}
     

        //Startform functions
        public void StartButtonClicked()
        {
            this.InitDemoQuestionaire();
            this.ques_form = new QuestionForm(this);
            start_form.Hide();
            ques_form.ShowDialog();
        }

        public void ConfigButtonClicked()
        {
            start_form.Hide();
            config_form.ShowDialog();
        }

        //Configurationform functions
        public void SaveButtonClicked()
        {
            config_form.Hide();
            start_form.Show();
        }

        //Questionform functions
        public void InitializeQuestionForm(TextBox textbox, RadioButton[] radios)
        {
            textbox.Text = GetFirstQuestion().GetText();
            for (int i = 0; i < radios.Length; i++)
            {
                radios[i].Text = GetFirstQuestion().GetAnswer(i).ToString();
            }
        }

        public void ForwardButtonClicked(TextBox textbox, RadioButton[] radios)
        {
            SetSelectedAnswer(radios);
            CreateNextPageQuestionForm(textbox, radios);
        }

        public void BackButtonClicked(TextBox textbox, RadioButton[] radios)
        {
            SetSelectedAnswer(radios);
            CreatePreviousPageQuestionForm(textbox, radios);
        }

        private void SetSelectedAnswer(RadioButton[] radios)
        {
            for (int i = 0; i < radios.Length; i++)
            {
                if(radios[i].Checked){
                    this.GetCurrentQuestion().AnswerQuestion(i);
                }
            }
        }

        private void CreateNextPageQuestionForm(TextBox textbox, RadioButton[] radios)
        {
            Question q;
            if ((q = GetNextQuestion()) == null)
            {
                this.ques_form.Hide();
                this.eval_form.setStartForm(this.start_form);
                this.eval_form.ShowDialog();
            }
            else
            {
                SetRadios(radios, q);
                for (int i = 0; i < radios.Length; i++)
                {
                    radios[i].Text = q.GetAnswer(i).ToString();
                }
                textbox.Text = q.GetText();
            }
        }

        private void CreatePreviousPageQuestionForm(TextBox textbox, RadioButton[] radios)
        {
            Question q;
            if ((q = GetPreviousQuestion()) != null)
            {
                SetRadios(radios, q);
                for (int i = 0; i < radios.Length; i++)
                {
                    radios[i].Text = q.GetAnswer(i).ToString();
                }
                textbox.Text = q.GetText();
            }
        }

        private void SetRadios(RadioButton[] radios, Question q)
        {
            for (int i = 0; i < radios.Length; i++)
            {
                if(q.GetAnswer(i).IsChoosen()){
                    radios[i].Checked = true;
                } else{
                    radios[i].Checked = false;
                }
            }
        }
	}
}
