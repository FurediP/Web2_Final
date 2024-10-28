namespace listContactsApi.Models
{
    public class Contact
    {
        public int contactid { get; set; }
        public int typecontactid { get; set; }
        public string name { get; set; }
        public long phonenum { get; set; }
        public string comment { get; set; }
        public string infoextra1 { get; set; }
        public string infoextra2 { get; set; }
    }
}
