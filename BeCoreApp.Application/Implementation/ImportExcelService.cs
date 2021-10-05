using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Common;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Implementation
{
    public class ImportExcelService : IImportExcelService
    {
        public Task<List<MemberBalanceModel>> ExtractMemberBalanceFromFile(ImportExcelModel model)
        {
            if (!ValidateFileType(model.FileUpload.FileName)) return null;

            var excelReaderImport = GetExcelDataReader(model.FileUpload);

            var dataSet = excelReaderImport.AsDataSet(new ExcelDataSetConfiguration { 
            
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = false,
                    FilterRow = rowReader =>
                    {
                        var hasData = false;
                        for (var i = 0; i < rowReader.FieldCount; i++)
                        {
                            if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString()))
                            {
                                continue;
                            }

                            hasData = true;
                            break;
                        }

                        return hasData;
                    },
                    // use ExcelDataTableConfiguration.FilterColumn to filter empty columns
                    FilterColumn = (rowReader, colIndex) =>
                    {
                        var hasData = false;
                        rowReader.Reset();

                        // this will skip first row as it is name of column
                        rowReader.Read();

                        while (rowReader.Read())
                        {
                            if (rowReader[colIndex] == null ||
                                string.IsNullOrEmpty(rowReader[colIndex].ToString()))
                            {
                                continue;
                            }

                            hasData = true;
                            break;
                        }

                        // below codes do a trick!
                        rowReader.Reset();
                        rowReader.Read();

                        return hasData;
                    }
                }
            });

            var memberDatas = new List<MemberBalanceModel>();

            for (int i = 1; i < dataSet.Tables[0].Rows.Count; i++)
            {
                DataRow item = dataSet.Tables[0].Rows[i];

                var memberBalance = new MemberBalanceModel
                {
                    Balance = decimal.Parse(item[1].ToString()),
                    Email = item[0].ToString().Trim()
                };

                memberDatas.Add(memberBalance);
            }

            return Task.FromResult(memberDatas);
        }
        private IExcelDataReader GetExcelDataReader(IFormFile file)
        {
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(file.OpenReadStream());
            return excelDataReader;
        }
        private bool ValidateFileType(string fileName)
        {
            return Path.GetExtension(fileName).ToLower() == ".xlsx";
        }
    }
}
