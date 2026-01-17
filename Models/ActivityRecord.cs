using System;

namespace FitTrack_DDOCP.Models
{
    public class ActivityRecord
    {
        public string ActivityType { get; set; }
        public double Metric1 { get; set; }
        public double Metric2 { get; set; }
        public double Metric3 { get; set; }
        public double CaloriesBurned { get; set; }
        public DateTime RecordedDate { get; set; }

        public ActivityRecord()
        {
            RecordedDate = DateTime.Now;
        }

        public ActivityRecord(string activityType, double metric1, double metric2, double metric3, double calories)
        {
            ActivityType = activityType;
            Metric1 = metric1;
            Metric2 = metric2;
            Metric3 = metric3;
            CaloriesBurned = calories;
            RecordedDate = DateTime.Now;
        }

        public string GetMetric1Label()
        {
            switch (ActivityType)
            {
                case "Walking":
                    return "Steps";
                case "Swimming":
                    return "Laps";
                case "Running":
                    return "Distance (km)";
                case "Cycling":
                    return "Distance (km)";
                case "Skipping":
                    return "Jump Count";
                case "Yoga":
                    return "Duration (min)";
                default:
                    return "Metric 1";
            }
        }

        public string GetMetric2Label()
        {
            switch (ActivityType)
            {
                case "Walking":
                    return "Distance (km)";
                case "Swimming":
                case "Running":
                case "Cycling":
                case "Skipping":
                    return "Time (min)";
                case "Yoga":
                    return "Pose Count";
                default:
                    return "Metric 2";
            }
        }

        public string GetMetric3Label()
        {
            switch (ActivityType)
            {
                case "Walking":
                    return "Time (min)";
                case "Swimming":
                case "Running":
                case "Skipping":
                case "Yoga":
                    return "Avg Heart Rate";
                case "Cycling":
                    return "Speed (km/h)";
                default:
                    return "Metric 3";
            }
        }
    }
}