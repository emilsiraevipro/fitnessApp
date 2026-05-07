namespace fitnessApp.BL.Controller
{
    public abstract class ControllerBase<T> where T : class
    {
        private readonly IDataSaver _manager = new DatabaseSaver();
        protected void Save<T>(List<T> item) where T: class
        {
            _manager.Save(item);
        }
        protected List<T> Load<T>() where T: class
        {
            return _manager.Load<T>();
        }
    }
}
