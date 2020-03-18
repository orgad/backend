using System;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace dotnet_wms_ef
{
    public class ExcelIOService
    {
        public string basePath="";

        public DataTable Import(IFormFile excelfile,string domain, string code)
        {
            var sFileName = basePath + "\\files\\"+domain+"\\" + code + ".xls";
            var sPath = basePath + "\\files\\"+domain;

            FileInfo file = new FileInfo(sFileName);
            if(!Directory.Exists(sPath))
            { 
                Directory.CreateDirectory(basePath+"\\files");
                Directory.CreateDirectory(basePath+"\\files\\"+domain);
            }

            if (!file.Exists)
            {
                // 生成文件
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
                {
                    excelfile.CopyTo(fs);
                    fs.Flush();
                }
            }

            //写数据
            return ImportData(file, true);
        }

        public string Export(string code, string domain,DataTable dt)
        {
            var sFileName = code + ".xls";
            var fullFileName = basePath + "\\"+domain+"\\" + sFileName;
            if (!File.Exists(fullFileName))
            {
                FileInfo file = new FileInfo(fullFileName);

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    // 添加worksheet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(code);
                    //添加头
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                    }
                    //添加值
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dt.Rows[i][j].ToString();
                        }
                    }
                    package.Save();
                }
            }
            return fullFileName;
        }

        private DataTable ImportData(FileInfo file, bool bHeaderRow)
        {
            DataTable dataTable = new DataTable();
            int startIndex = 0;

            using (ExcelPackage package = new ExcelPackage(file))
            {
                StringBuilder sb = new StringBuilder();
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                if (bHeaderRow)
                {
                    for (int col = 1; col <= ColCount; col++)
                    {
                        var colName = worksheet.Cells[1, col].Value.ToString();
                        dataTable.Columns.Add(colName);
                    }
                    startIndex = 2;
                }

                for (int row = startIndex; row <= rowCount; row++)
                {
                    DataRow dr = dataTable.NewRow();
                    for (int col = 1; col <= ColCount; col++)
                    {
                        dr[col - 1] = worksheet.Cells[row, col].Value.ToString();
                    }
                    dataTable.Rows.Add(dr);
                }
            }
            return dataTable;
        }

    }
}