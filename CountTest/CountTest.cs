using Final_Project_OOP;

namespace CountTest
{
    [TestClass]
    public class CountTest
    {
        [TestMethod]
        public void Count()
        {
            List<ElectricalAppliance> appliances = new List<ElectricalAppliance>
            {
                new DustTrain("DustTrain", "bosh", 2000, 120, "purple"),
                new DustTrain("DustTrain", "bosh2", 200, 150, "trple"),
                new WashingMachine("WashingMachine", "bore", 230, 5, 50),
                new Combine("Combine", "wer", 1200, 12, 220),
                new Combine("Combine", "fre", 180, 145, 20),
                new Combine("Combine", "vfr", 300, 134, 520),
            };

            int expected = 1;
            int actual = 0;

            foreach (ElectricalAppliance device in appliances)
            {
                actual += device.Count("WashingMachine");
            }

            Assert.AreEqual(expected, actual);
        }
    }
}