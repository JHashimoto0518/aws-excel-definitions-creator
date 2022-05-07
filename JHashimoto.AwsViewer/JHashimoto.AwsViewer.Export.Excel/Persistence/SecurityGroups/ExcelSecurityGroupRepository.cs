using ClosedXML.Excel;
using ClosedXML.Report;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Models.SecurityGroups;
using JHashimoto.AwsViewer.CreateDefinitionsApplication.Domain.Services.SecurityGroups;
using System.Diagnostics;

namespace JHashimoto.AwsViewer.ExcelInfrastructure.Persistence.SecurityGroups {
    public class ExcelSecurityGroupRepository : IExportSecutiryGroupRepository {

        public ExcelSecurityGroupRepository() {
        }
         
        public void Export(IEnumerable<SecurityGroupRule> securityGroup) {

            var obj = new {
                Data = securityGroup.OrderBy(sg => sg.VpcID).ThenBy(sg => sg.Name).ThenByDescending(sg => sg.IngressOrEgress).ThenBy(sg => sg.SourceType).ThenBy(sg => sg.Source).ThenBy(sg => sg.SourcePort).ToList()
            };

            var tplBase = @".\Templates\aws_resources_template_base_mergedlabel2.xlsx";
            var tplPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), $"aws_resources_template_{DateTime.Now:yyMMddHHmmss}.xlsx");

            // setting template
            using (var stream = File.Open(tplBase, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var dest = new MemoryStream((int) stream.Length)) {
                stream.CopyTo(dest);
                using (var wbk = new XLWorkbook(dest)) {
                    var wsh = wbk.Worksheets.Worksheet("security_group");
                    wsh.Cell("A2").Value = $"{securityGroup.Count()} items";

                    wsh.Cell("A4").Value = "{{item." + nameof(SecurityGroupRule.VpcID) + "}}";
                    //wsh.Cell("B4").Value = "{{item." + nameof(SecurityGroupRule.Name) + "}}";
                    wsh.Cell("B4").Value = "{{item." + nameof(SecurityGroupRule.GroupName) + "}}";
                    wsh.Cell("C4").Value = "{{item." + nameof(SecurityGroupRule.GroupDescription) + "}}";
                    wsh.Cell("D4").Value = "{{item." + nameof(SecurityGroupRule.IngressOrEgress) + "}}";
                    wsh.Cell("E4").Value = "{{item." + nameof(SecurityGroupRule.SourcePort) + "}}";
                    wsh.Cell("F4").Value = "{{item." + nameof(SecurityGroupRule.Protocol) + "}}";
                    wsh.Cell("G4").Value = "{{item." + nameof(SecurityGroupRule.SourceType) + "}}";
                    wsh.Cell("H4").Value = "{{item." + nameof(SecurityGroupRule.Source) + "}}";
                    wsh.Cell("I4").Value = "{{item." + nameof(SecurityGroupRule.RuleDescription) + "}}";
                    wbk.NamedRanges.Add("Data", wsh.Ranges("A4:I5"));

                    // temporary
                    wsh.Column("C").Hide();

                    wbk.SaveAs(tplPath);
                }
            }

            // generate
            using (var tpl = new XLTemplate(tplPath)) {
                tpl.AddVariable(obj);
                tpl.Generate();
                var result = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), $"aws_resources_{DateTime.Now:yyMMddHHmmss}.xlsx");
                tpl.SaveAs(result);
                Process.Start(new ProcessStartInfo(result) { UseShellExecute = true });
            }

            File.Delete(tplPath);
        }
    }
}