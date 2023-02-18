using Newtonsoft.Json;
using Xunit;

namespace MemberData.Tests;

public class PersonTest
{
    [Theory]
    [MemberData(nameof(PersonTestData.IsLessThan30YearsOld), MemberType = typeof(PersonTestData))]
    public void GivenPerson_WhenAgeIsSmallerOrEqual30_ThenReturnsTrue(Person person, bool expected)
    {
        // GIVEN: a person with an age
        // WHEN: the age is tested
        var result = person.Age <= 30;

        // THEN: the result is equal to the expected value
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(PersonTestData.PatchCountry), MemberType = typeof(PersonTestData))]
    public void GivenPerson_WhenCountryIsNotAssigned_ThenShouldPatchPerson(Person person, Person personPatched)
    {
        // GIVEN: a person without a country
        // WHEN: the country is patched
        person.Country ??= "US";

        // THEN: the patched person is equal to the expected person
        Assert.Equal(
              JsonConvert.SerializeObject(person, new JsonSerializerSettings()),
              JsonConvert.SerializeObject(personPatched, new JsonSerializerSettings()),
              ignoreCase: true,
              ignoreLineEndingDifferences: true,
              ignoreWhiteSpaceDifferences: true);
    }
}