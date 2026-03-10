using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace robot_11_3_Storchevaya
{
    public partial class GameRobot : Form
    {
        public GameRobot()
        {
            InitializeComponent();
        }

        private void Robot_Load(object sender, EventArgs e)
        {

        }
        private int GetLife(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return 0;

            if (int.TryParse(textBox.Text, out int result))
                return result;

            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GameRobot[] team = new GameRobot[3];
                for (int i = 0; i < 3; i++)
                {
                    team[i] = new GameRobot();
                }
                int value1 = GetLife(textBox1);
                int value2 = GetLife(textBox2);
                int value3 = GetLife(textBox3);
                lifeLabel1.Text = value1.ToString();
                lifeLabel2.Text = value2.ToString();
                lifeLabel3.Text = value3.ToString();
                team[0].kollife = value1;
                team[1].kollife = value2;
                team[2].kollife = value3;
                int leaderPosition = 0;
                int leaderHealth = team[0].kollife;
                for (int i = 1; i < 3; i++)
                {
                    if (team[i].kollife > leaderHealth)
                    {
                        leaderHealth = team[i].kollife;
                        leaderPosition = i;
                    }
                }
                int healthBefore = leaderHealth;
                team[leaderPosition].Min(team[leaderPosition].kollife);
                int healthLost = healthBefore - team[leaderPosition].kollife;
                double lossPercentage = 0;
                if (healthBefore > 0)
                {
                    lossPercentage = ((double)healthLost / healthBefore) * 100;
                    lossPercentage = Math.Round(lossPercentage, 1);
                }
                int compensation = 0;
                if (lossPercentage >= 50)
                    compensation = 30;
                else if (lossPercentage >= 30)
                    compensation = 20;
                for (int i = 0; i < 3; i++)
                {
                    if (i != leaderPosition)
                    {
                        team[i].Kol(healthBefore, team[leaderPosition].kollife);
                    }
                }
                textBox1.Text = team[0].kollife.ToString();
                textBox2.Text = team[1].kollife.ToString();
                textBox3.Text = team[2].kollife.ToString();
                label2.Text = "Робот 1 после игры: " + team[0].kollife;
                if (leaderPosition == 0)
                    label2.Text += " (потеря " + lossPercentage + "%)";
                if (leaderPosition != 0 && compensation > 0)
                    label2.Text += " (+" + compensation + " бонус)";
                label8.Text = "Робот 2 после игры: " + team[1].kollife;
                if (leaderPosition == 1)
                    label8.Text += " (потеря " + lossPercentage + "%)";
                if (leaderPosition != 1 && compensation > 0)
                    label8.Text += " (+" + compensation + " бонус)";
                label9.Text = "Робот 3 после игры: " + team[2].kollife;
                if (leaderPosition == 2)
                    label9.Text += " (потеря " + lossPercentage + "%)";
                if (leaderPosition != 2 && compensation > 0)
                    label9.Text += " (+" + compensation + " бонус)";
            }
            catch
            {
                MessageBox.Show("ошибка ввода");
            }
        }
}
}
