using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using YES.appcode;

namespace YES.Forms
{
    public partial class frm_test : Form
    {
      
        public frm_test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

    

        private void frm_test_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strsql = "SELECT  [seq],[ID_DATE] FROM [dbo].[tmpshareholder] WHERE [ID_DATE] IS NOT NULL";
            DataTable dt = Db.GetDataAsDataTable(strsql);
            foreach (DataRow dr in dt.Rows)
            {
                if (!Utility.IsValidDate(dr["ID_DATE"].ToString()))
                {
                    txt1.Text += dr["seq"].ToString() + " | " + dr["ID_DATE"].ToString();
                }
            }
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
           txt2.Text = Security.Cryptography.Decrypt(txt1.Text, true, txtKey.Text);
        }

        private void btnEnc_Click(object sender, EventArgs e)
        {
            txt2.Text = Security.Cryptography.Encrypt(txt1.Text, true, txtKey.Text);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var sim = Similarity.CalculateSimilarity(txt1.Text, txtKey.Text);
            lblSim.Text = sim.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var strsql = "select * from xmatch2";
            //DataTable dt = Db.GetDataAsDataTable(strsql);
            //foreach(DataRow dr in dt.Rows)
            //{
            //    var sim = Similarity.CalculateSimilarity(dr["fullname"].ToString(), dr["name"].ToString());
            //    var strsql2 = "update xmatch2 set similarity = " + sim.ToString() + " where cert_no = '"+ dr["cert_no"].ToString() + "'";
            //    Db.ExecuteSQLCommand(strsql2);
            //}
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            lblrandomPass.Text = RandomString(8);
        }
    }
    public class Similarity
    {
        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// </summary>
        private static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">Source String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        public static  double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
    }
}
