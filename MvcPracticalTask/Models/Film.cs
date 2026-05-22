namespace MvcPracticalTask.Models
{
    public class Film
    {
        public int Id { get; set; }
        public int FilmID { get; set; }
        public string Title { get; set; }
        public int DirectorID { get; set; }
        public string Review { get; set; }
        public int RunTimeMinutes { get; set; }
        public long BudgetDollars { get; set; }
        public long BoxOfficeDollars { get; set; }
        public int OscarNominations { get; set; }
        public int OscarWins { get; set; }
    }
}