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

            var ec2List = ec2.ToList();
            var obj = new {
                //Header = new {
                ////    // TODO:修正
                //    Count = ec2.Count()
                //},
                Data = ec2
            };

            var suffix = "041402"; //ok
            //var suffix = "041104";
            //var suffix = "041105"; //ng
            //var suffix = "041108";

            var tplBase = @".\Templates\aws_resources_template_base.xlsx";
            var tplPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"aws_resources_template_" + suffix + ".xlsx");

            using (var stream = File.Open(tplBase, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                using (var dest = new MemoryStream((int) stream.Length)) {
                    stream.CopyTo(dest);
                    using (var wbk = new XLWorkbook(dest)) {
                        var wsh = wbk.Worksheets.Worksheet("ec2_instances");
                        //var index = ec2.Select((ins, i) => i + 1);

                        //wsh.Cell("A4").Value = "{{items.Select((ins, i) => i + 1)}}";
                        //wsh.Cell("A4").Value = "{{items.Select((in, i) => 1)}}";
                        //wsh.Cell("A4").Value = "{{items.Where(i => i.ID == \"RUB\").Count()}}"; //ok
                        //wsh.Cell("A4").Value = "{{items.IndexOf(item)}}";

                        //wsh.Cell("A2").Value = "{{\"EC2 Instance (\" + item.Count.ToString() + \"items\")}}";
                        wsh.Cell("A2").Value = $"EC2 Instance ({ec2.Count()} items)";

                        wsh.Cell("A4").Value = "{{item.AutoNumber}}";
                        wsh.Cell("B4").Value = "{{item.Name}}";
                        wsh.Cell("C4").Value = "{{item.ID}}";
                        wbk.NamedRanges.Add("Data", wsh.Ranges("A4:R5"));
                        wbk.SaveAs(tplPath);
                    }
                }
            }

            using (var tpl = new XLTemplate(tplPath)) {
                tpl.AddVariable(obj);
                tpl.Generate();
                var result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "aws_resources.xlsx");
                tpl.SaveAs(result);
                Process.Start(new ProcessStartInfo(result) { UseShellExecute = true });
            }
        }

        //public void Export(IEnumerable<EC2Instance> ec2List) {
        //    var obj = new {
        //        //Meta = new {
        //        //    // TODO:修正
        //        //    Count = ec2List.Count()
        //        //},
        //        Data = ec2List
        //    };

        //    var suffix = "041103"; //ok
        //    //var suffix = "041104";
        //    //var suffix = "041105"; //ng



        //    //var suffix = "041108";

        //    var templateBase = @".\Templates\aws_resources_template_base.xlsx";
        //    var templatePath = @".\Templates\aws_resources_template_" + suffix + ".xlsx";

        //    using (var stream = File.Open(templatePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
        //        //using (var workbook = new XLWorkbook(stream)) { 
        //        // NOTE: 出力ファイルが壊れる
        //        //var sheet = workbook.Worksheets.Worksheet("ec2_instances");
        //        //sheet.Cell("B4").Value = "{{item.ID}}";
        //        //sheet.Cell("C4").Value = "{{item.Name}}";
        //        //sheet.Cell("D4").Value = "{{item.InstanceType}}";
        //        //sheet.Cell("E4").Value = "{{item.ImageID}}";
        //        //sheet.NamedRanges.Add("Data", workbook.Ranges("B4:E5"));
        //        //workbook.Save();
        //        //workbook.SaveAs(templatePath);
        //        //Process.Start(new ProcessStartInfo(@".\Templates\aws_resources_template_1.0.xlsx") { UseShellExecute = true });

        //        // TODO:MemoryStreamで
        //        using (var destination = new MemoryStream()) {
        //            stream.CopyTo(destination);
        //            using (var template = new XLTemplate(destination)) {
        //                // TODO:templateではなくwbkを編集し、templateのコンストラクタにセットする
        //                //var sheet = template.Workbook.Worksheets.Worksheet("ec2_instances");
        //                //sheet.Cell("B4").Value = "{{item.ID}}";

        //                template.AddVariable(obj);
        //                template.Generate();
        //                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "aws_resources.xlsx");
        //                template.SaveAs(path);
        //                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });

        //                //using (var file = new MemoryStream()) {
        //                //    var sheet = template.Workbook.Worksheets.Worksheet("ec2_instances");
        //                //    //sheet.Cell("B4").Value = "{{item.ID}}";

        //                //    template.AddVariable(obj);
        //                //    template.Generate();
        //                //    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "aws_resources.xlsx");
        //                //    template.SaveAs(file);
        //                //    using (var wb = new XLWorkbook(file)) {
        //                //        wb.SaveAs(path);
        //                //        Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        //                //    }
        //                //}
        //            }
        //        }
        //    }
        //    //}
        //}
    }
}