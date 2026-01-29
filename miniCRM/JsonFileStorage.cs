using Newtonsoft.Json;

namespace miniCRM
{
    public class JsonFileStorage<T> : IStorage<T>
    {
        private readonly string _path;

        public JsonFileStorage(string filePath)
        {
            _path = filePath;
        }

        public List<T> Load()
        {
            if (!File.Exists(_path))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        public async Task SaveAsync(List<T> items)
        {
            var json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(_path, json);
        }
    }
}