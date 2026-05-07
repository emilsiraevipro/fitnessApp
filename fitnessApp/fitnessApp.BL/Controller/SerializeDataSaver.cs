using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace fitnessApp.BL.Controller
{
    class SerializeDataSaver<T> : IDataSaver<T>
    {
        T IDataSaver<T>.Load()
        {
            var fileName = typeof(T) + ".json";
            if (!File.Exists(fileName) || new FileInfo(fileName).Length == 0)
                return default(T);
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var foods = JsonSerializer.Deserialize<T>(file);
                return foods;
            }
        }

        void IDataSaver<T>.Save(T item)
        {
            var fileName = typeof(T) + ".json";
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
