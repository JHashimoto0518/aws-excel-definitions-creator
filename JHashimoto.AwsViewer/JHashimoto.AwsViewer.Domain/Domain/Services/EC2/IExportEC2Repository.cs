using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services.EC2 {
    public interface IExportEC2Repository {
        void Export(IEnumerable<EC2Instance> ec2List);
    }
}
