using System.Collections.Generic;

namespace Bond.PerformanceTest
{
    public static class BenchmarksData
    {
        public static Bond.Person BondPerson()
        {
            return new Bond.Person
            {
                firstName = "Test",
                lastName = "Person",
                age = 22,
                gender = Bond.Gender.Male,
                policeRecords = new List<Bond.PoliceRecord>
                {
                    new Bond.PoliceRecord
                    {
                        crime = "crime1",
                        id = 1
                    },

                    new Bond.PoliceRecord
                    {
                        crime = "some crime with very very very very very long description. asldg ;askdg a;sdgjk asdgjahsd asd gasd asdjgahsl dgasldjgh",
                        id = 2
                    }
                }
            };
        }

        public static Person ProtobufPerson()
        {
            return Person
                .CreateBuilder()
                .SetFirstName("Test")
                .SetLastName("Person")
                .SetAge(22)
                .SetGender(Gender.Male)
                .AddPoliceRecords(PoliceRecord
                    .CreateBuilder()
                    .SetCrime("crime1")
                    .SetId(1))
                .AddPoliceRecords(PoliceRecord
                    .CreateBuilder()
                    .SetCrime("some crime with very very very very very long description. asldg ;askdg a;sdgjk asdgjahsd asd gasd asdjgahsl dgasldjgh")
                    .SetId(2))
                .Build();
        }

        public static ProtobufNet.Person ProtobufNetPerson()
        {
            var result = new ProtobufNet.Person
            {
                firstName = "Test",
                lastName = "Person",
                age = 22,
                gender = ProtobufNet.Gender.Male,
                police_records =
                {
                    new ProtobufNet.PoliceRecord
                    {
                        crime = "crime1",
                        id = 1
                    },
                    new ProtobufNet.PoliceRecord
                    {
                        crime = "some crime with very very very very very long description. asldg ;askdg a;sdgjk asdgjahsd asd gasd asdjgahsl dgasldjgh",
                        id = 2
                    }
                }
            };
            return result;
        }

        public static JSON.Person JSONPerson()
        {
            var result = new JSON.Person
            {
                firstName = "Test",
                lastName = "Person",
                age = 22,
                gender = JSON.Gender.Male,
                policeRecords =
                {
                    new JSON.PoliceRecord
                    {
                        crime = "crime1",
                        id = 1
                    },
                    new JSON.PoliceRecord
                    {
                        crime = "some crime with very very very very very long description. asldg ;askdg a;sdgjk asdgjahsd asd gasd asdjgahsl dgasldjgh",
                        id = 2
                    }
                }
            };

            return result;
        }

        public static XML.Person XMLPerson()
        {
            var result = new XML.Person
            {
                firstName = "Test",
                lastName = "Person",
                age = 22,
                gender = XML.Gender.Male,
                policeRecords =
                {
                    new XML.PoliceRecord
                    {
                        crime = "crime1",
                        id = 1
                    },
                    new XML.PoliceRecord
                    {
                        crime = "some crime with very very very very very long description. asldg ;askdg a;sdgjk asdgjahsd asd gasd asdjgahsl dgasldjgh",
                        id = 2
                    }
                }
            };

            return result;
        }
    }
}