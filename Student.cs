namespace university_enrollment_system
{
    public class Student : Person
    {
        public string Major { get; set; }

        public Student(string fullName, long id, string major) : base(fullName, id)
        {
            Major = major;
        }

        public override void SaveToFile(StreamWriter writer)
        {
            base.SaveToFile(writer);
            writer.WriteLine($",{Major}");
        }

        public override string ToString()
        {
            return base.ToString() + $", {Major}";
        }
    }
}