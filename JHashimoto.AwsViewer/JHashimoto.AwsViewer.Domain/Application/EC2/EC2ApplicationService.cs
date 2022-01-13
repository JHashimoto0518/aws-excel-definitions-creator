using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.CreateDefinitionsApplication.Application.EC2 {
    public class EC2ApplicationService {
        private readonly IEC2Repository ec2Repository;

        public EC2ApplicationService(IEC2Repository ec2Repository) {
            this.ec2Repository = ec2Repository ?? throw new ArgumentNullException(nameof(ec2Repository));
        }

        public List<EC2Instance> GetAll() {
            return ec2Repository.GetAll();
        }
    }
}
