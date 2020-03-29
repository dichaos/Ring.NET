using System;
using System.Collections.Generic;

namespace RingIntegration.Devices.History
{
    public class History
    {
        public object id { get; set; }
        public DateTime created_at { get; set; }
        public bool answered { get; set; }
        public List<object> events { get; set; }
        public string kind { get; set; }
        public bool favorite { get; set; }
        public string snapshot_url { get; set; }
        public Recording recording { get; set; }
        public double duration { get; set; }
        public CvProperties cv_properties { get; set; }
        public Doorbot doorbot { get; set; }
    }
}