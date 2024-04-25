using System.ComponentModel.DataAnnotations;

namespace Assignment_1
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public bool IsGraduated { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Gender: {(Gender ? "Male" : "Female")}, Date of Birth: {DateOfBirth.ToShortDateString()}, Phone Number: {PhoneNumber}, Birth Place: {BirthPlace}, Age: {Age}, Graduated: {(IsGraduated ? "Yes" : "No")}";
        }
    }
}
