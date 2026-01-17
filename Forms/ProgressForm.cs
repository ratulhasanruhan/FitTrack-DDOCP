using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FitTrack_DDOCP.Models;

namespace FitTrack_DDOCP.Forms
{
    public partial class ProgressForm : Form
    {
        private User currentUser;

        public ProgressForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadActivities();
            DisplaySummary();
        }

        private void LoadActivities()
        {
            dgvActivities.Rows.Clear();

            if (currentUser.Activities == null || currentUser.Activities.Count == 0)
            {
                return;
            }

            foreach (ActivityRecord activity in currentUser.Activities)
            {
                string metricsText = GetMetricsSummary(activity);
                string caloriesText = $"{activity.CaloriesBurned:F0} kcal";

                dgvActivities.Rows.Add(
                    activity.ActivityType,
                    metricsText,
                    caloriesText
                );
            }

            if (dgvActivities.Rows.Count == 0)
            {
                dgvActivities.Rows.Add("No activities", "Get started by adding an activity!", "0 kcal");
            }
        }

        private string GetMetricsSummary(ActivityRecord activity)
        {
            string metric1Label = activity.GetMetric1Label();
            string metric2Label = activity.GetMetric2Label();
            string metric3Label = activity.GetMetric3Label();

            return $"{metric1Label}: {activity.Metric1:F0}, {metric2Label}: {activity.Metric2:F0}, {metric3Label}: {activity.Metric3:F0}";
        }

        private void DisplaySummary()
        {
            double totalCalories = currentUser.GetTotalCaloriesBurned();
            
            lblTotalCalories.Text = $"Total Calories Burned: {totalCalories:F0} kcal";
            
            if (currentUser.CalorieGoal > 0)
            {
                lblGoal.Text = $"Goal: {currentUser.CalorieGoal} kcal";

                if (totalCalories >= currentUser.CalorieGoal)
                {
                    lblStatus.Text = "Status: Goal Achieved ?";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblStatus.Text = "Status: Goal Not Achieved ?";
                    lblStatus.ForeColor = Color.FromArgb(211, 47, 47);
                }
            }
            else
            {
                lblGoal.Text = "Goal: Not Set";
                lblStatus.Text = "Status: Please set a calorie goal";
                lblStatus.ForeColor = Color.Gray;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
