using static System.Formats.Asn1.AsnWriter;

namespace WebApplication1.Models
{
    public class Member
    {
        public string userID { get; set; }
        public string userPW { get; set; }


        public Member()
        {
            userID = string.Empty;
            userPW = string.Empty;
        }

        public Member(string _id,string _pw)
        {
            userID = _id;
            userPW = _pw;
        }
    }
}
