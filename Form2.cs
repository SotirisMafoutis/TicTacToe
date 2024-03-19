using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static Triliza.TicTac;

namespace Triliza
{

    

    public class Player
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public Player(string name, string symbol)
        {

            this.Name = name;
            this.Symbol = symbol;






        }
    }



    public partial class TicTac : Form
    {
        
        public static bool SelectedOption;

        public class Scoreboard
        {
            bool or = SelectedOption;

            private int player1Score;
            private int player2Score;
            private int cpuScore;


           
            public string Player1Name { get; }
            public string Player2OrCpuName { get; }
            public Scoreboard(bool selectedOption)
            {

                ResetScores();


            }

            public void IncrementPlayer1Score()
            {
                player1Score++;
            }

            public void IncrementPlayer2OrCpuScore()
            {
                if (or)
                {
                    player2Score++;
                }
                else
                {
                    cpuScore++;
                }
            }

            public void ResetScores()
            {
                player1Score = 0;
                player2Score = 0;
                cpuScore = 0;
            }

            public int GetPlayer1Score()
            {
                return player1Score;
            }

            public int GetPlayer2OrCpuScore()
            {
                return SelectedOption ? player2Score : cpuScore;

            }
        }

        private Scoreboard scoreboard;

        Player player1 = new Player("Player 1", "X");
        Player player2 = new Player("Player 2", "O");
        Player CPU = new Player("CPU", "O");




        Random random = new Random();


        
        List<Button> buttons = new List<Button>();
        List<String> namebut = new List<string>();
        String curPlayer;
        int grid = 300;
        string a, b;
        int i = 0;
        int col = 1;
        int row = 1;
        int N;
        public Label lab1;
        int draw = 0;

        bool turn = true;

        int c = 100;

        public TicTac()
        {
            
            InitializeComponent();
            
            Rectangle screen = Screen.FromControl(this).Bounds;
            Width = screen.Width;
            Height = screen.Height;

            WindowState = FormWindowState.Maximized;



            
           
            scoreboard = new Scoreboard(SelectedOption);




        }

        private void InitializeScoreboard()
        {
           
            CreateScoreLabel(player1.Name, new Point(Restart.Location.X, Restart.Location.Y - 60));
            if (SelectedOption)
            {
                CreateScoreLabel(player2.Name, new Point(Restart.Location.X, Restart.Location.Y - 30));
            }
            else
            {
                CreateScoreLabel(CPU.Name, new Point(Restart.Location.X, Restart.Location.Y - 30));
            }
            
            scoreboard = new Scoreboard(SelectedOption);
        }

        private void CreateScoreLabel(string playerName, Point location)
        {
            Label scoreLabel = new Label();
            scoreLabel.Name = $"scoreLabel{playerName.Replace(" ", "")}";
            scoreLabel.AutoSize = true;
            scoreLabel.Left = location.X;
            scoreLabel.Top = location.Y;
            scoreLabel.Text = $"{playerName}: 0";  // Initialize the Text property with the player's score
            Controls.Add(scoreLabel);
        }

        private void UpdateScoreLabels()
        {
            UpdateScoreLabel("Player 1", scoreboard.GetPlayer1Score());
           
            UpdateScoreLabel(SelectedOption ? "Player 2" : "CPU", scoreboard.GetPlayer2OrCpuScore());
        }

        private void UpdateScoreLabel(string playerName, int score)
        {
            Label scoreLabel = Controls.Find($"scoreLabel{playerName.Replace(" ", "")}", true).FirstOrDefault() as Label;

            if (scoreLabel != null)
            {
                scoreLabel.Text = $"{playerName}: {score}";
            }
        }

        private void UpdateScoreOnWin(string playerName)
        {
            if (playerName == "Player 1")
            {
                scoreboard.IncrementPlayer1Score();
                UpdateScoreLabel(playerName, scoreboard.GetPlayer1Score());
                
            }
            else
            {
                scoreboard.IncrementPlayer2OrCpuScore();
                UpdateScoreLabel(playerName, scoreboard.GetPlayer2OrCpuScore());
            }

           
        }

        private void ResetScore(string playerName)
        {
            scoreboard.ResetScores();
            UpdateScoreLabels();
        }


        private void Button5_Click(object sender, EventArgs e)
        {




        }

        private void StartGame(bool Sel)
        {
            
            UpdateScoreLabels();
            draw = 0;



            if (Sel)
            {

                while (col <= N && row <= N)
                {
                    if (col < N)
                    {

                        Button newBut = new Button();
                        newBut.Name = "button" + i;

                        buttons.Add(newBut);

                        namebut.Add("button" + i);




                        newBut.Location = new Point(row * 100 + grid, col * 100);
                        newBut.Size = new Size(100, 100);
                        this.Controls.Add(newBut);//εμφανιζει το καθε button
                        col++;
                    }
                    else if (row <= N)
                    {
                        Button newBut = new Button();
                        newBut.Name = "Button" + i;
                        buttons.Add(newBut);




                        newBut.Location = new Point(row * 100 + grid, col * 100);
                        newBut.Size = new Size(100, 100);
                        this.Controls.Add(newBut);//εμφανιζει το καθε button
                        col = 1;
                        row++;





                    }

                    buttons[i].Click += delegate (object sender, EventArgs e)
                    {
                        draw++;

                        var button = (Button)sender;
                        if (turn)
                        {

                            curPlayer = player1.Symbol;
                            button.Text = curPlayer.ToString();
                            button.Enabled = false;
                            button.BackColor = Color.Orange;
                            turn = false;
                            Check();
                        }
                        else
                        {
                            curPlayer = player2.Symbol;
                            button.Text = curPlayer.ToString();
                            button.Enabled = false;
                            button.BackColor = Color.Cyan;
                            turn = true;
                            Check();



                        }

                        if (draw == N * N)
                        {
                            MessageBox.Show("ITS A DRAW");

                            StartGame(Sel);
                        }

                    };

                    i++;
                }

                foreach (Button x in buttons)
                {


                    x.Enabled = true;
                    x.Text = "";
                    x.BackColor = DefaultBackColor;

                }




            }
            else
            {



                while (col <= N && row <= N)
                {
                    if (col < N)
                    {

                        Button newBut = new Button();
                        newBut.Name = "button" + i;

                        buttons.Add(newBut);

                        namebut.Add("button" + i);




                        newBut.Location = new Point(row * 100 + grid, col * 100);
                        newBut.Size = new Size(100, 100);
                        this.Controls.Add(newBut);//εμφανιζει το καθε button
                        col++;
                    }
                    else if (row <= N)
                    {
                        Button newBut = new Button();
                        newBut.Name = "Button" + i;
                        buttons.Add(newBut);




                        newBut.Location = new Point(row * 100 + grid, col * 100);
                        newBut.Size = new Size(100, 100);
                        this.Controls.Add(newBut);//εμφανιζει το καθε button
                        col = 1;
                        row++;









                    }



                    buttons[i].Click += delegate (object sender, EventArgs e)
                    {

                        var button = (Button)sender;
                        if (turn)
                        {
                            curPlayer = player1.Symbol;
                            button.Text = curPlayer.ToString();
                            button.Enabled = false;
                            button.BackColor = Color.Orange;

                            turn = false;
                            draw++;
                            Check();

                        }
                        if (draw == N * N)
                        {
                            MessageBox.Show("ITS A DRAW");

                            StartGame(Sel);
                        }



                        CpuMove();


                        if (draw == N * N)
                        {
                            MessageBox.Show("ITS A DRAW");

                            StartGame(Sel);
                        }



                    };
















                    i++;


                }

                foreach (Button x in buttons)
                {


                    x.Enabled = true;
                    x.Text = "";
                    x.BackColor = DefaultBackColor;

                }




            }

        }
        private void CpuMove()
        {
            Random random = new Random();
            int index;

            do
            {
                index = random.Next(N * N);
            } while (buttons[index].Text != "");
            curPlayer = CPU.Symbol;

            buttons[index].Text = curPlayer.ToString();
            buttons[index].Enabled = false;
            buttons[index].BackColor = Color.Cyan;
            turn = true;
            draw++;
            Check();








        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void B00l(bool y)
        {
            SelectedOption = y;
        }
        public void Dimensions(string x)
        {
            a = x.ToString();

            N = int.Parse(a);






        }


        private void Check()
        {



            Horizontal("X");
            Horizontal("O");
            Vertical("X");
            Vertical("O");
            Diagonal("X");
            Diagonal("O");
            SecDiagonal("X");
            SecDiagonal("O");



        }

        private void Restart_Click(object sender, EventArgs e)
        {
            ResetScore(player1.Name);
            ResetScore(player2.Name);
            ResetScore(CPU.Name);
            StartGame(SelectedOption);

        }

        private void Horizontal(String symbol)
        {
            String paikths;
            if (symbol == "X")
            {
                paikths = "Player 1";
            }
            else
            {
                if (SelectedOption)
                {
                    paikths = "Player 2";
                }
                else
                {
                    paikths = "CPU";
                }
            }
            for (int i = 0; i < N; i++)
            {
                bool winnner = true;
                for (int j = 0; j < N; j++)
                {
                    if (buttons[j * N + i].Text != symbol)
                    {
                        winnner = false;
                        break;
                    }
                }


                if (winnner)
                {
                    MessageBox.Show(paikths, "THE WINNER IS:");

                    draw = 0;
                    UpdateScoreOnWin(paikths);
                    StartGame(SelectedOption);

                }


            }



        }









        private void Vertical(String symbol)
        {
            String paikths;
            if (symbol == "X")
            {
                paikths = "Player 1";
            }
            else
            {
                if (SelectedOption)
                {
                    paikths = "Player 2";
                }
                else
                {
                    paikths = "CPU";
                }
            }
            int counter = 0;
            int fastc = 0;
            int i = 0;
            int j = 0;
            for (j = 0; j < N * N; j++)
            {
                fastc++;
                if (buttons[j].Text == symbol)
                {
                    counter++;
                    if (counter == N)
                    {
                        MessageBox.Show(paikths, "THE WINNER IS:");

                        draw = 0;
                        UpdateScoreOnWin(paikths);
                        StartGame(SelectedOption);


                    }
                }
                else
                {
                    counter = 0;
                }
                if (fastc % N == 0)
                {
                    counter = 0;
                }





            }


        }
        private void Diagonal(String symbol)
        {
            String paikths;
            if (symbol == "X")
            {
                paikths = "Player 1";
            }
            else
            {
                if (SelectedOption)
                {
                    paikths = "Player 2";
                }
                else
                {
                    paikths = "CPU";
                }
            }
            bool diagonalWin1 = true;
            for (int i = 0; i < N; i++)
            {
                if (buttons[i * N + i].Text != symbol)
                {
                    diagonalWin1 = false;
                    break;
                }
            }
            if (diagonalWin1)
            {
                MessageBox.Show(paikths, "THE WINNER IS:");
                UpdateScoreOnWin(paikths);
                draw = 0;

                StartGame(SelectedOption);

            }











        }
        private void SecDiagonal(String symbol)
        {

            String paikths;
            if (symbol == "X")
            {
                paikths = "Player 1";
            }

            else
            {
                if (SelectedOption)
                {
                    paikths = "Player 2";
                }
                else
                {
                    paikths = "CPU";
                }
            }
            bool diagonalWin2 = true;
            for (int i = 0; i < N; i++)
            {
                if (buttons[(N - 1) * (i + 1)].Text != symbol)
                {
                    diagonalWin2 = false;
                    break;
                }
            }
            if (diagonalWin2)
            {
                MessageBox.Show(paikths, "THE WINNER IS:");

                draw = 0;
                UpdateScoreOnWin(paikths);
                StartGame(SelectedOption);
            }





        }

        private void TicTac_Load(object sender, EventArgs e)
        {
            InitializeScoreboard();
            StartGame(SelectedOption);
        }

    }

}