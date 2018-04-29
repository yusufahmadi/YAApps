using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YLibs
{
    class ClassSQLServer
    {
        public static string SqlConn = "";
        public static string SqlConn2 = "";
        public DataSet ExecuteDataset(string tabel, string SQL,bool GunakanServer2= false) { 
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(GunakanServer2 ? SqlConn2 : SqlConn)) {
                using (SqlCommand cmd = new SqlCommand(SQL, con)) {
                    using (SqlDataAdapter ODA = new SqlDataAdapter(cmd)) {
                        try {
                            con.Open();
                            cmd.CommandTimeout = con.ConnectionTimeout;
                            if (ds.Tables[tabel] != null){
                                ds.Tables[tabel].Clear();
                            }
                            ODA.Fill(ds, tabel);
                        }
                        catch (Exception){
                            ds = null;
                        }
                    }
                }
            }
            return ds;
        }

        public int EksekusiSQL(string SQl, string KoneksiString = "", bool IsTampilError = true)
        {
            SqlConnection oConn = null /* TODO Change to default(_) if this is not a reference type */;
            SqlCommand ocmd = null /* TODO Change to default(_) if this is not a reference type */;
            int NoID=0;
            //string KoneksiStringAktif;
            //if (KoneksiString == "")
            //    KoneksiStringAktif = SqlConn;
            //else
            //    KoneksiStringAktif = SqlConn;
            try
            {
                oConn = new SqlConnection(SqlConn);
                ocmd = new SqlCommand(SQl, oConn);
                oConn.Open();
                ocmd.CommandTimeout = oConn.ConnectionTimeout;
                NoID = ClassConverter.NullToInt32(ocmd.ExecuteNonQuery());
             }
            catch (Exception)
            {
                //if (IsTampilError)
                //    XtraMessageBox.Show("Gagal mengeksekusi SQL :" + SQl + vbCrLf + ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                if (oConn != null)
                {
                    oConn.Close();
                    oConn.Dispose();
                }
            }
            return NoID;
        }

        public object EksekusiSQlSkalarNew(string strsql)
        {
            SqlConnection oConn = null /* TODO Change to default(_) if this is not a reference type */;
            SqlCommand ocmd = null /* TODO Change to default(_) if this is not a reference type */;
            object hasil = "";
            try
            {
                oConn = new SqlConnection(SqlConn);
                ocmd = new SqlCommand(strsql, oConn);
                oConn.Open();
                ocmd.CommandTimeout = oConn.ConnectionTimeout;
                hasil = ocmd.ExecuteScalar();
            }
            catch (Exception )
            {
            }
            finally
            {
                if (ocmd != null)
                    ocmd.Dispose();
                if (oConn != null)
                {
                    oConn.Close();
                    oConn.Dispose();
                }
            }
            return hasil;
        }

    }
}
