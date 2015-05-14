namespace VGGLinkedIn.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ContactInfo
    {
        [DisplayFormat(NullDisplayText = "No")]
        public string Phone { get; set; }

        [DisplayFormat(NullDisplayText = "No")]
        public string Twitter { get; set; }

        [DisplayFormat(NullDisplayText = "No")]
        public string Website { get; set; }

        [DisplayFormat(NullDisplayText = "No")]
        public string Facebook { get; set; }
    }
}
