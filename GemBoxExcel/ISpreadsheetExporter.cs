using System;
namespace SpreadsheetExport
{
    /// <summary>
    /// This interface encapsulates the logic of exporting a student's
    /// information to a spreadsheet file for review. The implementation
    /// included is SpreadsheetExporter.
    /// </summary>
    public interface ISpreadsheetExporter
    {
        /// <summary>
        /// Create an Excel spreadsheet for a student. Throws an ExcelCreateException if
        /// creation fails.
        /// </summary>
        void Export(Models.Student student);
    }
}
