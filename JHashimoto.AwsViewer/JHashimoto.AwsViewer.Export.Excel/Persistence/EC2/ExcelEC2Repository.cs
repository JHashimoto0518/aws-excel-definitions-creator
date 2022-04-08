using ClosedXML.Excel;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.EC2;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services;

namespace JHashimoto.AwsViewer.ExcelInfrastructure.Persistence.EC2 {
    public class ExcelEC2Repository : IExportRepository {

        public ExcelEC2Repository() {
        }

        public void Export(List<EC2Instance> ec2List) {
            var instance = ec2List.First();
            using (var workbook = new XLWorkbook()) {
                var worksheet = workbook.Worksheets.Add("EC2");
                worksheet.Cell("A1").Value = instance.ID;
                worksheet.Cell("B1").Value = instance.Name;
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "aws_resources.xlsx");
                workbook.SaveAs(path);
            }
        }
    }
}