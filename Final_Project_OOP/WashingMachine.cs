using System.Runtime.Serialization;

namespace Final_Project_OOP
{
    [DataContract]
    public class WashingMachine : ElectricalAppliance
    {
        [DataMember]
        public int CountOfPrograms { get; set; }
        [DataMember]
        public int Volume { get; set; }
        [DataMember]
        public int countWashingMachine;
        public WashingMachine(string name, string mark, int cost, int countOfPrograms, int volume) : base(name, mark, cost)
        {
            CountOfPrograms = countOfPrograms;
            Volume = volume;
        }
        public override string ToString()
        {
            return $"Name: {Name}, mark: {Mark}, cost: {Cost}$, count of programs: {CountOfPrograms}, volume: {Volume} cubic feet";
        }
        public override int Count(string name)
        {
            if (name == "WashingMachine")
                countWashingMachine++;
            return countWashingMachine;
        }

    }
}
