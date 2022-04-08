using JHashimoto.AwsViewer.AwsInfrastructure.Persistence.EC2;
using JHashimoto.AwsViewer.ExcelInfrastructure.Persistence.EC2;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Application.EC2;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using Microsoft.Extensions.DependencyInjection;

public static class EntryPoint {
    public static void Main(String[] args) {
        // TODO: get credential from App.Config
        //var credential = new Credential("AKI...", "FGb...");
        //var registerler = new CredentialRegisterer(credential, "dev", Amazon.RegionEndpoint.APNortheast1);

        // TODO: DI
        //var services = new ServiceCollection();
        //services.AddTransient<IEC2Repository, AwsEC2Repository>();

        //using var provider = services.BuildServiceProvider();
        //var ec2Repository = provider.GetService<IEC2Repository>();

        // ERROR:
        // System.AggregateException: 'One or more errors occurred. (Unable to get IAM security credentials from EC2 Instance Metadata Service.)'
        // 
        // Inner Exception
        //AmazonServiceException: Unable to get IAM security credentials from EC2 Instance Metadata Service.
        //var ec2Repository = new AwsEC2Repository();
        var ec2Repository = new AwsEC2Repository("dev", Amazon.RegionEndpoint.APNortheast1);
        var exportRepository = new ExcelEC2Repository();

        var ec2Service = new EC2ApplicationService(ec2Repository, exportRepository);
        ec2Service.Export();
    }
}