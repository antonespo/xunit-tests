using Xunit;

namespace MemberData.Tests;

public static class PersonTestData
{
    public static TheoryData<Person, bool> IsLessThan30YearsOld =>
        new TheoryData<Person, bool>
        {
            {
                new()
                {
                    Name = "Antonio",
                    Age = 28,
                },
                true
            },
            {
                new ()
                {
                    Name = "Mario",
                    Age = 32
                },
                false
            },
            {
                new ()
                {
                    Name = "Alice",
                    Age = 35
                },
                false
            }
        };

    public static TheoryData<Person, Person> PatchCountry =>
        new TheoryData<Person, Person>
        {
            {
                new()
                {
                    Name = "Antonio",
                    Age = 28,
                },
                new()
                {
                    Name = "Antonio",
                    Age = 28,
                    Country = "US"
                }
            },
            {
                new()
                {
                    Name = "Antonio",
                    Age = 28,
                    Country = "Italy"
                },
                new()
                {
                    Name = "Antonio",
                    Age = 28,
                    Country = "Italy"
                }
            }
        };
}
