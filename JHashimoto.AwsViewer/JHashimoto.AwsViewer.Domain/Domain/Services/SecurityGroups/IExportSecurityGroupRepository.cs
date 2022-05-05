using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.SecurityGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services.SecurityGroups {
    public interface IExportSecutiryGroupRepository {
        void Export(IEnumerable<SecurityGroupRule> securityGroupList);
    }
}
