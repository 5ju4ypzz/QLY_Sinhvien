using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLY_Sinhvien
{
    public static class Mypublic
    {
        public static SqlConnection conMyConnection;
        public static string strsever, strMSSV, strLop, strQuyensd, strHK, strNK;

        public static void ConnectionDatabase()
        {
            string strConn = "Server= " + strsever + "; Database = QL_SinhVien; Integrated Security = false; UID = TN207User; PWD = TN207User";
            conMyConnection = new SqlConnection();
            conMyConnection.ConnectionString = strConn;
            try
            {
                conMyConnection.Open();
            }
            catch (Exception)
            {
            }
        }
        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName, SqlDataAdapter daDataAdapter)
        {
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();                                
                daDataAdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                SqlCommandBuilder cmbCommandBuider = new SqlCommandBuilder(daDataAdapter);
                daDataAdapter.Fill(dsDatabase, strTableName);
                conMyConnection.Close();

            }
            catch (Exception)
            {
            }
        }
        public static void OpenData(string strSelect, DataSet dsDatabase, string strTableName)
        {
            SqlDataAdapter daDataAdapter = new SqlDataAdapter();
            try
            {
                if (conMyConnection.State == ConnectionState.Closed)
                    conMyConnection.Open();
                daDataAdapter.SelectCommand = new SqlCommand(strSelect, conMyConnection);
                
                daDataAdapter.Fill(dsDatabase, strTableName);
                conMyConnection.Close();

            }
            catch (Exception)
            {
            }
        }
        public static string MaHoaPassword(string strPassword) {
            string strTemp1, strTemp2;
            int i, n;
            strTemp1 = "";
            strTemp2 = "";
            n = strPassword.Length;
            for (i = 0; i < n;i=i+2 ) {
                strTemp1 += strPassword[i];
                if (n > i + 1)
                    strTemp2 += strPassword[i + 1];
            }
            return (strTemp1+strTemp2);
        }
        public static bool TonTaiKhoaChinh(string strGiaTri, string strTenTruong, string strTable)
        {
            SqlCommand cmdCommand;
            SqlDataReader drReader;
            bool blnResult = false;
            try
            {
                string sqlSelect = "Select 1 From" + strTable + " Where " + strTenTruong + "='" + strGiaTri + "'";
                if (conMyConnection.State == ConnectionState.Closed)
                conMyConnection.Open();
                cmdCommand = new SqlCommand(sqlSelect, conMyConnection);
                drReader = cmdCommand.ExecuteReader();
                if(drReader.HasRows)
                    blnResult = true; 
                drReader.Close();
                conMyConnection.Close();
            }
            catch (Exception)
            { 
            
            }
            return blnResult;
        }
        public static void XacDinhHKNK()
        {
            int thang = DateTime.Today.Month;
            if (thang <= 5)
            {
                strHK = "2";
                strNK = (DateTime.Today.Year - 1) + "-" + (DateTime.Today.Year);
            }
            else
                if (thang <= 7)
                {
                    strHK = "3";
                    strNK = (DateTime.Today.Year - 1) + "-" + (DateTime.Today.Year);
                }
                else
                {
                    strHK = "1";
                    strNK = (DateTime.Today.Year) + "-" + (DateTime.Today.Year + 1);
                }
        }
    }
}
