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
        public void Create(Models.Student student)
        {
            var excelFile = new ExcelFile();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar;
            var excelWorksheet = excelFile.Worksheets.Add("Student Breakdown");
            SetInitialFields(student, excelWorksheet);

            excelFile.SaveXlsx(desktop + Guid.NewGuid().ToString() + ".xlsx");
        }

        private static void SetInitialFields(Models.Student student, ExcelWorksheet excelWorksheet)
        {
            excelWorksheet.Cells[0, 0].Value = "Name";
            excelWorksheet.Cells[1, 0].Value = student.FirstName + " " + student.LastName;
            excelWorksheet.Columns[0].AutoFit();
            excelWorksheet.Cells[0, 1].Value = "Behavior";
            excelWorksheet.Cells[1, 1].Value = student.BehaviorName;
            excelWorksheet.Columns[1].AutoFit();
            excelWorksheet.Cells[0, 2].Value = "Teacher";
            excelWorksheet.Cells[1, 2].Value = student.Teacher;
            excelWorksheet.Columns[2].AutoFit();
            excelWorksheet.Cells[2, 4].Value = "Weekly";
            excelWorksheet.Cells[3, 4].Value = "Total"; 
        }
    }
}
