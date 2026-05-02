namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
    class Numbers
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 6; i++)
            {
                yield return i * i;
            }
        }
    }
}
