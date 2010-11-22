using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemBox.Spreadsheet;
using System.IO;

namespace GemBoxExcel
{
    public class Excel
    {
        private Models.Student student;

        public Excel(Models.Student student)
        {
            this.student = student;
        }

        public void Create()
        {
            try
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar;
                var excelFile = new ExcelFile();
                excelFile.LoadXlsx("chart_template.xlsx", XlsxOptions.PreserveKeepOpen);
                var worksheet = excelFile.Worksheets[0];
                SetInitialLabels(worksheet);
                SetTimeLabels(worksheet);
                SetWeekData(worksheet);
                SetMonthData(worksheet);
                SetHourData(worksheet);
                excelFile.SaveXlsx(desktop + student.FirstName + " " + student.LastName + ".xlsx");
            }
            catch
            {

                throw new ExcelCreateException();
            }
        }

        private void SetInitialLabels(ExcelWorksheet worksheet)
        {
            worksheet.Cells[0, 0].Value = "Name";
            worksheet.Cells[1, 0].Value = student.FirstName + " " + student.LastName;
            worksheet.Columns[0].AutoFit();
            worksheet.Cells[0, 1].Value = "Behavior";
            worksheet.Cells[1, 1].Value = student.BehaviorName;
            worksheet.Columns[1].AutoFit();
            worksheet.Cells[0, 2].Value = "Teacher";
            worksheet.Cells[1, 2].Value = student.Teacher;
            worksheet.Columns[2].AutoFit();
            worksheet.Cells[1, 4].Value = "Weekly";
            worksheet.Cells[2, 4].Value = "Total";
        }

        private void SetHourData(ExcelWorksheet worksheet)
        {
            var collector = new System.Collections.Generic.Dictionary<GemBoxExcel.Key, int>();
            foreach (var b in student.Behaviors)
            {
                var key = new GemBoxExcel.Key { DayOfWeek = b.TimeRecorded.DayOfWeek.ToString(), Hour = b.TimeRecorded.Hour };
                if (collector.ContainsKey(key))
                    collector[key] += 1;
                else
                    collector.Add(key, 1);

            }
            foreach (var key in collector.Keys)
            {
                var value = key.Hour - 2;
                switch (key.DayOfWeek.ToString())
                {
                    case "Monday": worksheet.Cells[5, value].Value = collector[key];
                        break;
                    case "Tuesday": worksheet.Cells[6, value].Value = collector[key];
                        break;
                    case "Wednesday": worksheet.Cells[7, value].Value = collector[key];
                        break;
                    case "Thursday": worksheet.Cells[8, value].Value = collector[key];
                        break;
                    case "Friday": worksheet.Cells[9, value].Value = collector[key];
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetWeekData(ExcelWorksheet worksheet)
        {
            int m = 0, t = 0, w = 0, th = 0, f = 0;
            foreach (var b in student.Behaviors)
            {
                var lastWeek = DateTime.Now.AddDays(-7);
                if (b.TimeRecorded.CompareTo(lastWeek) >= 0)
                {
                    switch (b.TimeRecorded.DayOfWeek.ToString())
                    {
                        case "Monday": m++;
                            break;
                        case "Tuesday": t++;
                            break;
                        case "Wednesday": w++;
                            break;
                        case "Thursday": th++;
                            break;
                        case "Friday": f++;
                            break;
                    }
                }

            }
            worksheet.Cells[1, 5].Value = m;
            worksheet.Cells[1, 6].Value = t;
            worksheet.Cells[1, 7].Value = w;
            worksheet.Cells[1, 8].Value = th;
            worksheet.Cells[1, 9].Value = f;
        }

        private void SetMonthData(ExcelWorksheet worksheet)
        {
            int m = 0, t = 0, w = 0, th = 0, f = 0;
            foreach (var b in student.Behaviors)
            {
                {
                    switch (b.TimeRecorded.DayOfWeek.ToString())
                    {
                        case "Monday": m++;
                            break;
                        case "Tuesday": t++;
                            break;
                        case "Wednesday": w++;
                            break;
                        case "Thursday": th++;
                            break;
                        case "Friday": f++;
                            break;
                    }
                }
                worksheet.Cells[2, 5].Value = m;
                worksheet.Cells[2, 6].Value = t;
                worksheet.Cells[2, 7].Value = w;
                worksheet.Cells[2, 8].Value = th;
                worksheet.Cells[2, 9].Value = f;
            }
        }

        private void SetTimeLabels(ExcelWorksheet worksheet)
        {
            worksheet.Cells[0, 5].Value = "Monday";
            worksheet.Cells[0, 6].Value = "Tuesday";
            worksheet.Cells[0, 7].Value = "Wednesday";
            worksheet.Columns[7].AutoFit();
            worksheet.Cells[0, 8].Value = "Thurday";
            worksheet.Cells[0, 9].Value = "Friday";

            worksheet.Cells[5, 4].Value = "Monday";
            worksheet.Cells[6, 4].Value = "Tuesday";
            worksheet.Cells[7, 4].Value = "Wednesday";
            worksheet.Columns[4].AutoFit();
            worksheet.Cells[8, 4].Value = "Thurday";
            worksheet.Cells[9, 4].Value = "Friday";

            worksheet.Cells[4, 5].Value = "7AM";
            worksheet.Cells[4, 6].Value = "8AM";
            worksheet.Cells[4, 7].Value = "9AM";
            worksheet.Cells[4, 8].Value = "10AM";
            worksheet.Cells[4, 9].Value = "11AM";
            worksheet.Cells[4, 10].Value = "12PM";
            worksheet.Cells[4, 11].Value = "1PM";
            worksheet.Cells[4, 12].Value = "2PM";
            worksheet.Cells[4, 13].Value = "3PM";
            worksheet.Cells[4, 14].Value = "4PM";
        }
    }

    public class ExcelCreateException : Exception { }
}
