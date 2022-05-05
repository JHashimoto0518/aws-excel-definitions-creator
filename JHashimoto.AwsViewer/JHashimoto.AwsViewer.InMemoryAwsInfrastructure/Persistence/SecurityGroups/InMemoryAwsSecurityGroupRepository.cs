using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.SecurityGroups;

namespace JHashimoto.AwsViewer.InMemoryAwsInfrastructure.Persistence.SecurityGroups {
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryAwsSecurityGroupRepository : ISecurityGroupRepository {

        public InMemoryAwsSecurityGroupRepository() {
        }

        public IEnumerable<SecurityGroupRule> GetAll() {
            var number = 0;

            yield return
                new SecurityGroupRule {
                    AutoNumber = ++number,
                    VpcID = "vpc-56253xxx (vpc-company-web)",
                    GroupName = "default (default VPC security group)",
                    GroupDescription = "default VPC security group",
                    IngressOrEgress = "Ingress",
                    SourcePort = 0,
                    Protocol = "-1",
                    SourceType = "CIDR",
                    Source = "0.0.0.0/0",
                    RuleDescription = "allow all ingress traffic"
                };

            yield return
                new SecurityGroupRule {
                    AutoNumber = ++number,
                    VpcID = "vpc-56253xxx (vpc-company-web)",
                    GroupName = "default (default VPC security group)",
                    GroupDescription = "default VPC security group",
                    IngressOrEgress = "Egress",
                    SourcePort = 0,
                    Protocol = "-1",
                    SourceType = "CIDR",
                    Source = "0.0.0.0/0",
                    RuleDescription = "allow all egress traffic"
                };

            yield return
                new SecurityGroupRule {
                    AutoNumber = ++number,
                    VpcID = "vpc-56253xxx (vpc-company-web)",
                    GroupName = "sg-webserver (for webserver)",
                    GroupDescription = "for webserver",
                    IngressOrEgress = "Ingress",
                    SourcePort = 80,
                    Protocol = "TCP",
                    SourceType = "CIDR",
                    Source = "0.0.0.0/0",
                    RuleDescription = "allow http"
                };

            yield return
                new SecurityGroupRule {
                    AutoNumber = ++number,
                    VpcID = "vpc-56253xxx (vpc-company-web)",
                    GroupName = "sg-webserver (for webserver)",
                    GroupDescription = "for webserver",
                    IngressOrEgress = "Ingress",
                    SourcePort = 22,
                    Protocol = "TCP",
                    SourceType = "CIDR",
                    Source = "118.87.15.xxx/32",
                    RuleDescription = "allow ssh"
                };

            yield return
                new SecurityGroupRule {
                    AutoNumber = ++number,
                    VpcID = "vpc-56253xxx (vpc-company-web)",
                    GroupName = "sg-webserver (for webserver)",
                    GroupDescription = "for webserver",
                    IngressOrEgress = "Egress",
                    SourcePort = 0,
                    Protocol = "-1",
                    SourceType = "CIDR",
                    Source = "0.0.0.0/0",
                    RuleDescription = "allow all egress traffic"
                };

        }
    }
}
