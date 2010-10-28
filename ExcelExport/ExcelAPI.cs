using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;


public class ExeclAPI
{
    Range dataRange = null;
    public void SetCellValue(Worksheet targetSheet, string Cell, object Value)
    {
        targetSheet.get_Range(Cell, Cell).set_Value(XlRangeValueDataType.xlRangeValueDefault, Value);
    }

    public void ExcelMain(Models.Student student)
    {
        var lname = student.LastName;
        // Declare a variable for the Excel ApplicationClass instance.
        Application excelApplication = null;
        Workbook newWorkbook = null;
        Worksheet targetSheet = null;
        ChartObjects chartObjects = null;
        ChartObject newChartObject = null;

        // Declare variables for the Workbooks.Open method parameters. 
        string paramWorkbookPath = student.LastName+"-"+student.FirstName+".xlsx";
        object paramMissing = Type.Missing;

        // Declare variables for the Chart.ChartWizard method.
        object paramChartFormat = 1;
        object paramCategoryLabels = 0;
        object paramSeriesLabels = 0;
        bool paramHasLegend = true;
        object paramTitle = "Daily Breakdown for:" + student.LastName + "-" + student.FirstName;
        object paramCategoryTitle = "Days of the Week";
        object paramValueTitle = "# of offenses recorded";

        try
        {
            // Create an instance of the Excel ApplicationClass object.          
            excelApplication = new Application();

            // Create a new workbook with 1 sheet in it.
            newWorkbook = excelApplication.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            // Change the name of the sheet.
            targetSheet = (Worksheet)(newWorkbook.Worksheets[1]);
            targetSheet.Name = "Student";
            SetCellValue(targetSheet, "A1", "Name");
            SetCellValue(targetSheet, "B1", "Behavior");
            SetCellValue(targetSheet, "C1", "Teacher");

            loadStudent(targetSheet, student);

            setWeekly(targetSheet, student);
            setMonthly(targetSheet, student);
            setForm(targetSheet);

            setHourlyRecord(targetSheet, student);

            dataRange = targetSheet.get_Range("A1", "J1");
            dataRange.EntireColumn.AutoFit();

            // Get the range holding the chart data.
            dataRange = targetSheet.get_Range("E1", "J3");

            // Get the ChartObjects collection for the sheet.
            chartObjects = (ChartObjects)(targetSheet.ChartObjects(paramMissing));

            // Add a Chart to the collection.
            newChartObject = chartObjects.Add(0, 200, 300, 300);

            // Create a new chart of the data.
            newChartObject.Chart.ChartWizard(dataRange, XlChartType.xl3DColumn, paramChartFormat, XlRowCol.xlRows,
                paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

            //////////////////////////////////////////////
            //          Hourly Breakdown Chart          //
            //////////////////////////////////////////////

            paramTitle = "Hourly Breakdown for: " + student.LastName + "-" + student.FirstName;

            // Get the range holding the chart data.
            dataRange = targetSheet.get_Range("E5", "O10");

            // Get the ChartObjects collection for the sheet.
            chartObjects = (ChartObjects)(targetSheet.ChartObjects(paramMissing));

            // Add a Chart to the collection.
            newChartObject = chartObjects.Add(400, 200, 300, 300);

            // Create a new chart of the data.
            newChartObject.Chart.ChartWizard(dataRange, XlChartType.xl3DColumn, paramChartFormat, XlRowCol.xlRows,
                paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

            // Save the workbook.
            newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
                paramMissing, XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // Release the references to the Excel objects.
            newChartObject = null;
            chartObjects = null;
            dataRange = null;
            targetSheet = null;


            // Show Excel and release the ApplicationClass object.
            if (excelApplication != null)
            {
                excelApplication.Visible = true;
                excelApplication.UserControl = true;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
    public void loadStudent(Worksheet targetSheet, Models.Student student)
    {
        SetCellValue(targetSheet, "A2", student.FirstName + " " +student.LastName);
        SetCellValue(targetSheet, "B2", student.BehaviorName);
        SetCellValue(targetSheet, "C2", student.Teacher);
        SetCellValue(targetSheet, "E2", "Weekly");
        SetCellValue(targetSheet, "E3", "Total");
    }
    public void setHourlyRecord(Worksheet targetSheet, Models.Student student)
    {
        var collector = new System.Collections.Generic.Dictionary<ExcelExport.Key, int>();
        foreach (var b in student.Behaviors)
        {
            var key = new ExcelExport.Key { DayOfWeek = b.TimeRecorded.DayOfWeek.ToString(), Hour = b.TimeRecorded.Hour };
            if (collector.ContainsKey(key))
                collector[key] += 1;
            else
                collector.Add(key, 1);

        }
        foreach (var key in collector.Keys)
        {
            var value = key.Hour - 1;
                switch (key.DayOfWeek.ToString())
                {
                    case "Monday": ((Range)(targetSheet.Cells[6, value])).Value = collector[key];
                        break;
                    case "Tuesday": ((Range)(targetSheet.Cells[7, value])).Value = collector[key];
                        break;
                    case "Wednesday": ((Range)(targetSheet.Cells[8, value])).Value = collector[key];
                        break;
                    case "Thursday": ((Range)(targetSheet.Cells[9, value])).Value = collector[key];
                        break;
                    case "Friday": ((Range)(targetSheet.Cells[10, value])).Value = collector[key];
                        break;
                    default:
                        break;
                }
            }

        }
    
    public void setWeekly(Worksheet targetSheet, Models.Student student)
    {
        int m = 0,t = 0,w = 0,th = 0,f = 0;
        foreach(var b in student.Behaviors)
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
        SetCellValue(targetSheet, "F2", m);
        SetCellValue(targetSheet, "G2", t);
        SetCellValue(targetSheet, "H2", w);
        SetCellValue(targetSheet, "I2", th);
        SetCellValue(targetSheet, "J2", f);
        
    }
    public void setMonthly(Worksheet targetSheet, Models.Student student)
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
            SetCellValue(targetSheet, "F3", m);
            SetCellValue(targetSheet, "G3", t);
            SetCellValue(targetSheet, "H3", w);
            SetCellValue(targetSheet, "I3", th);
            SetCellValue(targetSheet, "J3", f);

        }
    }
    public void setForm(Worksheet targetSheet)
    {
        SetCellValue(targetSheet, "F1", "Monday");
        Range oRange = (Range)targetSheet.get_Range("F1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "G1", "Tuesday");
        oRange = (Range)targetSheet.get_Range("G1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "H1", "Wednesday");
        oRange = (Range)targetSheet.get_Range("H1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "I1", "Thursday");
        oRange = (Range)targetSheet.get_Range("I1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "J1", "Friday");
        oRange = (Range)targetSheet.get_Range("J1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "E6", "Monday");
        oRange = (Range)targetSheet.get_Range("F1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "E7", "Tuesday");
        oRange = (Range)targetSheet.get_Range("G1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "E8", "Wednesday");
        oRange = (Range)targetSheet.get_Range("H1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "E9", "Thursday");
        oRange = (Range)targetSheet.get_Range("I1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "E10", "Friday");
        oRange = (Range)targetSheet.get_Range("J1", Type.Missing);
        oRange.Columns.AutoFit();
        SetCellValue(targetSheet, "F5", "7AM");
        SetCellValue(targetSheet, "G5", "8AM");
        SetCellValue(targetSheet, "H5", "9AM");
        SetCellValue(targetSheet, "I5", "10AM");
        SetCellValue(targetSheet, "J5", "11AM");
        SetCellValue(targetSheet, "K5", "12PM");
        SetCellValue(targetSheet, "L5", "1PM");
        SetCellValue(targetSheet, "M5", "2PM");
        SetCellValue(targetSheet, "N5", "3PM");
        SetCellValue(targetSheet, "O5", "4PM");
    }
}

