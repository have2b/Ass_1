using System.Globalization;
using System.Text.RegularExpressions;

namespace Assignment_1
{
    public class MemberService
    {
        private static readonly string nameRegex = @"^[a-zA-Z]+$";
        private static readonly string phoneRegex = @"^(0|\+84)(\d{9})$";

        public static List<Member> GenerateMembers()
        {
            var members = new List<Member>()
            {
                new Member()
                {
                    FirstName = "Thanh",
                    LastName = "Long",
                    Gender = true,
                    DateOfBirth = new DateOnly(2002, 6, 15),
                    PhoneNumber = "+84867433638",
                    BirthPlace = "Ha Tey",
                    Age = 21,
                    IsGraduated = true
                },
                new Member()
                {
                    FirstName = "Huyen",
                    LastName = "Trang",
                    Gender = false,
                    DateOfBirth = new DateOnly(2000, 8, 21),
                    PhoneNumber = "+84867433639",
                    BirthPlace = "Ha Tey",
                    Age = 23,
                    IsGraduated = true
                },
                new Member()
                {
                    FirstName = "Phuong",
                    LastName = "Ngan",
                    Gender = false,
                    DateOfBirth = new DateOnly(1998, 7, 30),
                    PhoneNumber = "+84867413648",
                    BirthPlace = "Ha Noi",
                    Age = 25,
                    IsGraduated = true
                },
                new Member()
                {
                    FirstName = "Nguyen",
                    LastName = "Hoang",
                    Gender = true,
                    DateOfBirth = new DateOnly(1999, 5, 20),
                    PhoneNumber = "+84867413648",
                    BirthPlace = "Ha Noi",
                    Age = 24,
                    IsGraduated = true
                }
            };
            return members;
        }

        public static void AddMember(List<Member> members)
        {
            string firstName = CheckInputString("Enter First name: ", nameRegex);
            string lastName = CheckInputString("Enter Last name: ", nameRegex);
            bool gender = CheckInputBool("Enter Gender (1 for Male, 0 for Female): ");
            DateOnly dob = CheckInputDate("Enter DOB (dd-mm-yyyy): ");
            string phoneNumber = CheckInputString("Enter Phone Number: ", phoneRegex);
            string birthPlace = CheckInputString("Enter Birth Place: ", nameRegex);
            int age = CheckInputInt("Enter Age: ");
            bool isGraduated = CheckInputBool(
                "Enter graduation status (1 for graduated, 0 for ungraduated): "
            );

            var member = new Member()
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DateOfBirth = dob,
                PhoneNumber = phoneNumber,
                BirthPlace = birthPlace,
                Age = age,
                IsGraduated = isGraduated
            };

            members.Add(member);
        }

        private static void DisplayListMember(List<Member> members)
        {
            foreach (Member member in members)
            {
                Console.WriteLine(member.ToString());
            }
        }

        public static void FindMales(List<Member> members)
        {
            var males = new List<Member>();
            foreach (Member member in members)
            {
                if (member.Gender is true)
                {
                    males.Add(member);
                }
            }

            Console.WriteLine("\nList of males: ");
            DisplayListMember(males);
        }

        public static void FindOldestMember(List<Member> members)
        {
            var oldest = members[0];
            foreach (Member member in members)
            {
                if (member.Age > oldest.Age)
                    oldest = member;
            }

            Console.WriteLine($"The oldest one is: {oldest}");
        }

        public static void ListFullNameOnly(List<Member> members)
        {
            foreach (Member member in members)
            {
                Console.WriteLine($"{member.FirstName} {member.LastName}");
            }
        }

        public static void ListMemSurroundingYear(List<Member> members, int year)
        {
            var beforeYear = new List<Member>();
            var inYear = new List<Member>();
            var afterYear = new List<Member>();
            foreach (Member member in members)
            {
                switch (member.DateOfBirth.Year - year)
                {
                    case < 0:
                        beforeYear.Add(member);
                        break;
                    case > 0:
                        afterYear.Add(member);
                        break;
                    case 0:
                        inYear.Add(member);
                        break;
                }
            }

            Console.WriteLine($"\nMember who has birth year in {year}: ");
            DisplayListMember(inYear);
            Console.WriteLine($"\nMember who has birth year before {year}: ");
            DisplayListMember(beforeYear);
            Console.WriteLine($"\nMember who has birth year after {year}: ");
            DisplayListMember(afterYear);
        }

        public static void FindFirstBornInHaNoi(List<Member> members)
        {
            foreach (Member member in members)
            {
                if (member.BirthPlace.Equals("Ha Noi"))
                {
                    Console.WriteLine(member.ToString());
                    break;
                }
            }
        }

        private static string CheckInputString(string prompt, string regex)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input can't be empty");
                    continue;
                }

                // Check match regex
                if (!Regex.IsMatch(input, regex))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                return input;
            }
        }

        private static bool CheckInputBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input == "1" || input == "0")
                {
                    return input == "1";
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter '1' or '0'.");
                }
            }
        }

        private static DateOnly CheckInputDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (
                    DateOnly.TryParseExact(
                        input,
                        "dd-mm-yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateOnly dob
                    )
                )
                {
                    return dob;
                }
                else
                {
                    Console.WriteLine(
                        "Invalid date format. Please enter date in dd-mm-yyyy format."
                    );
                }
            }
        }

        private static int CheckInputInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input. Input must be a non-negative integer.");
                }
            }
        }
    }
}
