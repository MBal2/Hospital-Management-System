using System;

namespace HospitalManagementSystem
{
    internal class PatientVitals
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime Timestamp { get; set; }
        public string Vitals { get; set; }
    }
}