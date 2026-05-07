using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace fitnessApp.BL.Controller
{
    class SerializableSaver : IDataSaver
    {
        List<T> IDataSaver.Load<T>()
        {
            var fileName = typeof(T).Name;
            if (!File.Exists(fileName) || new FileInfo(fileName).Length == 0)
                return new List<T>();
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var items = JsonSerializer.Deserialize<List<T>>(file);
                return items;
            }
        }

        void IDataSaver.Save<T>(List<T> item)
        {
            var fileName = typeof(T).Name;
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(file, item, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    AllowTrailingCommas = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                });
                Console.WriteLine("Данные были записаны в файл");
            }
        }
    }
}
