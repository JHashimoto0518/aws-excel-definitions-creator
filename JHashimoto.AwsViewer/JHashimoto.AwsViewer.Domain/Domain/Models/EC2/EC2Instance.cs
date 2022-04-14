using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2 {
    public class EC2Instance {
        public int AutoNumber { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string InstanceType { get; set; }

        public string ImageID { get; set; }

        public string PrivateDns { get; set; }

        public string PrivateIP { get; set; }

        public string PublicDns { get; set; }

        public string PublicIP { get; set; }

        public string SecurityGroupID { get; set; }

        public string SecurityGroupName { get; set; }

        public string VpcID { get; set; }

        public string SubnetID { get; set; }

        public string AZ { get; set; }

        public string RootDeviceName { get; set; }

        public string Key { get; set; }

        public string Platform { get; set; }

        public string Architecture { get; set; }
    }
}
