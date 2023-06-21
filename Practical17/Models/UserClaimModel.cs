namespace Practical17.Models
{
    public class UserClaimModel
    {
        public UserClaimModel()
        {
            Claims = new List<UserClaim>();
        }
        public string UserId { get; set; } = string.Empty;
        public IList<UserClaim> Claims { get; set; }
    }
}
