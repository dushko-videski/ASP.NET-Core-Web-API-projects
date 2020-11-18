namespace SimplifiedCollageSystem.DomainModels
{
    public class Subject
    {

        public string Name { get; set; }
        public int Credits { get; set; }
        public int Semestar { get; set; }


        //FK
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
