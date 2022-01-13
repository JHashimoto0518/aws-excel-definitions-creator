using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHashimoto.AwsViewer.AwsInfrastructure.Authentication {
    internal static class CredentialDescribeService {
		public static AWSCredentials GetCredential(string profileName) {
			var chain = new CredentialProfileStoreChain();
			AWSCredentials awsCredentials;
			if (chain.TryGetAWSCredentials(profileName, out awsCredentials) == false) {
				throw new Exception($"profile:{profileName}からcredentialを取得できませんでした。");
			}

			return awsCredentials;
		}

	}
}
