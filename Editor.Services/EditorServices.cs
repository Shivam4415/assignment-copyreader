using Editor.Entity.Data;
using Editor.Entity.Exceptions;
using Editor.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Editor.Services
{
    public static class EditorServices
    {
        public static void InsertData(string values, int editorId, int? retain = null)
        {
            //Create Datatable and send values
            try
            {
                editorId = 1;
                string[] arrValue = values.Split('\n');
                int ordinal = 1;


                DataTable dataTable = new DataTable();
                // add static columns
                dataTable.Columns.Add("Ordinal", typeof(int));
                dataTable.Columns.Add("EditorId", typeof(int));
                dataTable.Columns.Add("Length", typeof(int));
                dataTable.Columns.Add("Characters", typeof(string));

                if (retain != null)
                {
                    int i = 0;
                    IEnumerable<ReaderData> readerData = new EditorRepository().GetReaderData(editorId, retain??1);
                    foreach(ReaderData data in readerData)
                    {
                        int tempOrdinal = data.Ordinal;
                        int tempLength = data.Length;
                        string value = data.Value;
                        int insertValueLength = arrValue[i].Length;
                        int index = tempLength - insertValueLength;
                        string updatedValue = data.Value.Substring(0,index) + arrValue[i];
                        string lastString = data.Value.Substring(index);

                        data.Value = updatedValue;
                        data.Length = updatedValue.Length;
                        ordinal = data.Ordinal;
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["Ordinal"] = ordinal + i;
                        dataRow["EditorId"] = editorId;
                        dataRow["Length"] = updatedValue.Length;
                        dataRow["Characters"] = updatedValue;
                        dataTable.Rows.Add(dataRow);
                        i++;
                    }

                }

                int dataLength = 0;
                for (var i = 0; i < arrValue.Length; i++)
                {
                    dataLength += arrValue[i].Length;
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["Ordinal"] = ordinal + i;
                    dataRow["EditorId"] = editorId;
                    dataRow["Length"] = dataLength;
                    dataRow["Characters"] = arrValue[i];
                    dataTable.Rows.Add(dataRow);
                }

                new EditorRepository().Add(dataTable);
            }
            catch
            {
                throw;
            }
        }


        public static void DeleteData(int? index, int editorId, int? retain = null)
        {
            try
            {
                //new EditorRepository().Delete(values, retain);
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateDataAttributes(int? retain, int editorId, Operation ops)
        {
            try
            {
                //new EditorRepository().Delete(values, retain);
            }
            catch
            {
                throw;
            }
        }

        public static void DeleteAndInsertData(int editorId, int? retain, string values, int? deleteIndex)
        {
            try
            {
                //new EditorRepository().Delete(values, retain);
            }
            catch
            {
                throw;
            }
        }

        public static void Add(List<Operation> operations, int id, Guid userId = new Guid())
        {
            try
            
            {
                if (operations.Count < 3 && operations[0].Insert != null || operations[1].Insert != null)
                {
                    InsertData(operations[0].Insert?? operations[1].Insert, id, operations[0].Retain);
                }
                else if (operations.Count < 3 &&  operations[0].Delete != 0 || operations[1].Delete != 0)
                {
                    DeleteData(operations[0].Delete??operations[1].Delete, id, operations[0].Retain);
                }
                else if (operations[1].Attributes != null)
                {
                    UpdateDataAttributes(operations[0].Retain, id, operations[1]);
                }
                else
                {
                    throw new NotFound("TestCases Mising");
                }

            }
            catch
            {
                throw;
            }
        }

    }

}