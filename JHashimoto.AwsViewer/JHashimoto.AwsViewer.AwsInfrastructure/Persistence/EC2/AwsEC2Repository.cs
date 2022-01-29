using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2;
using Amazon.EC2.Model;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using JHashimoto.AwsViewer.AwsInfrastructure.Authentication;

namespace JHashimoto.AwsViewer.AwsInfrastructure.EC2 {
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

        public List<EC2Instance> GetAll() {
            var request = new DescribeInstancesRequest();
            var response = ec2Client.DescribeInstancesAsync(request);
            var reservations = response.Result.Reservations;
            
            return new List<EC2Instance>() {
                new EC2Instance() {
                    ID = reservations.First().Instances.First().InstanceId,
                    Name = (
                    from tag in reservations.First().Instances.First().Tags
                    where tag.Key == "Name"
                    select tag.Value).FirstOrDefault() ?? "タグなし",
                }
            };
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
