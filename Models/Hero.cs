using System;

namespace Heroes.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ability { get; set; }

        public DateTime StartedTrainingDate { get; set; }

        public string SuitColors { get; set; }

        public int StartingPower { get; set; }

        public int CurrentPower { get; set; }

        public int RemainingTrains { get; set; }

        public User User { get; set; }
    }
}
