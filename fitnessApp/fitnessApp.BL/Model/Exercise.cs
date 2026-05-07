using System;

namespace fitnessApp.BL.Model
{
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public virtual ACtivity Activity { get; set; }
        public virtual User User { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public Exercise(DateTime start, DateTime finish, ACtivity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
            //check-up

        }
        public Exercise() { }
    }
}
