using System;
using System.Collections.Generic;
using System.Linq;

namespace FitTrack_DDOCP.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int CalorieGoal { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<ActivityRecord> Activities { get; set; }

        public User()
        {
            RegistrationDate = DateTime.Now;
            CalorieGoal = 0;
            Activities = new List<ActivityRecord>();
        }

        public User(string username, string password) : this()
        {
            Username = username;
            Password = password;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public double GetTotalCaloriesBurned()
        {
            return Activities.Sum(a => a.CaloriesBurned);
        }

        public void AddActivity(ActivityRecord activity)
        {
            Activities.Add(activity);
        }
    }
}
