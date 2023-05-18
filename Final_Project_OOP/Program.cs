using System.Runtime.Serialization.Json;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Final_Project_OOP
{
    internal class Program
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            string Readepath1 = @"C:\Users\Користувач\Desktop\Final_Project_OOP\Final_Project_OOP\Read.txt";
            string Writepath1 = @"C:\Users\Користувач\Desktop\Final_Project_OOP\Final_Project_OOP\Sorted.txt";
            string Writepath2 = @"C:\Users\Користувач\Desktop\Final_Project_OOP\Final_Project_OOP\NameCost.txt";

            List<ElectricalAppliance> appliances = new List<ElectricalAppliance>();

            try
            {
                using (StreamReader reader = new StreamReader(Readepath1))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] data = line.Split(',');

                        string name = data[0];
                        string brand = data[1];
                        int price = int.Parse(data[2]);

                        if (name == "DustTrain")
                        {
                            int power = int.Parse(data[3]);
                            string color = data[4];
                            appliances.Add(new DustTrain(name, brand, price, power, color));
                            log.Debug("Added new DustTrain");
                        }
                        else if (name == "WashingMachine")
                        {
                            int programsCount = int.Parse(data[3]);
                            int capacity = int.Parse(data[4]);
                            appliances.Add(new WashingMachine(name, brand, price, programsCount, capacity));
                            log.Debug("Added new WashingMachine");
                        }
                        else if (name == "Combine")
                        {
                            int power = int.Parse(data[3]);
                            int functionsCount = int.Parse(data[4]);
                            appliances.Add(new Combine(name, brand, price, power, functionsCount));
                            log.Debug("Added new Combine");
                        }
                    }

                }
            }catch (Exception ex) 
            {
                log.Error(ex.Message);
            }

            int CountDustTrain = 0;
            int CountWashingMachine = 0;
            int CountCombine = 0;

            appliances.Sort((x, y) => x.Name.CompareTo(y.Name));
            using (StreamWriter sw = new StreamWriter(Writepath1))
            {
                foreach (ElectricalAppliance device in appliances)
                {
                    if (device.Name == "DustTrain")
                        CountDustTrain += device.Count(device.Name);
                    else if (device.Name == "WashingMachine")
                    {
                        CountWashingMachine += device.Count(device.Name);
                    }
                    else if (device.Name == "Combine")
                        CountCombine += device.Count(device.Name);

                    sw.WriteLine($"{device} ");

                }
                sw.WriteLine($"Count of DustTrain: {CountDustTrain}, count of WashingMachine: {CountWashingMachine}, count of Combine: {CountCombine} ");
            }

            int cost = 0;

            using (StreamWriter sw = new StreamWriter(Writepath2))
            {
                foreach (ElectricalAppliance device in appliances)
                {
                    
                    if (device.Mark == "bosh")
                    {
                        cost += device.Cost;
                        sw.WriteLine($"Mark: {device.Mark}, name: {device.Name}");
                    }
                    
                    

                }
                sw.WriteLine($"All device of this mark cost: {cost}$");
            }

            Stream file = new FileStream("ElectricalAppliance.json", FileMode.Create);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<ElectricalAppliance>), new Type[] { typeof(Combine), typeof(WashingMachine), typeof(DustTrain) });
            serializer.WriteObject(file, appliances);

            Console.WriteLine("After serialization: ");
            file.Position = 0;
            List<ElectricalAppliance> appliances1 = (List<ElectricalAppliance>)serializer.ReadObject(file);
            foreach (ElectricalAppliance appliance in appliances1)
            {
                Console.WriteLine(appliance);
            }
        }
    }
}