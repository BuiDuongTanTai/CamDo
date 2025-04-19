using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace CamDo.Models
{
    class connection_sql
    {
        public static string sqlcon = "Data Source=TAIBUI;Initial Catalog=CamDo;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection Getconnection()
        {
            SqlConnection con = new SqlConnection(sqlcon);
            return con;
        }

        public static void open()
        {
            try
            {
                if (Getconnection().State == ConnectionState.Closed)
                    Getconnection().Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public static void close()
        {
            try
            {
                if (Getconnection().State == ConnectionState.Open)
                    Getconnection().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public static DataSet FillDataSet(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, Getconnection());
                da.Fill(ds);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return ds;
        }
        public static DataSet FillDataSet(string sql, string table)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, Getconnection());
                da.Fill(ds, table);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return ds;
        }


        public static DataSet FillDataSet(string strQuery, CommandType cmdtype)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return ds;
        }

        public static DataSet FillDataSet(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlParameter sqlpara;
                for (int i = 0; i < para.Length; i++)
                {
                    sqlpara = new SqlParameter();
                    sqlpara.ParameterName = para[i];
                    sqlpara.SqlValue = values[i];

                    cmd.Parameters.Add(sqlpara);
                }

                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(ds);
                sqlda.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return ds;
        }

        public static DataSet DataSetReader(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            DataSet dsReader = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlParameter sqlpara;
                for (int i = 0; i < para.Length; i++)
                {
                    sqlpara = new SqlParameter();
                    sqlpara.ParameterName = para[i];
                    sqlpara.SqlValue = values[i];

                    cmd.Parameters.Add(sqlpara);
                }
                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                dsReader.Tables[0].Load(dataReader);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dsReader;
        }

        public static SqlDataReader DataReader(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection();
            con = Getconnection();
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strQuery;
            cmd.CommandType = cmdtype;

            cmd.Connection = con;
            SqlParameter sqlpara;
            for (int i = 0; i < para.Length; i++)
            {
                sqlpara = new SqlParameter();
                sqlpara.ParameterName = para[i];
                sqlpara.SqlValue = values[i];
                cmd.Parameters.Add(sqlpara);
            }
            dataReader = cmd.ExecuteReader();

            return dataReader;
        }

        public static DataSet DataSetReader1(string strQuery, CommandType cmdtype)
        {
            DataSet dsReader = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                dsReader.Tables[0].Load(dataReader);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dsReader;
        }
        public static DataSet DataSetReader(string strQuery, CommandType cmdtype)
        {
            DataSet dsReader = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                con = Getconnection();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery;
                cmd.CommandType = cmdtype;

                cmd.Connection = con;

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                dsReader.Tables[0].Load(dataReader);
                dataReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dsReader;
        }
        public static DataTable FillDataTable(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Getconnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Thêm các tham số nếu có
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return dt;
        }
        public static int Excute_Sql(string sql)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return i;
        }
        public static int Excute_Sql(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {
            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            int efftectRecord = 0;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = strQuery;
            sqlcmd.Connection = conn;
            sqlcmd.CommandType = cmdtype;

            SqlParameter sqlpara;
            for (int i = 0; i < para.Length; i++)
            {
                sqlpara = new SqlParameter();
                sqlpara.ParameterName = para[i];
                sqlpara.SqlValue = values[i];
                sqlcmd.Parameters.Add(sqlpara);
            }
            try
            {
                efftectRecord = sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return efftectRecord;
        }

        public static int thucThiLenh(string sql)
        {
            int count = 0;
            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    count = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra\r\n" + ex.Message);
                }
            }
            return count;
        }
        public static object docGiaTri(string sql, SqlParameter[] parameters = null)
        {
            object result = null;
            using (SqlConnection conn = Getconnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Thêm tham số nếu có
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        result = cmd.ExecuteScalar(); // Thực thi câu lệnh và lấy giá trị
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra\r\n" + ex.Message);
                    }
                }
            }
            return result; // Trả về kết quả
        }
        public static string ExcuteScalar(string stringSQL)
        {
            string giaTri = "";
            try
            {
                SqlConnection sqlconn = Getconnection();
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand(stringSQL, sqlconn);
                giaTri = cmd.ExecuteScalar().ToString();
            }
            catch { }
            return giaTri;
        }
        public static string ExcuteScalar(string strQuery, CommandType cmdtype, string[] para, object[] values)
        {

            SqlConnection conn = new SqlConnection();
            conn = Getconnection();
            conn.Open();
            string efftectRecord = "";
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = strQuery;
            sqlcmd.Connection = conn;
            sqlcmd.CommandType = cmdtype;

            SqlParameter sqlpara;
            for (int i = 0; i < para.Length; i++)
            {
                sqlpara = new SqlParameter();
                sqlpara.ParameterName = para[i];
                sqlpara.SqlValue = values[i];
                sqlcmd.Parameters.Add(sqlpara);
            }
            try
            {
                if(sqlcmd.ExecuteScalar() != null)
                    efftectRecord = sqlcmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                efftectRecord = "";
                Console.WriteLine("Error:" + ex.Message);
            }
            return efftectRecord;
        }

    }
}


//1.Getconnection()
//Chức năng: Tạo và trả về một đối tượng SqlConnection sử dụng chuỗi kết nối đã định nghĩa.
//Trả về: SqlConnection - kết nối đến cơ sở dữ liệu.
//2. open()
//Chức năng: Mở kết nối đến cơ sở dữ liệu nếu nó đang đóng.
//Thông báo lỗi: Hiển thị thông báo lỗi nếu gặp phải khi mở kết nối.
//3. close()
//Chức năng: Đóng kết nối nếu nó đang mở.
//Thông báo lỗi: Hiển thị thông báo lỗi nếu gặp phải khi đóng kết nối.
//4. FillDataSet(string sql)
//Chức năng: Thực hiện truy vấn SQL và điền dữ liệu vào một đối tượng DataSet từ kết quả trả về.
//Trả về: DataSet chứa dữ liệu từ cơ sở dữ liệu.
//5. FillDataSet(string sql, string table)
//Chức năng: Tương tự như trên, nhưng cho phép chỉ định tên bảng trong DataSet để chứa dữ liệu.
//Trả về: DataSet với dữ liệu được điền vào bảng cụ thể.
//6. FillDataSet(string strQuery, CommandType cmdtype)
//Chức năng: Thực hiện truy vấn với loại lệnh (CommandType) và điền dữ liệu vào DataSet.
//Trả về: DataSet chứa dữ liệu từ truy vấn.
//7. FillDataSet(string strQuery, CommandType cmdtype, string[] para, object[] values)
//Chức năng: Thực hiện truy vấn có tham số và điền dữ liệu vào DataSet.
//Trả về: DataSet chứa dữ liệu từ truy vấn.
//8. DataSetReader(string strQuery, CommandType cmdtype, string[] para, object[] values)
//Chức năng: Thực hiện truy vấn và đọc dữ liệu vào DataSet từ SqlDataReader.
//Trả về: DataSet chứa dữ liệu đọc được.
//9. DataReader(string strQuery, CommandType cmdtype, string[] para, object[] values)
//Chức năng: Thực hiện truy vấn và trả về một đối tượng SqlDataReader để đọc dữ liệu.
//Trả về: SqlDataReader.
//10.DataSetReader1(string strQuery, CommandType cmdtype)
//Chức năng: Thực hiện truy vấn và đọc dữ liệu vào DataSet từ SqlDataReader.
//Trả về: DataSet.
//11.DataSetReader(string strQuery, CommandType cmdtype)
//Chức năng: Tương tự như DataSetReader1, thực hiện truy vấn và đọc dữ liệu vào DataSet.
//Trả về: DataSet.
//12.FillDataTable(string sql)
//Chức năng: Thực hiện truy vấn SQL và điền dữ liệu vào một đối tượng DataTable.
//Trả về: DataTable chứa dữ liệu từ truy vấn.
//13. Excute_Sql(string sql)
//Chức năng: Thực hiện một lệnh SQL không trả về dữ liệu (như INSERT, UPDATE, DELETE).
//Trả về: Số lượng bản ghi bị ảnh hưởng.
//14. Excute_Sql(string strQuery, CommandType cmdtype, string[] para, object[] values)
//Chức năng: Thực hiện lệnh SQL có tham số và trả về số lượng bản ghi bị ảnh hưởng.
//Trả về: Số lượng bản ghi bị ảnh hưởng.
//15. thucThiLenh(string sql)
//Chức năng: Thực hiện lệnh SQL và trả về số lượng bản ghi bị ảnh hưởng.
//Trả về: Số lượng bản ghi bị ảnh hưởng.
//16. docGiaTri(string sql)
//Chức năng: Thực hiện truy vấn để lấy một giá trị đơn (sử dụng ExecuteScalar).
//Trả về: Giá trị đầu tiên từ kết quả truy vấn.
//17. ExcuteScalar(string stringSQL)
//Chức năng: Thực hiện truy vấn SQL và trả về giá trị đầu tiên.
//Trả về: Giá trị đầu tiên từ kết quả truy vấn.
//18. ExcuteScalar(string strQuery, CommandType cmdtype, string[] para, object[] values)
//Chức năng: Thực hiện truy vấn có tham số và trả về giá trị đầu tiên.
//Trả về: Giá trị đầu tiên từ kết quả truy vấn.