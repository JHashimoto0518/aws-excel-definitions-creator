using JHashimoto.AwsViewer.AwsInfrastructure.Authentication;

public static class EntryPoint {
    public static void Main(String[] args) {
        // TODO:Configrationに
        var credential = new Credential("AKI...", "FGb...");
        var registerler = new CredentialRegisterer(credential, "dev", Amazon.RegionEndpoint.APNortheast1);

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
    }
}