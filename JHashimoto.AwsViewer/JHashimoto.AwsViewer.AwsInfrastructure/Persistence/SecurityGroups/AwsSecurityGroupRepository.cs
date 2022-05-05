using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.SecurityGroups;
using JHashimoto.AwsViewer.AwsInfrastructure.Authentication;

namespace JHashimoto.AwsViewer.AwsInfrastructure.Persistence.SecurityGroups {
    /// <summary>
    /// 
    /// </summary>
    public class AwsSecurityGroupRepository : ISecurityGroupRepository, IDisposable {

        private AmazonEC2Client ec2Client;

        public AwsSecurityGroupRepository(string profileName, Amazon.RegionEndpoint regionEndpoint) {
            var credential = CredentialDescribeService.GetCredential(profileName);
            ec2Client = new AmazonEC2Client(credential, regionEndpoint);
        }

        public AwsSecurityGroupRepository() {
            ec2Client = new AmazonEC2Client();
        }

       public IEnumerable<CreateDefinitionsApplication.Domain.Models.SecurityGroups.SecurityGroupRule> GetAll() {
            var request = new Amazon.EC2.Model.DescribeSecurityGroupsRequest();
            var response  = ec2Client.DescribeSecurityGroupsAsync(request);

            var index = 1;
            foreach (var sg_org in response.Result.SecurityGroups) {
                var name = (from tag in sg_org.Tags
                            where tag.Key == "Name"
                            select tag.Value).FirstOrDefault() ?? "name tag none";

                // ingress
                foreach (var ipPerm in sg_org.IpPermissions) {
                    foreach (var cidrPerm in ipPerm.Ipv4Ranges) {
                        yield return new CreateDefinitionsApplication.Domain.Models.SecurityGroups.SecurityGroupRule() {
                            AutoNumber = index,
                            Name = name,
                            VpcID = sg_org.VpcId,
                            GroupName = $"{sg_org.GroupName} ({sg_org.Description})",
                            GroupDescription = sg_org.Description,
                            IngressOrEgress = "Ingress",
                            SourcePort = ipPerm.FromPort,
                            Protocol = ipPerm.IpProtocol.ToUpper(),
                            SourceType = "CIDR",
                            Source = cidrPerm.CidrIp,
                            RuleDescription = cidrPerm.Description
                        };

                        index++;
                    }

                    foreach (var sgPerm in ipPerm.UserIdGroupPairs) {
                        yield return new CreateDefinitionsApplication.Domain.Models.SecurityGroups.SecurityGroupRule() {
                            AutoNumber = index,
                            Name = name,
                            VpcID = sg_org.VpcId,
                            GroupName = $"{sg_org.GroupName} ({sg_org.Description})",
                            GroupDescription = sg_org.Description,
                            IngressOrEgress = "Ingress",
                            SourcePort = ipPerm.FromPort,
                            Protocol = ipPerm.IpProtocol.ToUpper(),
                            SourceType = "SecurityGroup",
                            Source = sgPerm.GroupId,
                            RuleDescription = sgPerm.Description
                        };

                        index++;
                    }
                }

                // egress
                foreach (var ipPerm in sg_org.IpPermissionsEgress) {
                    foreach (var cidrPerm in ipPerm.Ipv4Ranges) {
                        yield return new CreateDefinitionsApplication.Domain.Models.SecurityGroups.SecurityGroupRule() {
                            AutoNumber = index,
                            Name = name,
                            VpcID = sg_org.VpcId,
                            GroupName = $"{sg_org.GroupName} ({sg_org.Description})",
                            GroupDescription = sg_org.Description,
                            IngressOrEgress = "Egress",
                            SourcePort = ipPerm.FromPort,
                            Protocol = ipPerm.IpProtocol.ToUpper(),
                            SourceType = "CIDR",
                            Source = cidrPerm.CidrIp,
                            RuleDescription = cidrPerm.Description
                        };

                        index++;
                    }

                    foreach (var sgPerm in ipPerm.UserIdGroupPairs) {
                        yield return new CreateDefinitionsApplication.Domain.Models.SecurityGroups.SecurityGroupRule() {
                            AutoNumber = index,
                            Name = name,
                            VpcID = sg_org.VpcId,
                            GroupName = $"{sg_org.GroupName} ({sg_org.Description})",
                            GroupDescription = sg_org.Description,
                            IngressOrEgress = "Egress",
                            SourcePort = ipPerm.FromPort,
                            Protocol = ipPerm.IpProtocol.ToUpper(),
                            SourceType = "SecurityGroup",
                            Source = sgPerm.GroupId,
                            RuleDescription = sgPerm.Description
                        };

                        index++;
                    }
                }
            }
        }


        #region 終了処理

        /// <summary>
        /// <see cref="DatabaseRepositoryContext"/>オブジェクトがガベージコレクションにより収集される前に、<see cref="DatabaseRepositoryContext"/>がリソースを解放し、
        /// その他のクリーンアップ操作を実行できるようにします。
        /// </summary>
        ~AwsSecurityGroupRepository() {
            Dispose();
        }

        /// <summary>
        /// 既にDisoseが呼ばれた場合は<c>true</c>。まだ呼ばれていない場合は<c>false</c>。
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// リソースを解放します。
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// リソースを解放します。
        /// </summary>
        /// <param name="disposing">
        /// マネージ リソースとアンマネージ リソースの両方を解放する場合は<c>true</c>。アンマネージ リソースだけを解放する場合は<c>false</c>。
        /// </param>
        private void Dispose(bool disposing) {
            if (disposed) {
                return;
            }

            // マネージリソースを解放する。
            if (disposing) {
                
            }

            disposed = true;
        }

        #endregion 終了処理
    }
}
