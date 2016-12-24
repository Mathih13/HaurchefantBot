using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace HaurchefantBot
{

    public class Data
    {
        public string modhash { get; set; }
        public IList<Child> children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }
	
}
