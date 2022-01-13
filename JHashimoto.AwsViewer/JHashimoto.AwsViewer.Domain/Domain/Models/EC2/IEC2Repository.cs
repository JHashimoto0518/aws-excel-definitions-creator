using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2 {
    public interface IEC2Repository {
        List<EC2Instance> GetAll();
    }
}
