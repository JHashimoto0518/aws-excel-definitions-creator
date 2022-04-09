using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Application.EC2 {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>コンストラクタインジェクション</remarks>
    public class EC2ApplicationService {
        private readonly IEC2Repository ec2Repository;
        private readonly IExportRepository exportRepository;

        public EC2ApplicationService(IEC2Repository ec2Repository, IExportRepository exportRepository) {
            this.ec2Repository = ec2Repository ?? throw new ArgumentNullException(nameof(ec2Repository));
            this.exportRepository = exportRepository ?? throw new ArgumentNullException(nameof(exportRepository));
        }


        public void Export() {
            this.exportRepository.Export(this.ec2Repository.GetAll());
        }
    }
}
