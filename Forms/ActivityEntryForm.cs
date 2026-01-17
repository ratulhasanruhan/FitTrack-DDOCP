using System;
using System.Windows.Forms;
using FitTrack_DDOCP.Models;

namespace FitTrack_DDOCP.Forms
{
    public partial class ActivityEntryForm : Form
    {
        private User currentUser;
        private double calculatedCalories;

        public ActivityEntryForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            calculatedCalories = 0;
            
            cmbActivity.SelectedIndex = 0;
        }

        private void cmbActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMetricLabels();
            ClearInputs();
            CalculateCalories();
        }

        private void UpdateMetricLabels()
        {
            string activity = cmbActivity.SelectedItem?.ToString();
            
            if (string.IsNullOrEmpty(activity))
                return;

            ActivityRecord tempRecord = new ActivityRecord { ActivityType = activity };
            
            lblMetric1.Text = tempRecord.GetMetric1Label() + ":";
            lblMetric2.Text = tempRecord.GetMetric2Label() + ":";
            lblMetric3.Text = tempRecord.GetMetric3Label() + ":";
        }

        private void ClearInputs()
        {
            txtMetric1.Clear();
            txtMetric2.Clear();
            txtMetric3.Clear();
            calculatedCalories = 0;
            lblCaloriesValue.Text = "0 kcal";
        }

        private void txtMetric_TextChanged(object sender, EventArgs e)
        {
            CalculateCalories();
        }

        private void CalculateCalories()
        {
            if (cmbActivity.SelectedItem == null)
            {
                calculatedCalories = 0;
                lblCaloriesValue.Text = "0 kcal";
                return;
            }

            double metric1, metric2, metric3;
            
            if (!double.TryParse(txtMetric1.Text, out metric1))
                metric1 = 0;
            if (!double.TryParse(txtMetric2.Text, out metric2))
                metric2 = 0;
            if (!double.TryParse(txtMetric3.Text, out metric3))
                metric3 = 0;

            string activity = cmbActivity.SelectedItem.ToString();
            calculatedCalories = CalculateCaloriesForActivity(activity, metric1, metric2, metric3);
            
            lblCaloriesValue.Text = $"{calculatedCalories:F0} kcal";
        }

        private double CalculateCaloriesForActivity(string activity, double m1, double m2, double m3)
        {
            double calories = 0;

            switch (activity)
            {
                case "Walking":
                    calories = (m1 * 0.04) + (m2 * 3.5) + (m3 * 0.5);
                    break;

                case "Running":
                    calories = (m1 * 60) + (m2 * 0.8) + (m3 * 0.1);
                    break;

                case "Swimming":
                    calories = (m1 * 35) + (m2 * 0.9) + (m3 * 0.15);
                    break;

                case "Cycling":
                    calories = (m1 * 45) + (m2 * 0.7) + (m3 * 2);
                    break;

                case "Skipping":
                    calories = (m1 * 0.1) + (m2 * 10) + (m3 * 0.12);
                    break;

                case "Yoga":
                    calories = (m1 * 3) + (m2 * 1.5) + (m3 * 0.08);
                    break;
            }

            return Math.Max(0, Math.Round(calories, 2));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbActivity.SelectedItem == null)
            {
                MessageBox.Show("Please select an activity.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double metric1, metric2, metric3;

            if (!double.TryParse(txtMetric1.Text, out metric1) || metric1 < 0)
            {
                MessageBox.Show($"Please enter a valid positive number for {lblMetric1.Text}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMetric1.Focus();
                return;
            }

            if (!double.TryParse(txtMetric2.Text, out metric2) || metric2 < 0)
            {
                MessageBox.Show($"Please enter a valid positive number for {lblMetric2.Text}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMetric2.Focus();
                return;
            }

            if (!double.TryParse(txtMetric3.Text, out metric3) || metric3 < 0)
            {
                MessageBox.Show($"Please enter a valid positive number for {lblMetric3.Text}", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMetric3.Focus();
                return;
            }

            if (calculatedCalories == 0)
            {
                DialogResult result = MessageBox.Show(
                    "The calculated calories are 0. Do you still want to save this activity?",
                    "Confirm Save",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.No)
                    return;
            }

            ActivityRecord newActivity = new ActivityRecord(
                cmbActivity.SelectedItem.ToString(),
                metric1,
                metric2,
                metric3,
                calculatedCalories
            );

            currentUser.AddActivity(newActivity);

            MessageBox.Show(
                $"Activity saved successfully!\n\nActivity: {newActivity.ActivityType}\nCalories Burned: {calculatedCalories:F0} kcal",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
