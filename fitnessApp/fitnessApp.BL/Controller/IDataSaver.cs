namespace fitnessApp.BL.Controller
{
    public interface IDataSaver 
    {
        public void Save<T>(List<T> item) where T : class;
        public List<T> Load<T>() where T: class;
    }
}
