using System.Runtime.Serialization;

namespace Final_Project_OOP
{
    [DataContract]
    public class Combine : ElectricalAppliance
    {
        [DataMember]
        public int CountOfPrograms { get; set; }
        [DataMember]
        public int Power { get; set; }
        [DataMember]
        public int countCombine { get; set; }
        public Combine(string name, string mark, int cost, int countOfPrograms, int power) : base(name, mark, cost)
        {
            CountOfPrograms = countOfPrograms;
            Power = power; 
        }
        public override string ToString()
        {
            return $"Name: {Name}, mark: {Mark}, cost: {Cost}$, count of programs: {CountOfPrograms}, power: {Power} Watt";
        }
        public override int Count(string name)
        {
            if (name == "Combine")
                countCombine++;
            return countCombine;
        }
    }
}
