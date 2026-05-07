namespace fitnessApp.BL.Controller
{
    public interface IDataSaver<T> where T : class
    {
        public void Save(T item);
        public T Load( );
    }
}
