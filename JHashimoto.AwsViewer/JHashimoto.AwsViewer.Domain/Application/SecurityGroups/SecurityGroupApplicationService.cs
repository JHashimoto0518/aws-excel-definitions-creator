using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.SecurityGroups;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services.SecurityGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Application.SecurityGroups {
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>コンストラクタインジェクション</remarks>
    public class SecurityGroupApplicationService {
        private readonly ISecurityGroupRepository securityGroupRepository;
        private readonly IExportSecutiryGroupRepository exportRepository;

        public SecurityGroupApplicationService(ISecurityGroupRepository securityGroupRepository, IExportSecutiryGroupRepository exportRepository) {
            this.securityGroupRepository = securityGroupRepository ?? throw new ArgumentNullException(nameof(securityGroupRepository));
            this.exportRepository = exportRepository ?? throw new ArgumentNullException(nameof(exportRepository));
        }

        public void Export() {
            this.exportRepository.Export(this.securityGroupRepository.GetAll());
        }
    }
}
