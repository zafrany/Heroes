using System;
using System.ComponentModel.DataAnnotations;

namespace Heroes.Models
{
    public class Hero
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ability { get; set; }

        [Required]
        public DateTime StartedTrainingDate { get; set; }

        [Required]
        public DateTime LastTrainingDate { get; set; }

        [Required]
        public string SuitColors { get; set; }

        [Required]
        public double StartingPower { get; set; }

        [Required]
        public double CurrentPower { get; set; }

        [Required]
        public int RemainingTrains { get; set; }

        public User User { get; set; }
    }
}
