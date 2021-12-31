using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.AwsInfrastructure.Authentication {
    public class Credential {
        public string accessKey;
        public string secretKey;

        public Credential(string accessKey, string secretKey) {
            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }
    }
}
