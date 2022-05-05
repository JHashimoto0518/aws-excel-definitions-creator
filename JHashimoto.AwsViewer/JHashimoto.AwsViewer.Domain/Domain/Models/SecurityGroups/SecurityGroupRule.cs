using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.SecurityGroups {
    public class SecurityGroupRule {
        public int AutoNumber { get; set; }

        public string Name { get; set; }

        public string VpcID { get; set; }

        public string GroupName { get; set; }

        public string GroupDescription { get; set; }

        public string IngressOrEgress { get; set; }

        public int SourcePort { get; set; }

        public string Protocol { get; set; }

        public string SourceType { get; set; }

        public string Source { get; set; }

        public string RuleDescription { get; set; }
    }
}
