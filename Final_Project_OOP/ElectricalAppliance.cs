using System.Runtime.Serialization;

namespace Final_Project_OOP
{
    [DataContract]
    public abstract class ElectricalAppliance
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Mark { get; set; }
        [DataMember]
        public int Cost { get; set; }

        public ElectricalAppliance(string name, string mark, int cost)
        {
            Name = name;
            Mark = mark;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"Name: {Name}, mark: {Mark}, cost: {Cost}$";
        }

        public abstract int Count(string name);


      
    }
}
