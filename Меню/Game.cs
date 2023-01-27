using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Игра.Properties;

namespace Игра
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            Initialization();
            GameInitialize();
            Record.Items[^countQuestion].UseItemStyleForSubItems = false;
        }

        readonly Random random = new Random();
        readonly string questionsOut = Resources.questions;
        readonly string answersOut = Resources.answers;
        readonly string trueAnswersOut = Resources.true_answers;
        List<string> questions = new List<string>();
        List<string> answers = new List<string>();
        List<string[]> answersToQuestion = new List<string[]>();
        List<string> trueAnswers = new List<string>();
        public void Initialization()
        {
            questions = questionsOut.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            answers = answersOut.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            trueAnswers = trueAnswersOut.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int countAnswers = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                string[] otveti = new string[4];
                for (int j = 0; j < 4; j++)
                {
                    otveti[j] = answers[countAnswers];
                    countAnswers++;
                }
                answersToQuestion.Add(otveti);
            }
        }

        bool flagA = false, flagB = false, flagC = false, flagD = false;
        int countQuestion = 0;
        readonly int[] balance = { 500, 1000, 2000, 3000, 5000, 10000, 15000, 25000, 50000, 100000, 200000, 400000, 800000, 1500000, 3000000 };
        int balanceSave;
        int balanceIndex = 0;

        public void GameInitialize()
        {
            ++countQuestion;
            try
            {
                Record.Items[^countQuestion].BackColor = Color.SkyBlue;
            }
            catch
            {

            }
            questionNumber.Text = $"Вопрос № {countQuestion}";
            int indexQuestion = random.Next(questions.Count);
            string selectedAnswer = trueAnswers[indexQuestion];
            Question.Text = (questions[indexQuestion]);
            Button[] buttons = { Answer_A, Answer_B, Answer_C, Answer_D };
            string[] answers = new string[4];
            List<int> answersIndex = new List<int>{ 0, 1, 2, 3 };
            for (int i = 0; i < 4; i++)
            {
                int randomIndex = answersIndex[random.Next(answersIndex.Count)];
                answers[i] = answersToQuestion[indexQuestion][i];
                buttons[randomIndex].Text = answers[i];
                answersIndex.Remove(randomIndex);
            }
            if (buttons[0].Text == selectedAnswer)
            {
                flagA = true;
            }
            else if (buttons[1].Text == selectedAnswer)
            {
                flagB = true;
            }
            else if (buttons[2].Text == selectedAnswer)
            {
                flagC = true;
            }
            else if (buttons[3].Text == selectedAnswer)
            {
                flagD = true;
            }
            questions.Remove(questions[indexQuestion]);
            answersToQuestion.Remove(answersToQuestion[indexQuestion]);
            trueAnswers.Remove(trueAnswers[indexQuestion]);
        }

        private void SaveBalance()
        {
            if (balance[balanceIndex] == 5000 || balance[balanceIndex] == 100000)
            {
                Record.Items[^countQuestion].BackColor = Color.Blue;
                balanceSave = balance[balanceIndex];
                MessageBox.Show($"Вы достигли сохраняемого баланса - {balance[balanceIndex]} рубелей!", "Поздравляю");
            }
        }
        private void WinnerNameInput()
        {
            Winner winner = new Winner();
            winner.Show();
            winner.Location = this.Location;
            this.Close();

        }

        private void Win()
        {
            DialogResult result = MessageBox.Show($"Вы миллионер!\nХотите вписать своё имя?", "Поздравляю с победой!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                WinnerNameInput();
                this.Close();
            }
            else
            {
                Back();
            }
        }

        private void Loss()
        {
            if (balanceSave > 0)
            {
                MessageBox.Show($"Спасибо за участие!\nСохранённый выигрыш = {balanceSave} рубелей", "Неправильно");
            }
            else
            {
                MessageBox.Show("Спасибо за участие!", "Неправильно");
            }
            Back();
        }

        private void Recolor()
        {
            if (Record.Items[^countQuestion].BackColor != Color.Blue)
            {
                Record.Items[^countQuestion].BackColor = Color.Transparent;
            }
        }

        private void Back()
        {
            Menu menu = new Menu();
            menu.Show();
            menu.Location = this.Location;
            this.Close();
        }

        private void AnswerClick(Button Answer, bool flag)
        {
            if (flag)
            {
                Answer.BackColor = Color.Green;
                if (balance[balanceIndex] == 3000000)
                {
                    Win();
                }
                else
                {
                    SaveBalance();
                    DialogResult result = MessageBox.Show($"Продолжить?", "Правильно", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (countQuestion >= 15)
                        {
                            Win();
                        }
                        else
                        {
                            balanceIndex++;
                            Answer.BackColor = Color.Transparent;
                            Recolor();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Ваш результат = {balance[balanceIndex]} рубелей", "Спасибо за участие!");
                        Back();
                    }
                }
            }
            else
            {
                Answer.BackColor = Color.Red;
                Loss();
            }
            VisibleButtons();
            Question.Focus();
        }

        private void VisibleButtons()
        {
            Button[] buttons = { Answer_A, Answer_B, Answer_C, Answer_D };
            for (int i = 0; i < 4; i++)
            {
                buttons[i].Visible = true;
            }
        }

        private void FiftyFifty_Click(object sender, EventArgs e)
        {
            bool[] flags = { flagA, flagB, flagC, flagD };
            bool[] visibles = new bool[4];
            flags.CopyTo(visibles, 0);
            int correctAnswerIndex = Array.IndexOf(visibles, true);
            visibles[correctAnswerIndex == 0 ? correctAnswerIndex + 1 : correctAnswerIndex - 1] = true;
            Button[] buttons = { Answer_A, Answer_B, Answer_C, Answer_D };
            for (int i = 0; i < 4; i++)
            {
                buttons[i].Visible = visibles[i];
            }
            FiftyFifty.Visible = false;
        }

        private void CallFriend_Click(object sender, EventArgs e)
        {
            bool[] flags = { flagA, flagB, flagC, flagD };
            Button[] buttons = { Answer_A, Answer_B, Answer_C, Answer_D };
            for (int i = 0; i < 4; i++)
            {
                if (flags[i])
                {
                    MessageBox.Show($"Я думаю, что правильный ответ - {buttons[i].Text}");
                }
            }
            CallFriend.Visible = false;
        }

        private void Answer_A_Click(object sender, EventArgs e)
        {
            AnswerClick(Answer_A, flagA);
            ResetText();
            flagA = false;
            GameInitialize();
        }

        private void Answer_B_Click(object sender, EventArgs e)
        {
            AnswerClick(Answer_B, flagB);
            ResetText();
            flagB = false;
            GameInitialize();
        }

        private void Answer_C_Click(object sender, EventArgs e)
        {
            AnswerClick(Answer_C, flagC);
            ResetText();
            flagC = false;
            GameInitialize();
        }

        private void Answer_D_Click(object sender, EventArgs e)
        {
            AnswerClick(Answer_D, flagD);
            ResetText();
            flagD = false;
            GameInitialize();
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            menu.Location = this.Location;
            this.Close();
        }

        private void FinishButton_MouseEnter(object sender, EventArgs e)
        {
            FinishButton.ForeColor = Color.White;
            FinishButton.BackColor = Color.Red;
        }

        private void FinishButton_MouseLeave(object sender, EventArgs e)
        {
            FinishButton.ForeColor = Color.Black;
            FinishButton.BackColor = Color.Transparent;
        }

        Point lastPoint;

        private void Background_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Background_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}