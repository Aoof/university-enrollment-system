
namespace university_enrollment_system
{
    public class Person
    {
        public string FullName { get; set; }
        public long ID { get; set; }

        public Person(string fullName, long id)
        {
            FullName = fullName;
            ID = id;
        }

        public virtual void SaveToFile(StreamWriter writer)
        {
            writer.Write($"{GetType().Name},{FullName},{ID}");
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {ID}, {FullName}";
        }
    }

}