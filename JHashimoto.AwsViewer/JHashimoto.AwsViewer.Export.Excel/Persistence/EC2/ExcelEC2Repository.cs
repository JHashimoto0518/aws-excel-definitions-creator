using ClosedXML.Excel;
using ClosedXML.Report;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services;
using System.Diagnostics;

namespace JHashimoto.AwsViewer.ExcelInfrastructure.Persistence.EC2 {
    public class ExcelEC2Repository : IExportRepository {

        public ExcelEC2Repository() {
        }

        public void Export(IEnumerable<EC2Instance> ec2List) {
            var obj = new {
                Data = ec2List
            };

            using(var workbook = new XLWorkbook(@".\Templates\aws_resources_template_041002.xlsx")){
                // NOTE: 出力ファイルが壊れる
                //var sheet = workbook.Worksheets.Worksheet("ec2_instances");
                //sheet.Cell("B4").Value = "{{item.ID}}";
                //sheet.Cell("C4").Value = "{{item.Name}}";
                //sheet.Cell("D4").Value = "{{item.InstanceType}}";
                //sheet.Cell("E4").Value = "{{item.ImageID}}";
                //sheet.NamedRanges.Add("Data", workbook.Ranges("B4:E5"));
                //workbook.Save();
                //Process.Start(new ProcessStartInfo(@".\Templates\aws_resources_template_1.0.xlsx") { UseShellExecute = true });

                using (var template = new XLTemplate(workbook)) {
                    template.AddVariable(obj);
                    template.Generate();
                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "aws_resources.xlsx");
                    template.SaveAs(path);
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                }
            }
        }
    }
}