namespace Infrastructure.Model;

public class Activity : BaseModel
{
    public string ActivityTitle { get; set; }
    public string ActivityDescription { get; set; }
    public DateTime ActivityDate { get; set; }
    public string ActivityType { get; set; }

    //Relationship with participations table
    // public ICollection<Participation> Participations { get; set; }
    
    //Relationship with locations table
    public int LocationId { get; set; }
    public Location Location { get; set; }
}