using Document.Library.Entity;
using Document.Library.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.ServiceLayer
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

        public static IEnumerable<FileEditor> GetAll(Guid userId)
        {
            try
            {
                return new EditorRepository().GetAll(userId);
            }
            catch
            {
                throw;
            }
        }


        //public static List<Operation> GetData(Guid userId, int id)
        //{
        //    try
        //    {
        //        List<ReaderData> data = new EditorRepository().GetData(userId, id);

        //        List<Operation> operation = new List<Operation>();
        //        foreach(ReaderData rd in data)
        //        {
        //            string startValue = rd.Value.Substring(0, ((rd.Attributes?.ElementAt(0).Start?? rd.Value.Length)));

        //            Operation ops = new Operation
        //            {
        //                Insert = startValue
        //            };

        //            operation.Add(ops);
        //            for(int i = 0, j = rd.Attributes.Count ; i < j; i++)
        //            {
        //                Attributor obj = rd.Attributes[i];
        //                Attributor atr = obj;
        //                string val = rd.Value.Substring(obj.Start??0 , obj.Length??0);

        //                Operation op = new Operation
        //                {
        //                    Insert = val,
        //                    Attributes =  atr
        //                };
        //                operation.Add(op);
        //                if( (i+1) != rd.Attributes.Count && (obj.Start + obj.Length) != rd.Value.Length)
        //                {
        //                    operation.Add(new Operation { Insert = rd.Value.Substring((obj.Start??0) + (obj.Length??0), ((rd.Attributes[i+1].Start??0) - ((obj.Start??0) + obj.Length??0))) });
        //                }
        //                else if((i+1) == rd.Attributes.Count)
        //                {
        //                    operation.Add(new Operation { Insert = rd.Value.Substring(obj.Start??0 + obj.Length??0) });
        //                }

        //            }

        //            //Decide Logic to add \n for data with length +1 than actual length
        //            //{
        //            //    int endIndex;
        //            //    Attributor lastAttributor = rd.Attributes.ElementAt(rd.Attributes.Count() - 1);
        //            //    endIndex = lastAttributor.Start - 1 + lastAttributor.Length;
        //            //    operation.Add(new Operation { Insert = rd.Value.Substring(endIndex) });
        //            //}

        //        }

        //        //List<ReaderData> opsToData = ConvertOpsToData(operation);

        //        return operation;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public static List<ReaderData> ConvertOpsToData(List<Operation> ops)
        {
            try
            {
                List<ReaderData> _readerData = new List<ReaderData>();
                List<Attributor> _attributes = new List<Attributor>();
                string value = "";
                int i = 0, j = ops.Count();
                int startIndexForAttributes = 0;

                /* Logic for Header is different, It always sets for new line.
                 * So when checking for header check for next attributes as newline and apply header to all its previous
                 */

                while (i < j)
                {

                    value += ops[i].Insert;
                    bool hasNewlineCharacter = value.Contains(Environment.NewLine);

                    if (ops[i].Attributes != null)
                    {
                        //ops[i].Attributes.Start = startIndexForAttributes;
                        //ops[i].Attributes.Length = ops[i].Insert.Length;
                        _attributes.Add(ops[i].Attributes);
                    }


                    while (!hasNewlineCharacter)
                    {
                        startIndexForAttributes = value.Length;
                        i++;
                        continue;
                    }

                    value = value.Split('\n').First();
                    ReaderData _data = new ReaderData()
                    {
                        Value = value,
                        Attributes = _attributes
                    };

                    startIndexForAttributes = 0;

                    _readerData.Add(_data);

                    value = value.Split('\n').Last();
                    i++;
                    _attributes = new List<Attributor>();
                }

                return _readerData;
            }
            catch
            {
                throw;
            }
        }


        public static FileEditor Create(string name, Guid userId)
        {
            try
            {
                return new EditorRepository().Create(name, userId);
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateMultiLineData(string values, int editorId, int? retain = null)
        {
            try
            {
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
                    ReaderData data = new EditorRepository().GetReaderData(editorId, retain ?? 1);

                    int index = (retain ?? 1) - (data.Length - data.Value.Length) + 1;
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

        /// <summary>
        /// A special case when user copy pasted data of one line with more than 250 characters.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="editorId"></param>
        public static void InsertInitialData(string values, int editorId)
        {
            try
            {
                string[] arrValue = values.Split('\n');
                int ordinal = 1;
                int dataLength = 0;

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Ordinal", typeof(int));
                dataTable.Columns.Add("EditorId", typeof(int));
                dataTable.Columns.Add("Length", typeof(int));
                dataTable.Columns.Add("Characters", typeof(string));

                string dataValue = "";
                for (var i = 0; i < arrValue.Length; i++)
                {
                    if (arrValue[i].Length > 250)
                    {
                        dataValue = arrValue[i].Substring(0, 250);
                        arrValue[i] = arrValue[i].Remove(0, 250);
                        i--;
                        dataLength += dataValue.Length; // This will ensure I don't need to add new line character
                    }
                    else
                    {
                        dataValue = arrValue[i];
                        dataLength += dataValue.Length + 1;
                    }

                    DataRow dataRow = dataTable.NewRow();
                    dataRow["Ordinal"] = ordinal++;
                    dataRow["EditorId"] = editorId;
                    dataRow["Length"] = dataLength;
                    dataRow["Characters"] = dataValue;
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
            try
            {
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


        public static void DeleteAll(int editorId, int startIndex, int length)
        {
            try
            {
                if (startIndex < 0)
                    return;

                //ReaderData data = new EditorRepository().GetReaderData(editorId, length);



                new EditorRepository().DeleteFromFirst(editorId, length);
            }
            catch
            {
                throw;
            }
        }


        public static void Delete(int editorId, int retain, int length)
        {
            try
            {
                new EditorRepository().DeleteByIndex(editorId, retain, length);
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
            /*
             * PTN: When inserting data in table make sure you are following following protocols:
             *      1. StartIndex Column in Attributor table will give correct index with reference to data length. Never relate it with length data present in ReaderData.
             *      2. When string length is overflowing your Character length in ReaderData, then split it by new line and never add +1 for new line character. 
             *          This will ensure to show correct format data on Editor.
             */
            try

            {
                //Works only for initial INSERT or DELETE.
                if (operations.Count() == 1)
                {
                    if (operations[0].Insert != null)
                    {
                        InsertInitialData(operations[0].Insert, id);//completed  //Trailing space does not work
                    }
                    else if (operations[0].Delete != null)
                    {
                        DeleteAll(id, 1, operations[0].Delete ?? 1); // COMPLETED //Trailing space does not work
                    }
                }
                /* 1. Works only for operation INSERT or DELETE between text.
                 * 2. Works for multiline entry for if only INSERT is done at different line within 5 second.
                 */
                else if (operations.Count() == 2 && operations[0].Retain != null)
                {
                    if (operations[1].Delete != null)
                    {
                        Delete(id, operations[0].Retain??0, operations[1].Delete??0);
                    }
                    else if (operations[1].Insert != null)
                    {
                        //Within 5 sec user inserted value with enter keyword
                        if (operations[1].Insert.Split('\n').Length == 1)
                        {
                            UpdateSingleLineData(operations[1].Insert, id, operations[0].Retain ?? 1); //Completed //Trailing space does not work
                        }
                        else
                        {
                            UpdateMultiLineData(operations[1].Insert, id, operations[0].Retain ?? 1);
                        }
                    }

                }
                else
                {

                    int retain = operations[0].Retain ?? 1;
                    ReaderData data = new EditorRepository().GetReaderData(id, retain);

                    List<ReaderData> readerData = RecurOperation(operations, id, 0, operations.Count(), null, data);
                    //Perform Following Algo
                    //Get Data from database using Retain value you have.
                    //Now loop over it and segregate each operations
                    //perform each operations as task to update to database.
                    //throw new NotFound("TestCases Mising");

                }
            }
            catch
            {
                throw;
            }
        }


        public static List<ReaderData> AggregateInsertOperations(int retain, string values, ReaderData previousIndexedData, Attributor attr = null, List<ReaderData> currentReaderList = null)
        {
            List<ReaderData> _data;
            ReaderData pushData = new ReaderData();

            string firstSplitValues = "";

            if (attr != null)
            {
                List<Attributor> _attributes = new List<Attributor>();

                //if (values.Contains("\n"))
                //{

                //}

                //attr.Start = currentReaderList[currentReaderList.Count() - 1].Value.Length;
                //attr.Length = values.Length;
                _attributes.Add(attr);
                pushData.Attributes = _attributes;
            }


            if (currentReaderList == null)
            {
                int index = (retain) - (previousIndexedData.Length - previousIndexedData.Value.Length) + 1;
                firstSplitValues = previousIndexedData.Value.Substring(0, index);
                currentReaderList = new List<ReaderData>();
                if (values.Contains("\n"))
                {
                    string firstValue = values.Split('\n').First();
                    string secondValue = values.Split('\n').Last();
                    values = firstSplitValues + firstValue; 
                    pushData.Value = values;
                    pushData.Length = previousIndexedData.Length - previousIndexedData.Value.Length + values.Length;
                    pushData.Ordinal = previousIndexedData.Ordinal;
                    currentReaderList.Add(pushData);

                    currentReaderList.Add(new ReaderData()
                    {
                        Value = secondValue,
                        Length = pushData.Length + secondValue.Length,
                        Ordinal = pushData.Ordinal + 1
                    });

                }
                else
                {
                    values = firstSplitValues + values;
                    pushData.Value = values;
                    pushData.Length = previousIndexedData.Length - previousIndexedData.Value.Length + values.Length;
                    pushData.Ordinal = previousIndexedData.Ordinal;
                    currentReaderList.Add(pushData);
                }

            }
            else
            {
                if (values.Contains("\n"))
                {
                    string firstValue = values.Split('\n').First();
                    string secondValue = values.Split('\n').Last();

                    currentReaderList[currentReaderList.Count() - 1].Value = currentReaderList[currentReaderList.Count() - 1].Value + firstValue;
                    currentReaderList[currentReaderList.Count() - 1].Length = currentReaderList[currentReaderList.Count() - 1].Length + firstValue.Length;

                    pushData.Value = secondValue;
                    pushData.Length = currentReaderList[currentReaderList.Count() - 1].Length + secondValue.Length;
                    pushData.Ordinal = currentReaderList[currentReaderList.Count() - 1].Ordinal + 1;


                    currentReaderList.Add(pushData);
                    pushData.Value = firstValue;
                }
                else
                {
                    currentReaderList[currentReaderList.Count() - 1].Value = currentReaderList[currentReaderList.Count() - 1].Value + values;
                    currentReaderList[currentReaderList.Count() - 1].Length = currentReaderList[currentReaderList.Count() - 1].Value.Length;
                }
            }



            //currentReaderList.Add(pushData);

            return currentReaderList;

        }

        public static void AggregateDeleteOperations(int editorId,int retain, int length)
        {
            Delete(editorId, retain, length);
        }



        private static List<ReaderData> RecurOperation(List<Operation> operations, int editorId, int start, int end, List<ReaderData> dt, ReaderData data)
        {

            int retain;
            if (start == end)
            {
                int index = (operations[0].Retain??0) - (data.Length - data.Value.Length) + 1;
                string lastSplitValues = data.Value.Substring(index);
                dt[dt.Count() - 1].Value = dt[dt.Count() - 1].Value + lastSplitValues;
                dt[dt.Count() - 1].Length = dt[dt.Count() - 1].Value.Length;
                return dt;
            }

            if (operations[start].Retain != null)
            {
                retain = operations[start].Retain ?? 0;
                if (operations[start + 1].Insert != null && operations[start + 1].Attributes != null)
                {
                    dt = AggregateInsertOperations(retain, operations[start + 1].Insert, data, operations[start + 1].Attributes, dt);
                    return RecurOperation(operations, editorId, start + 2, end, dt, data);
                }
                if (operations[start + 1].Delete != null)
                {
                    AggregateDeleteOperations(editorId, retain, operations[start + 1].Delete ?? 0);
                    return RecurOperation(operations, editorId, start + 2, end, dt, data);

                }
                if (operations[start + 1].Insert != null)
                {

                    //UpdateMultiLineData(operations[start + 1].Insert, editorId, operations[start].Retain);
                    return RecurOperation(operations, editorId, start + 2, end, dt, data);
                }
                if (operations[start + 1].Retain != null && operations[start + 1].Attributes != null) //
                {
                    return RecurOperation(operations, editorId, start + 2, end, dt, data);
                }
                if(operations[start].Attributes != null) // Example: If your previous line consists of Header attributor.
                {
                    return RecurOperation(operations, editorId, start + 1, end, dt, data);
                }
            }
            if(operations[start].Insert != null && operations[start].Attributes != null)
            {
                return RecurOperation(operations, editorId, start + 1, end, dt, data);
            }
            if (operations[start].Insert != null)
            {
                return RecurOperation(operations, editorId, start + 1, end, dt, data);
            }
            if (operations[start].Delete != null)
            {
                return RecurOperation(operations, editorId, start + 1, end, dt, data);
            }
            else
            {
                return dt;
            }

            //return reader;

        }


    }

}
