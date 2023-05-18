using System.Runtime.Serialization;
namespace Final_Project_OOP
{
    [DataContract]
    public class DustTrain : ElectricalAppliance
    {
        [DataMember]
        public int Power { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]

        public int countDustTrain;

        public DustTrain(string name, string mark, int cost, int power, string color) : base(name, mark, cost)
        {
            Power = power;
            Color = color;
        }
        public override string ToString()
        {
            return $"Name: {Name}, mark: {Mark}, cost: {Cost}$, power: {Power} Watt, color: {Color}";
        }

        public override int Count(string name)
        {
            if (name == "DustTrain")
                countDustTrain++;
            return countDustTrain;
        }
    }
}
