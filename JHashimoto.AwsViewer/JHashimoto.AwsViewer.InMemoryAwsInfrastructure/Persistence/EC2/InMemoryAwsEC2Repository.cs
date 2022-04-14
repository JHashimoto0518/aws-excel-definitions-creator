using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;

namespace JHashimoto.AwsViewer.AwsInfrastructure.Persistence.EC2 {
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryAwsEC2Repository : IEC2Repository {

        public InMemoryAwsEC2Repository() {
        }

        public IEnumerable<EC2Instance> GetAll() {
            yield return
                new EC2Instance() {
                    AutoNumber = 1,
                    ID = "i-06c3998b0ed37xxxx",
                    Name = "bastion-server",
                    InstanceType = "t2.micro",
                    ImageID = "ami-07a780395c79fxxxx",
                    PrivateDns = "ip-192.168.1.3.ap-northeast-1.compute.internal",
                    PrivateIP = "192.168.1.3",
                    PublicIP = "82.129.80.xxx",
                    PublicDns = "ec2-82-129-80-xxx.us-west-2.compute.amazonaws.com",
                    // TODO:all securitygroup
                    SecurityGroupID = "sg-03bf6446cb8baxxxx",
                    SecurityGroupName = "bastion-ssh-sg",
                    VpcID = "vpc-56253xxx",
                    SubnetID = "subnet-3994xxxx",
                    AZ = "ap-northeast-1a",
                    RootDeviceName = "/dev/xvda",
                    Key = "bastion-key",
                    Platform = "Linux/UNIX",
                    Architecture = "x86_64"
                };

            yield return
                new EC2Instance() {
                    AutoNumber = 2,
                    ID = "i-00fc57644a76fxxxx",
                    Name = "web1-server",
                    InstanceType = "t2.micro",
                    ImageID = "ami-07a780395c79fxxxx",
                    PrivateDns = "ip-192.168.1.4.ap-northeast-1.compute.internal",
                    PrivateIP = "192.168.1.4",
                    PublicIP = "82.129.81.xxx",
                    PublicDns = "ec2-82-129-81-xxx.us-west-2.compute.amazonaws.com",
                    // TODO:all securitygroup
                    SecurityGroupID = "sg-04bb6446ej8aaxxxx",
                    SecurityGroupName = "web-http-sg",
                    VpcID = "vpc-56253xxx",
                    SubnetID = "subnet-9836xxxx",
                    AZ = "ap-northeast-1c",
                    RootDeviceName = "/dev/xvda",
                    Key = "web-key",
                    Platform = "Linux/UNIX",
                    Architecture = "x86_64"
                };

            yield return
                new EC2Instance() {
                    AutoNumber = 3,
                    ID = "i-00fc57644a76fxxxx",
                    Name = "web2-server",
                    InstanceType = "t2.micro",
                    ImageID = "ami-07a780395c79fxxxx",
                    PrivateDns = "ip-192.168.1.5.ap-northeast-1.compute.internal",
                    PrivateIP = "192.168.1.5",
                    PublicIP = "82.129.82.xxx",
                    PublicDns = "ec2-82-129-82-xxx.us-west-2.compute.amazonaws.com",
                    // TODO:all securitygroup
                    SecurityGroupID = "sg-01th6446ol8aaxxxx",
                    SecurityGroupName = "web-http-sg",
                    VpcID = "vpc-56253xxx",
                    SubnetID = "subnet-9836xxxx",
                    AZ = "ap-northeast-1d",
                    RootDeviceName = "/dev/xvda",
                    Key = "web-key",
                    Platform = "Linux/UNIX",
                    Architecture = "x86_64"
                };
        }
    }
}
