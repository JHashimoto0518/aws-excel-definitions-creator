using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2 {
    public class EC2Instance {
        public string ID { get; set; }
        public string Name { get; set; }
        public string InstanceType { get; set; }

        public string ImageID { get; set; }
    }
}
