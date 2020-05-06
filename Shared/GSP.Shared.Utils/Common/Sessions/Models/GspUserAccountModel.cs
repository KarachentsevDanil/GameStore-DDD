namespace GSP.Shared.Utils.Common.Sessions.Models
{
    public class GspUserAccountModel
    {
        public GspUserAccountModel(long id, string email)
        {
            Id = id;
            Email = email;
        }

        public long Id { get; set; }

        public string Email { get; set; }
    }
}