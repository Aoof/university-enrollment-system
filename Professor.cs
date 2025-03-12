namespace university_enrollment_system
{
    public class Professor : Person
    {
        public string Department { get; set; }

        public Professor(string fullName, long id, string department) : base(fullName, id)
        {
            Department = department;
        }

        public override void SaveToFile(StreamWriter writer)
        {
            base.SaveToFile(writer);
            writer.WriteLine($",{Department}");
        }

        public override string ToString()
        {
            return base.ToString() + $", {Department}";
        }
    }
}