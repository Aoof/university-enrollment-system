namespace university_enrollment_system
{
    static public class Driver
    {

        const string FILENAME = "output.txt";
        private static Person[] people = {};
        private static int count = 0;
        private static bool running = true;
        public static void Main()
        {
            while (running)
            {
                DisplayMenu();
                int choice = (int)AcceptInput("Enter choice: ", 1, 6);
                ProcessChoice(choice);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n\nUniversity Enrollment System");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Add a Student");
            Console.WriteLine("2. Add a Professor");
            Console.WriteLine("3. Display All People (Sorted by ID)");
            Console.WriteLine("4. Save to File");
            Console.WriteLine("5. Load from File");
            Console.WriteLine("6. Exit");
        }

        private static void ProcessChoice(int choice)
        {
            Console.WriteLine("\n");
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    AddProfessor();
                    break;
                case 3:
                    DisplayPeople();
                    break;
                case 4:
                    SaveToFile(people);
                    break;
                case 5:
                    people = ReadFromFile();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private static string AcceptInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine() ?? "";
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        private static long AcceptInput(string prompt, long min, long max)
        {
            long value;
            do
            {
                Console.Write(prompt);
                value = long.Parse(Console.ReadLine() ?? "0");
            } while (value < min || value > max);

            return value;
        }

        private static void AddStudent()
        {
            string fullName = AcceptInput("Enter full name: ");
            long id = AcceptInput("Enter ID: ", 0, 999999999);
            string major = AcceptInput("Enter major: ");

            int newIndex = count++;
            Array.Resize(ref people, count);
            people[newIndex] = new Student(fullName, id, major);
        }

        private static void AddProfessor()
        {
            string fullName = AcceptInput("Enter full name: ");
            long id = AcceptInput("Enter ID: ", 0, 999999999);
            string department = AcceptInput("Enter department: ");

            int newIndex = count++;
            Array.Resize(ref people, count);
            people[newIndex] = new Professor(fullName, id, department);
        }

        private static void DisplayPeople()
        {
            SortById();
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void SortById()
        {
            bool swapped;

            for (int i = 0; i < people.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < people.Length - 1 - i; j++)
                {
                    if (people[j].ID > people[j + 1].ID)
                    {
                        Person temp = people[j];
                        people[j] = people[j + 1];
                        people[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }
        }

        private static void SaveToFile(Person[] people)
        {
            try
            {
                using StreamWriter writer = new(FILENAME);
                foreach (Person person in people)
                {
                    person.SaveToFile(writer);
                }
                Console.WriteLine("Data successfully saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        private static Person[] ReadFromFile()
        {
            try
            {
                if (!File.Exists(FILENAME))
                {
                    Console.WriteLine("File does not exist.");
                    return people;
                }

                using StreamReader reader = new(FILENAME);
                string lines = reader.ReadToEnd();
                string[] records = lines.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                Person[] loadedPeople = new Person[records.Length];
                int validRecords = ProcessRecords(records, loadedPeople);
                
                if (validRecords < loadedPeople.Length)
                {
                    Array.Resize(ref loadedPeople, validRecords);
                }
                
                count = validRecords;
                
                Console.WriteLine($"Successfully loaded {validRecords} records from file.");
                return loadedPeople;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
                return people;
            }
        }
        
        private static int ProcessRecords(string[] records, Person[] loadedPeople)
        {
            int validRecords = 0;
            
            foreach (string record in records)
            {
                if (string.IsNullOrWhiteSpace(record)) continue;
                
                string[] parts = record.Split(',');
                if (parts.Length < 3) continue;
                
                string type = parts[0];
                string fullName = parts[1];
                
                if (!long.TryParse(parts[2], out long id))
                    continue;
                
                string additionalInfo = parts.Length > 3 ? parts[3] : "Unknown";

                if (type == "Student")
                {
                    loadedPeople[validRecords++] = new Student(fullName, id, additionalInfo);
                }
                else if (type == "Professor")
                {
                    loadedPeople[validRecords++] = new Professor(fullName, id, additionalInfo);
                } 
                else 
                {
                    loadedPeople[validRecords++] = new Person(fullName, id);
                }
            }
            
            return validRecords;
        }
    }
}