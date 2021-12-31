using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace JHashimoto.AwsViewer.AwsInfrastructure.Authentication {
    public class CredentialRegisterer {
        public CredentialRegisterer(Credential credential, string profileName, Amazon.RegionEndpoint region) {
            var options = new Amazon.Runtime.CredentialManagement.CredentialProfileOptions {
                AccessKey = credential.accessKey, // Access Key
                SecretKey = credential.secretKey, // Don't commit with Secret Key
            };

            var profile = new CredentialProfile(profileName, options);
            profile.Region = region;
            var netSDKFile = new Amazon.Runtime.CredentialManagement.NetSDKCredentialsFile();
            netSDKFile.RegisterProfile(profile);
        }
	}
}
