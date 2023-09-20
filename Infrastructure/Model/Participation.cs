namespace Infrastructure.Model;

public class Participation : BaseModel
{
    //Relationship with Activity
    public int ActivityId { get; set; }
    public Activity Activity { get; set; }
    
    //Relationship with CommunityMember
    public int CommunityMemberId { get; set; }
    public CommunityMember CommunityMember { get; set; }
}