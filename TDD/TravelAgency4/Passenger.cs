namespace TravelAgency4
{
    public class Passenger
    {
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public Passenger(string fname, string lname)
        {
            FirstName = fname;
            LastName = lname;
        }
    }
}