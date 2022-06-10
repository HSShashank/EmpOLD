using System;
using System.Collections.Generic;

namespace IBM.Models
{
    public partial class ContactDetail
    {
        public string BaseLocation { get; set; } = null!;
        public string CurrentLocation { get; set; } = null!;
        public DateOnly LocationChangeDate { get; set; }
        public int PhoneNumber { get; set; }
        public int? TelephoneNumber { get; set; }
        public int EmergencyContact { get; set; }
        public int EmergencyContactName { get; set; }
        public string PermanentAddress { get; set; } = null!;
        public string CurrentAddress { get; set; } = null!;
        public string IbmAddress { get; set; } = null!;
        public string Organisation { get; set; } = null!;
    }
}