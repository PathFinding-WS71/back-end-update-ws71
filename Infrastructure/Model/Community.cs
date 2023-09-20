namespace Infrastructure.Model;

public class Community : BaseModel
{
    public string CommunityName { get; set; }
    public string CommunityDescription { get; set; }
    public string CommunityVisibility { get; set; }
    
    //Relationship with CommunityMembers table
    public ICollection<CommunityMember> CommunityMembers { get; set; }
}