using Newtonsoft.Json;

namespace Directory
{
    internal class Program
    {
        static string PathString = Path.GetFullPath(Path.Combine("..", "..", "..", "Files", "Names.json"));

        static void Main(string[] args)
        {
            Add("Nicat");
            Add("Azad");
            Add("Max");
            Console.WriteLine(Search("Nicat"));
            Delete(0);
            Console.WriteLine(Search("Nicat"));
            Console.WriteLine(Search("Max"));
        }

        static void Add(string name)
        {
            List<string> names = new List<string>();

            using (StreamReader sr = new StreamReader(PathString))
            {
                string json = sr.ReadToEnd();
                names = JsonConvert.DeserializeObject<List<string>>(json);

                if (names == null)
                {
                    names = new List<string>();
                }
            }

            names.Add(name);

            using (StreamWriter sw = new StreamWriter(PathString))
            {
                string updatedJson = JsonConvert.SerializeObject(names);
                sw.Write(updatedJson);
            }
        }

        static bool Search(string name)
        {
            List<string> names = new List<string>();

            using (StreamReader sr = new StreamReader(PathString))
            {
                string json = sr.ReadToEnd();
                names = JsonConvert.DeserializeObject<List<string>>(json);
            }

            return names.Exists(n => n.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        static void Delete(int index)
        {
            List<string> names = new List<string>();

            using (StreamReader sr = new StreamReader(PathString))
            {
                string json = sr.ReadToEnd();
                names = JsonConvert.DeserializeObject<List<string>>(json);
            }

            if (index >= 0 && index < names.Count)
            {
                names.RemoveAt(index);

                using (StreamWriter sw = new StreamWriter(PathString))
                {
                    string updatedJson = JsonConvert.SerializeObject(names);
                    sw.Write(updatedJson);
                }
            }
        }
    }
}


