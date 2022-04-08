using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services {
    public interface IExportRepository {
        void Export(List<EC2Instance> ec2List);
    }
}
