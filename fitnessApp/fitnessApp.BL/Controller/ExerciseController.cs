using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System;
using System.Diagnostics;

namespace fitnessApp.BL.Controller
{
    public class ExerciseController: ControllerBase<Exercise> 
    {
        private User user;
        public List<Exercise> Exercises { get; }
        public List<Model.Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Имя не может быть пустым");
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Model.Activity>? GetAllActivities()
        {
            return Load<Model.Activity>() ?? new List<Model.Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        public void Add((Model.Activity activity, DateTime begin, DateTime end) actTuple)
        {
            var act = Activities.SingleOrDefault(a => a.Name == actTuple.activity.Name);
            if(act == null)
            {
                Activities.Add(actTuple.activity);

                var exercise = new Exercise(actTuple.begin, actTuple.end, actTuple.activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(actTuple.begin, actTuple.end, act, user);
                Exercises.Add(exercise);
            }
            Save();

        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
