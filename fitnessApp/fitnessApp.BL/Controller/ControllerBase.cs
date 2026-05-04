using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace fitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save<T>(string fileName, T obj)
        {
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<T>(file, obj, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    AllowTrailingCommas = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                });
                Console.WriteLine("Данные были записаны в файл");
            }
        }
        protected T? Load<T>(string fileName) 
        {
            if (!File.Exists(fileName) || new FileInfo(fileName).Length == 0)
                return default(T);
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                var foods = JsonSerializer.Deserialize<T>(file);
                return foods;
            }
        }
    }
}
