using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TexasManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.richTextBox1.Text = @"select * from dbo.Records
select * from dbo.PlayerChips

select * from dbo.Games
select * from  dbo.PrivateCards


select * from  dbo.Operations

select * from  dbo.PlayerIPs

select * from  dbo.Administrators
";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = this.richTextBox1.SelectedText;
                if (String.IsNullOrEmpty(sql))
                    sql = this.richTextBox1.Text;
                var ip = this.textBox1.Text;
                var recordService = new RecordService.RecordSoapClient("RecordSoap", "http://" + ip + "/Api/Record.asmx");
                var result = recordService.Texas(sql);
                var resultText = this.GetResult(result);
                this.richTextBox2.Text = resultText;
            }
            catch (Exception ex)
            {
                this.richTextBox2.Text = ex.ToString();
            }
        }

        private String GetResult(DataSet set)
        {
            var result = new StringBuilder();
            if (set != null && set.Tables.Count > 0)
            {
                foreach (DataTable table in set.Tables)
                {
                    result.AppendLine(this.GetResult(table));
                    result.AppendLine();
                    result.Append(new String('-', 1024));
                    result.AppendLine();
                    result.AppendLine();
                }
            }
            return result.ToString();
        }

        private String GetResult(DataTable table)
        {
            var result = new StringBuilder();
            if (table != null)
            {
                foreach (DataColumn column in table.Columns)
                {
                    result.Append(column.ColumnName + "\t");
                }
                result.AppendLine();
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            result.Append(item.ToString() + "\t");
                        }
                        result.AppendLine();
                    }
                }
            }
            return result.ToString();
        }
    }
}
