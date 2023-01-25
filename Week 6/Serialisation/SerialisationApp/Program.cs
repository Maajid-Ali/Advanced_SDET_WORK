namespace SerialisationApp;

public class Program
{
    private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static ISerialise _serialiser;
    static void Main(string[] args)
    {
        //Trainee joseph = new Trainee() { FirstName = "Joseph", LastName = "McCann", SpartaNo = 7};
        _serialiser = new BinarySerialiser();

        //serialiser.SerialiseToFile<Trainee>($"{_path}BinaryJoe.bin", joseph);
        Trainee joseph = _serialiser.DeserialiseFromFile<Trainee>($"{_path}BinaryJoe.bin")

        _serialiser = new XMLSerialiser();

        joseph = _serialiser.DeserialiseFromFile<Trainee>($"{_path}BinaryJoe.xml");

        Course eng134 = new Course()
        {
            Title = "Engineering 134";
            Subject = "C# SDET";
            StartDate = new DateTime(2022, 11, 28);
        }

    }
}

[Serializable]
public class Course
{
    public string Subject { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public List<Trainee> Trainees { get; } = new List<Trainee>();
    [field: NonSerialized]
    private readonly DateTime _lastRead;
    public Course()
    {
        _lastRead = DateTime.Now;
    }
    public void AddTrainee(Trainee newTrainee)
    {
        Trainees.Add(newTrainee);
    }

}
