namespace Infrastructure.Model;

public class CommunityMember : BaseModel
{
    public DateOnly? MembershipDate { get; set; }
    
    //Relationship with Participations table
    public ICollection<Participation> Participations { get; set; }
    
    //Relationship with Community table
    public int CommunityId { get; set; }
    public  Community Community { get; set; }
    
    //Relationship with Rol table
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    // TODO : Relationship with Users table
}