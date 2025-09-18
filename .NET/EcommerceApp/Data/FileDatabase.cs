using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data
{
    public class FileDatabase<T>
    {
        private readonly string _filepath;

        public FileDatabase(string filepath)
        {
            _filepath = filepath;
            if (!File.Exists(_filepath))
            { 
                File.WriteAllText(_filepath, "[]");
            }
        }

        public List<T> Load()
        {
            var json = File.ReadAllText(_filepath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void Save(List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(_filepath, json);
        }
    }
}
