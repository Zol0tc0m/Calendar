using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vipief.Model
{
    public class Kalendar
    {


        public static void SaveSelectedItems(List<string> selectedItems)
        {
            
            string serializedData = JsonConvert.SerializeObject(selectedItems);

           
            File.WriteAllText("calendar_data.json", serializedData);
        }

        public static List<string> LoadSelectedItems()
        {
            if (File.Exists("calendar_data.json"))
            {
                try
                {
                    string jsonData = File.ReadAllText("calendar_data.json");
                    return JsonConvert.DeserializeObject<List<string>>(jsonData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при десериализации: " + ex.Message);
                    return new List<string>();
                }
            }
            else
            {
                Console.WriteLine("Файл calendar_data.json не найден.");
                return new List<string>();
            }
        }



    }
}
