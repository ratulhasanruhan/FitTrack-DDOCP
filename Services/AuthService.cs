using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FitTrack_DDOCP.Models;
using FitTrack_DDOCP.Helpers;

namespace FitTrack_DDOCP.Services
{
    public class AuthService
    {
        private List<User> users;
        private Dictionary<string, int> failedAttempts;
        private readonly string dataFilePath;

        public AuthService()
        {
            users = new List<User>();
            failedAttempts = new Dictionary<string, int>();
            
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FitTrack");
            
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }
            
            dataFilePath = Path.Combine(appDataPath, "users.dat");
            LoadUsers();
        }

        public bool Register(string username, string password, out string message)
        {
            if (!ValidationHelper.IsValidUsername(username))
            {
                message = "Username must contain only letters and numbers.";
                return false;
            }

            if (!ValidationHelper.IsValidPassword(password))
            {
                message = "Password must be 12 characters with upper and lower case letters.";
                return false;
            }

            if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                message = "Username already exists.";
                return false;
            }

            users.Add(new User(username, password));
            SaveUsers();
            message = "Registration successful.";
            return true;
        }

        public User Login(string username, string password, out string message)
        {
            if (failedAttempts.ContainsKey(username) && failedAttempts[username] >= 3)
            {
                message = "Account temporarily locked due to multiple failed attempts.";
                return null;
            }

            User user = users.FirstOrDefault(u => 
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null || !user.CheckPassword(password))
            {
                if (!failedAttempts.ContainsKey(username))
                    failedAttempts[username] = 0;

                failedAttempts[username]++;
                
                int attemptsRemaining = 3 - failedAttempts[username];
                if (attemptsRemaining > 0)
                {
                    message = $"Invalid username or password. {attemptsRemaining} attempt(s) remaining.";
                }
                else
                {
                    message = "Account temporarily locked due to multiple failed attempts.";
                }
                
                return null;
            }

            failedAttempts[username] = 0;
            message = "Login successful.";
            return user;
        }

        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => 
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateUserGoal(User user)
        {
            SaveUsers();
        }

        public void SaveUserActivities(User user)
        {
            SaveUsers();
        }

        private void SaveUsers()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(dataFilePath, false))
                {
                    foreach (User user in users)
                    {
                        string activitiesData = SerializeActivities(user.Activities);
                        string line = $"{user.Username}|{user.Password}|{user.CalorieGoal}|{user.RegistrationDate:O}|{activitiesData}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Error saving user data: {ex.Message}", 
                    "Error", 
                    System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private string SerializeActivities(List<ActivityRecord> activities)
        {
            if (activities == null || activities.Count == 0)
                return "";

            List<string> activityStrings = new List<string>();
            foreach (ActivityRecord activity in activities)
            {
                string activityData = $"{activity.ActivityType}~{activity.Metric1}~{activity.Metric2}~{activity.Metric3}~{activity.CaloriesBurned}~{activity.RecordedDate:O}";
                activityStrings.Add(activityData);
            }
            return string.Join(";", activityStrings);
        }

        private void LoadUsers()
        {
            if (!File.Exists(dataFilePath))
            {
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(dataFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length >= 4)
                        {
                            User user = new User
                            {
                                Username = parts[0],
                                Password = parts[1],
                                CalorieGoal = int.Parse(parts[2]),
                                RegistrationDate = DateTime.Parse(parts[3])
                            };

                            if (parts.Length >= 5 && !string.IsNullOrEmpty(parts[4]))
                            {
                                user.Activities = DeserializeActivities(parts[4]);
                            }

                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Error loading user data: {ex.Message}", 
                    "Error", 
                    System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private List<ActivityRecord> DeserializeActivities(string activitiesData)
        {
            List<ActivityRecord> activities = new List<ActivityRecord>();
            
            if (string.IsNullOrEmpty(activitiesData))
                return activities;

            string[] activityStrings = activitiesData.Split(';');
            foreach (string activityString in activityStrings)
            {
                if (string.IsNullOrEmpty(activityString))
                    continue;

                string[] activityParts = activityString.Split('~');
                if (activityParts.Length >= 6)
                {
                    ActivityRecord activity = new ActivityRecord
                    {
                        ActivityType = activityParts[0],
                        Metric1 = double.Parse(activityParts[1]),
                        Metric2 = double.Parse(activityParts[2]),
                        Metric3 = double.Parse(activityParts[3]),
                        CaloriesBurned = double.Parse(activityParts[4]),
                        RecordedDate = DateTime.Parse(activityParts[5])
                    };
                    activities.Add(activity);
                }
            }

            return activities;
        }
    }
}
