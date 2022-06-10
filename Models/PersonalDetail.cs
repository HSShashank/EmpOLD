using System;
using System.Collections.Generic;

namespace IBM.Models
{
    public partial class PersonalDetail
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
        public string StartDateInIbm { get; set; }
        public string StartDateInNyl { get; set; }
        public string IbmEmailId { get; set; } = null!;
        public string NylEmailId { get; set; } = null!;
        public string T57Id { get; set; } = null!;
        public string PeopleManager { get; set; } = null!;
        public string ExpectedIbmRole { get; set; } = null!;
        public string ExpectedClientRole { get; set; } = null!;
        public string PrimaryNylTeam { get; set; } = null!;
        public string PrimaryVertical { get; set; } = null!;
        public string TotalExperienceInInsurance { get; set; } = null!;
    }
}