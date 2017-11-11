using System.Collections.Generic;

namespace Bond.PerformanceTest.XML
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Passport
    {
        public string number { get; set; }

        public string authority { get; set; }

        public Passport()
        {
            number = string.Empty;
            authority = string.Empty;
        }
    }

    public class PoliceRecord
    {
        public int id { get; set; }

        public string crime { get; set; }

        public PoliceRecord()
        {
            crime = string.Empty;
        }
    }

    public class Person
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public uint age { get; set; }

        public Gender gender { get; set; }

        public Passport password { get; set; }

        public List<PoliceRecord> policeRecords { get; set; }

        public Person()
        {
            firstName = string.Empty;
            lastName = string.Empty;
            policeRecords = new List<PoliceRecord>();
        }
    }
}
