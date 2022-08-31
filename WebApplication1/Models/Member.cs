using static System.Formats.Asn1.AsnWriter;

namespace WebApplication1.Models
{
    public class Member
    {
        public string userId { get; set; }
        public string userPW { get; set; }


        public Member()
        {
            userId = string.Empty;
            userPW = string.Empty;
        }

        public Member(string _id,string _pw)
        {
            userId = _id;
            userPW = _pw;
        }
    }
}
