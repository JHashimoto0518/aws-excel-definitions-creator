using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.SecurityGroups {
    public interface ISecurityGroupRepository {
        IEnumerable<SecurityGroupRule> GetAll();
    }
}
