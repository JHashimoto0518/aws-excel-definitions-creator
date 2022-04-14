using ClosedXML.Excel;
using ClosedXML.Report;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services;
using System.Diagnostics;

namespace JHashimoto.AwsViewer.ExcelInfrastructure.Persistence.EC2 {
    public class ExcelEC2Repository : IExportRepository {

        public ExcelEC2Repository() {
        }

        public void Export(IEnumerable<EC2Instance> ec2) {

            var obj = new {
                Data = ec2
            };

            var tplBase = @".\Templates\aws_resources_template_base.xlsx";
            var tplPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"aws_resources_template.xlsx");

            // setting template
            using (var stream = File.Open(tplBase, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var dest = new MemoryStream((int) stream.Length)) {
                stream.CopyTo(dest);
                using (var wbk = new XLWorkbook(dest)) {
                    var wsh = wbk.Worksheets.Worksheet("ec2_instances");
                    wsh.Cell("A2").Value = $"EC2 Instance ({ec2.Count()} items)";

                    wsh.Cell("A4").Value = "{{item.AutoNumber}}";
                    wsh.Cell("B4").Value = "{{item.Name}}";
                    wsh.Cell("C4").Value = "{{item.ID}}";
                    wbk.NamedRanges.Add("Data", wsh.Ranges("A4:R5"));
                    wbk.SaveAs(tplPath);
                }
            }

            // generate
            using (var tpl = new XLTemplate(tplPath)) {
                tpl.AddVariable(obj);
                tpl.Generate();
                var result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "aws_resources.xlsx");
                tpl.SaveAs(result);
                Process.Start(new ProcessStartInfo(result) { UseShellExecute = true });
            }
        }
    }
}