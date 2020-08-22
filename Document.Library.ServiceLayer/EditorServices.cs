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


        private static DataTable ReaderDatatable(string[] arrValue, int dataLength, int ordinal, int editorId)
        {
            DataTable dataTable = new DataTable();
            // add static columns
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

            return dataTable;
        }

        public static IEnumerable<FileEditor> GetAll(int userId)
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

        public static FileEditor Create(string name, int userId)
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
 
        public static void DeleteAll(int editorId, int startIndex, int length)
        {
            try
            {
                if (startIndex < 0)
                    return;

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
    }

}
