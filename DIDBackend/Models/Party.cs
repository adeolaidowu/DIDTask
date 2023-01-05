namespace DIDBackend.Models
{
    public class Party
    {
        public string PartyId { get; set; }
        public string FullName { get; set; }
        public List<string> Addresses { get; set; }
        public object PartyType { get; set; }
        public object IsIndividual { get; set; }
        public object IsAuthorizingParty { get; set; }
        public string EmailAddress { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
}
