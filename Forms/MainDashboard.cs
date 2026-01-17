using System;
using System.Windows.Forms;
using FitTrack_DDOCP.Models;
using FitTrack_DDOCP.Services;

namespace FitTrack_DDOCP.Forms
{
    public partial class MainDashboard : Form
    {
        private User currentUser;
        private AuthService authService;

        public MainDashboard(string username)
        {
            InitializeComponent();
            authService = new AuthService();
            currentUser = authService.GetUser(username);
            
            if (currentUser == null)
            {
                MessageBox.Show("Error loading user data.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            InitializeUserInterface();
        }

        private void InitializeUserInterface()
        {
            lblWelcome.Text = $"Welcome, {currentUser.Username}";
            
            if (currentUser.CalorieGoal == 0)
            {
                lblGoal.Text = "Daily Calorie Goal: Not Set";
                ShowSetGoalPrompt();
            }
            else
            {
                lblGoal.Text = $"Daily Calorie Goal: {currentUser.CalorieGoal} kcal";
            }
            
            UpdateProgressDisplay();
        }

        private void ShowSetGoalPrompt()
        {
            DialogResult result = MessageBox.Show(
                "You haven't set a daily calorie goal yet. Would you like to set one now?",
                "Set Calorie Goal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SetCalorieGoal();
            }
        }

        private void SetCalorieGoal()
        {
            using (Form goalForm = new Form())
            {
                goalForm.Text = "Set Calorie Goal";
                goalForm.Width = 350;
                goalForm.Height = 180;
                goalForm.StartPosition = FormStartPosition.CenterParent;
                goalForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                goalForm.MaximizeBox = false;
                goalForm.MinimizeBox = false;

                Label lblPrompt = new Label
                {
                    Text = "Enter your daily calorie goal:",
                    Left = 20,
                    Top = 20,
                    Width = 300,
                    Font = new System.Drawing.Font("Segoe UI", 10F)
                };

                NumericUpDown numGoal = new NumericUpDown
                {
                    Left = 20,
                    Top = 50,
                    Width = 290,
                    Minimum = 100,
                    Maximum = 5000,
                    Value = 300,
                    Increment = 50,
                    Font = new System.Drawing.Font("Segoe UI", 11F)
                };

                Button btnOk = new Button
                {
                    Text = "Set Goal",
                    Left = 150,
                    Top = 90,
                    Width = 80,
                    Height = 35,
                    BackColor = System.Drawing.Color.FromArgb(0, 121, 107),
                    ForeColor = System.Drawing.Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
                };

                Button btnCancel = new Button
                {
                    Text = "Cancel",
                    Left = 240,
                    Top = 90,
                    Width = 70,
                    Height = 35,
                    DialogResult = DialogResult.Cancel
                };

                btnOk.Click += (sender, e) =>
                {
                    currentUser.CalorieGoal = (int)numGoal.Value;
                    authService.UpdateUserGoal(currentUser);
                    lblGoal.Text = $"Daily Calorie Goal: {currentUser.CalorieGoal} kcal";
                    UpdateProgressDisplay();
                    goalForm.DialogResult = DialogResult.OK;
                    goalForm.Close();
                };

                goalForm.Controls.Add(lblPrompt);
                goalForm.Controls.Add(numGoal);
                goalForm.Controls.Add(btnOk);
                goalForm.Controls.Add(btnCancel);
                goalForm.AcceptButton = btnOk;
                goalForm.CancelButton = btnCancel;

                goalForm.ShowDialog(this);
            }
        }

        private void UpdateProgressDisplay()
        {
            double totalCaloriesBurned = currentUser.GetTotalCaloriesBurned();
            lblTotalCalories.Text = $"Total Calories Burned: {totalCaloriesBurned:F0} kcal";

            if (currentUser.CalorieGoal > 0)
            {
                int progress = (int)((double)totalCaloriesBurned / currentUser.CalorieGoal * 100);
                progress = Math.Min(progress, 100);
                progressBar.Value = progress;
                lblProgressPercentage.Text = $"Progress: {progress}%";

                if (totalCaloriesBurned >= currentUser.CalorieGoal)
                {
                    lblStatus.Text = "Status: Goal Achieved ?";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblStatus.Text = "Status: Goal Not Achieved ?";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(211, 47, 47);
                }
            }
            else
            {
                progressBar.Value = 0;
                lblProgressPercentage.Text = "Progress: --";
                lblStatus.Text = "Status: Please set a calorie goal";
                lblStatus.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            ActivityEntryForm activityForm = new ActivityEntryForm(currentUser);
            DialogResult result = activityForm.ShowDialog(this);
            
            if (result == DialogResult.OK)
            {
                authService.SaveUserActivities(currentUser);
                UpdateProgressDisplay();
            }
        }

        private void btnViewProgress_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm(currentUser);
            progressForm.ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Authentication authForm = new Authentication();
                authForm.Show();
            }
        }

        private void lblAppTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
