using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using JHashimoto.AwsViewer.AwsInfrastructure.Authentication;

namespace JHashimoto.AwsViewer.AwsInfrastructure.Persistence.EC2 {
    /// <summary>
    /// 
    /// </summary>
    public class AwsEC2Repository : IEC2Repository, IDisposable {

        private AmazonEC2Client ec2Client;

        public AwsEC2Repository(string profileName, Amazon.RegionEndpoint regionEndpoint) {
            var credential = CredentialDescribeService.GetCredential(profileName);
            ec2Client = new AmazonEC2Client(credential, regionEndpoint);
        }

        public AwsEC2Repository() {
            ec2Client = new AmazonEC2Client();
        }

        public IEnumerable<EC2Instance> GetAll() {
            var request = new DescribeInstancesRequest();
            var response = ec2Client.DescribeInstancesAsync(request);
            var reservations = response.Result.Reservations;

            var index = 1;
            foreach (var reserve in reservations) {
                foreach (var ins in reserve.Instances) {
                    var sg = new {
                        GroupID = ins.SecurityGroups.FirstOrDefault()?.GroupId ?? "none",
                        GroupName = ins.SecurityGroups.FirstOrDefault()?.GroupName ?? "none"
                    };

                    yield return
                        new EC2Instance() {
                            AutoNumber = index,
                            ID = ins.InstanceId,

                            Name = (
                                from tag in ins.Tags
                                where tag.Key == "Name"
                                select tag.Value).FirstOrDefault() ?? "タグなし",

                            InstanceType = ins.InstanceType,
                            ImageID = ins.ImageId,
                            PrivateDns = ins.PrivateDnsName,
                            PrivateIP = ins.PrivateIpAddress,
                            PublicIP = ins.PublicIpAddress,
                            // TODO:all securitygroup
                            SecurityGroupID = sg.GroupID,
                            SecurityGroupName = sg.GroupName,
                            VpcID = ins.VpcId,
                            SubnetID = ins.SubnetId,
                            AZ = ins.Placement.AvailabilityZone,
                            RootDeviceName = ins.RootDeviceName,
                            Key = ins.KeyName,
                            Platform = ins.Platform,
                            Architecture = ins.Architecture
                        };

                    index++;
                }
            }
        }


        #region 終了処理

        /// <summary>
        /// <see cref="DatabaseRepositoryContext"/>オブジェクトがガベージコレクションにより収集される前に、<see cref="DatabaseRepositoryContext"/>がリソースを解放し、
        /// その他のクリーンアップ操作を実行できるようにします。
        /// </summary>
        ~AwsEC2Repository() {
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
