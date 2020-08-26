using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Library.Globals
{
    public static class GlobalFunctions
    {
        public static decimal RemoveTrailingZeros(decimal num)
        {
            string str = Convert.ToString(num);
            string[] strParts = str.Split('.');
            if (strParts.Length == 2)
            {
                return Convert.ToDecimal(strParts[0] + "." + strParts[1].TrimEnd('0'));
            }
            else
            {
                return num;
            }
        }

        /// <summary>
        /// Using to send DataTable parameter in Store procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">list of objects</param>
        /// <param name="propertyName"></param>
        /// <returns>DataTable</returns>
        public static DataTable ListToIdDataTable<T>(List<T> list, string propertyName = "InternalId")
        {
            DataTable Ids = new DataTable();
            Ids.Columns.Add("Id", typeof(int));
            if (typeof(T).GetProperty(propertyName) != null)
            {
                foreach (T t in list)
                {
                    DataRow dataRow = Ids.NewRow();
                    dataRow["Id"] = typeof(T).GetProperty(propertyName).GetValue(t);
                    Ids.Rows.Add(dataRow);
                }
            }
            else
            {
                throw new Exception("ListToIdDataTable : Object " + typeof(T) + " does not contain property " + propertyName);
            }

            return Ids;
        }


        /// <summary>
        /// Using to send DataTable parameter in Store procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">list of int</param>
        /// <returns>DataTable</returns>
        public static DataTable ListToIdDataTable(List<int> list)
        {
            DataTable Ids = new DataTable();
            Ids.Columns.Add("Id", typeof(int));
            foreach (int id in list)
            {
                DataRow dataRow = Ids.NewRow();
                dataRow["Id"] = id;
                Ids.Rows.Add(dataRow);
            }
            return Ids;
        }

        /// <summary>
        /// Using to send DataTable parameter in Store procedure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">list of string</param>
        /// <returns>DataTable</returns>
        public static DataTable ListToStringIdDataTable(List<string> list)
        {
            DataTable Ids = new DataTable();
            Ids.Columns.Add("Id", typeof(string));
            foreach (string id in list)
            {
                DataRow dataRow = Ids.NewRow();
                dataRow["Id"] = id;
                Ids.Rows.Add(dataRow);
            }

            return Ids;
        }


        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            foreach (var i in source)
            {
                func(i);
            }
            return source;
        }

    }
}
