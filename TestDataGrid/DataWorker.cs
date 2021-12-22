using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDataGrid
{
    internal class DataWorker
    {
        public event EventHandler<EventArgs> DataChanged;


        public DataWorker()
        {
            column.DataType = Type.GetType("System.UInt64");
            column.ColumnName = "DATA";
            dt.Columns.Add(column);
        }

        public DataTable dt = new DataTable();
        private DataColumn column = new DataColumn();        

        public void RunThread()
        {
            Thread th = new Thread(DataChange);
            th.Start();
        }
        private void DataChange()
        {
            while (true)
            {
                dt.Clear();
                dt.Rows.Add(new object[] { DateTime.Now.Ticks });
                DataChanged?.Invoke(this, EventArgs.Empty);
                Thread.Sleep(1000);
            }
                
        }

    }
}
