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
        private static DataTable IdAsIntArrayTable(List<int> ids)
        {
            DataTable Ids = new DataTable();
            Ids.Columns.Add("Id", typeof(int));
            foreach (int id in ids)
            {
                DataRow dataRow = Ids.NewRow();
                dataRow["Id"] = id;
                Ids.Rows.Add(dataRow);
            }
            return Ids;
        }

        public static void UpdateMultiLineData(string values, int editorId, int? retain = null)
        {
            //Create Datatable and send values
            try
            {
                editorId = 1;
                string[] arrValue = values.Split('\n');
                int ordinal = 1;
                int dataLength = 0;

                DataTable dataTable = new DataTable();
                // add static columns
                dataTable.Columns.Add("Ordinal", typeof(int));
                dataTable.Columns.Add("EditorId", typeof(int));
                dataTable.Columns.Add("Length", typeof(int));
                dataTable.Columns.Add("Characters", typeof(string));

                if (retain != null)
                {
                    ReaderData data = new EditorRepository().GetReaderData(editorId, retain??1);

                    int index = (retain??1) - (data.Length - data.Value.Length) + 1;
                    string firstSplitValues = data.Value.Substring(0, index);
                    string lastSplitValues = data.Value.Substring(index);

                    arrValue[0] = firstSplitValues + arrValue[0];
                    arrValue[arrValue.Length - 1] = arrValue[arrValue.Length - 1] + lastSplitValues;
                    dataLength = data.Length - (data.Value.Length + 1);
                    ordinal = data.Ordinal;
                }

                
                for (var i = 0; i < arrValue.Length; i++)
                {
                    dataLength += arrValue[i].Length + 1;
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["Ordinal"] = ordinal + i;
                    dataRow["EditorId"] = editorId;
                    dataRow["Length"] = dataLength;
                    dataRow["Characters"] = arrValue[i];
                    dataTable.Rows.Add(dataRow);
                }

                new EditorRepository().Add(dataTable, arrValue.Length - 1, editorId, dataLength, retain);
            }
            catch
            {
                throw;
            }
        }

        public static void InsertInitialData(string values, int editorId)
        {
            try
            {
                editorId = 1;
                string[] arrValue = values.Split('\n');
                int ordinal = 1;
                int dataLength = 0;

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Ordinal", typeof(int));
                dataTable.Columns.Add("EditorId", typeof(int));
                dataTable.Columns.Add("Length", typeof(int));
                dataTable.Columns.Add("Characters", typeof(string));

                for (var i = 0; i < arrValue.Length; i++)
                {
                    dataLength += arrValue[i].Length + 1;
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

        public static void UpdateSingleLineData(string values, int editorId, int retain)
        {
            //Create Datatable and send values
            try
            {
                editorId = 1;
                int ordinal = 1;
                int dataLength = 0;

                ReaderData data = new EditorRepository().GetReaderData(editorId, retain);

                int index = retain - (data.Length - data.Value.Length) + 1;
                string firstSplitValues = data.Value.Substring(0, index);
                string lastSplitValues = data.Value.Substring(index);

                values = firstSplitValues + values;
                dataLength = data.Length - (data.Value.Length + 1);
                ordinal = data.Ordinal;



                new EditorRepository().Update(data.Id, data.Ordinal, dataLength, values);
            }
            catch
            {
                throw;
            }
        }


        public static void DeleteAll(int index, int editorId, int retain)
        {
            try
            {
                if (index < 0)
                    return;

                ReaderData data = new EditorRepository().GetReaderData(editorId, retain);



                new EditorRepository().DeleteByIndex(index, editorId);
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

        public static void SegregateOperations(List<Operation> operations, int id, Guid userId = new Guid())
        {
            try
            
            {
                if(operations.Count() == 1)
                {
                    if(operations[0].Insert != null)
                    {
                        InsertInitialData(operations[0].Insert, id);
                    }
                    else if(operations[0].Delete != null)
                    {
                        DeleteAll(operations[0].Delete ?? -1, id, operations[0].Delete??1);
                    }

                }
                else if(operations.Count() == 2 && operations[0].Retain != null)
                {
                    if(operations[1].Delete != null)
                    {

                    }
                    else if(operations[1].Insert != null)
                    {
                        if(operations[1].Insert.Split('\n').Length == 1)
                        {
                            UpdateSingleLineData(operations[1].Insert, id, operations[0].Retain ?? 1);
                        }
                        else
                        {
                            UpdateMultiLineData(operations[1].Insert, id, operations[0].Retain ?? 1);
                        }
                    }

                }
                else if(operations.Count() == 3)
                {

                }
                else
                {
                    //Perform Following Algo
                    //Get Data from database using Retain value you have.
                    //Now loop over it and segregate each operations
                    //perform each operations as task to update to database.
                    throw new NotFound("TestCases Mising");

                }


                //if (operations.Count < 3 &&  operations[0].Delete != 0 || operations[1].Delete != 0)
                //{
                //    DeleteData(operations[0].Delete??operations[1].Delete, id, operations[0].Retain);
                //}
                //else if (operations[1].Attributes != null)
                //{
                //    UpdateDataAttributes(operations[0].Retain, id, operations[1]);
                //}
                //else
                //{
                //    throw new NotFound("TestCases Mising");
                //}

            }
            catch
            {
                throw;
            }
        }

    }

}