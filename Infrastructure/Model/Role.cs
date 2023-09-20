namespace Infrastructure.Model;

public class Role : BaseModel
{
    public string Name { get; set; }
    
    //Relationship with CommunityMembers table
    public ICollection<CommunityMember> CommunityMembers { get; set; }
}