using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;


namespace AssociationPro
{
    class Class1
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=associations;User ID=sa;password=mterp");
        SqlCommand com;
        DataTable dt;
        public DataTable centers(string gov)
        {
            com = new SqlCommand("select center from gov_center where gov=N'"+gov+"'", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }
        public DataTable getProAssName()
        {
            com = new SqlCommand("select distinct assName from protocol where GETDATE() between protocolDate and DATEADD(MONTH,period,protocolDate)", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }
        public DataTable sections(string center)
        {
            com = new SqlCommand("select distinct section from Center_Section_Village where center=N'" + center + "'", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }


        public DataTable village(string section)
        {
            com = new SqlCommand("select distinct village from Center_Section_Village where section=N'" + section + "'", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }

        public DataTable getemp()
        {
            com = new SqlCommand("select distinct emp from emp ", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }

        public int count2(string assname)
        {
            int x = 0;
            com = new SqlCommand("select count (id)  from cases where [ass_name]=N'" + assname + "' and [comm_decision]='مقبولة' and con_type='مياه وصرف'", con);
            com.CommandType = CommandType.Text;
            // SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                con.Open();
                x = int.Parse(com.ExecuteScalar().ToString());
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return x;
        }

        public int count(string assname,string type)
        {
            int x=0;
            com = new SqlCommand("select count (id)  from cases where [ass_name]=N'" + assname + "' and [comm_decision]='مقبولة' and (con_type='مياه' or con_type='صرف' )", con);
            com.CommandType = CommandType.Text;
           // SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                con.Open();
                x = int.Parse(com.ExecuteScalar().ToString());
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return x;
        }
        public int waterNo(string assname)
        {
            int x = 0;
            com = new SqlCommand("select [ConNo]  from def where [name]=N'" + assname + "' ", con);
            com.CommandType = CommandType.Text;
            // SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                con.Open();
              

                x = int.Parse(Math.Ceiling(int.Parse(com.ExecuteScalar().ToString()) * 0.2).ToString());
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return x;
        }


        public int sewerNo(string assname)
        {
            int x = 0;
            com = new SqlCommand("select sewerNo  from def where [name]=N '" + assname + "' ", con); 
            com.CommandType = CommandType.Text;
            // SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                con.Open();
                x = int.Parse(Math.Ceiling(int.Parse(com.ExecuteScalar().ToString()) * 0.2).ToString());
                //x = int.Parse(com.ExecuteScalar().ToString());
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return x;
        }


        //public void InsertAssociaton(string name, string type, string gov, string center, string street, string chairman, string authorized, string phone_no, string note)
        //{
        //    com = new SqlCommand(" INSERT INTO [associations].[dbo].[Def]([name],[type],[gov] ,[center] ,[street] ,[chairman],[authorized],[phone_no],note) values('" + name + "','" + type + "','" + gov + "','" + center + "','" + street + "','" + chairman + "','" + authorized + "','" + phone_no + "','" + note + "')", con);
        //    com.CommandType = CommandType.Text;
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}
        public void InsertAssociaton(string name, string type, string gov, string center, string street, string chairman, string authorized, string phone_no, string note)
        {
            com = new SqlCommand(" INSERT INTO [associations].[dbo].[Def]([name],[type],[gov] ,[center] ,[street] ,[chairman],[authorized],[phone_no],note) values('" + name + "','" + type + "','" + gov + "','" + center + "','" + street + "','" + chairman + "','" + authorized + "','" + phone_no + "','" + note + "')", con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public int InsertCase(string ass_name, string case_name, string center, string section, string village, string street, float area, int no_floors, string con_type, string F_emp, string S_emp, string decision, string comm_decision, bool Rec, bool paid, string account, DateTime scanDate,string reason,string txtID)
        {
            com = new SqlCommand("SET DATEFORMAT dmy  INSERT INTO [associations].[dbo].[cases]([ass_name],[case_name],[center],[section],[village],[street],[area],[no_floors],[con_type],[F_emp],[S_emp],[decision],[comm_decision],Recommended,paid,account_no,scanDate,commRefuseReason,case_id) values(N'" + ass_name + "',N'" + case_name + "',N'" + center + "',N'" + section + "',N'" + village + "','" + street + "'," + area + "," + no_floors + ",N'" + con_type + "',N'" + F_emp + "',N'" + S_emp + "',N'" + decision + "','" + comm_decision + "','" + Rec + "','" + paid + "','" + account + "','" + scanDate + "',N'" + reason + "','" + txtID + "')  SELECT SCOPE_IDENTITY()", con);
            com.CommandType = CommandType.Text;
            con.Open();
            int x= int.Parse(com.ExecuteScalar().ToString());
            con.Close();
            return x;
        }


        public void InsertCase_image(int image_id, int case_id, int type)
        {
            com = new SqlCommand(" INSERT INTO [associations].[dbo].[image_case]([image_id],[case_id],[type]) values(" + image_id + "," + case_id + "," + type + ")", con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
           
        }


        public void updateCase(int id, string ass_name, string case_name, string center, string section, string village, string street, float area, int no_floors, string con_type, string F_emp, string S_emp, string decision, string comm_decision, bool Rec, bool paid, string account, DateTime scanDate, string commRefuseReason,string txtid)
        {
            com = new SqlCommand(" update [cases]  set [ass_name]=N'" + ass_name + "',[case_name]=N'" + case_name + "',[center]=N'" + center + "',[section]=N'" + section + "',[village]=N'" + village + "',[street]=N'" + street + "',[area]=N'" + area + "',[no_floors]='" + no_floors + "',[con_type]=N'" + con_type + "',[F_emp]=N'" + F_emp + "',[S_emp]=N'" + S_emp + "',[decision]=N'" + decision + "',[comm_decision]=N'" + comm_decision + "',Recommended='" + Rec + "',paid='" + paid + "',account_no='" + account + "', scanDate='" + scanDate + "',commRefuseReason='"+commRefuseReason+ "',case_id='" + txtid + "' where id=" + id, con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //public void updateAss(string name,string type,string gov,string center,string street,string chairman ,string authorized,string phone_no )
        //{
        //    com = new SqlCommand(" update [Def]  SET type = N'" + type + "' , gov =N'" + gov + "', center = N'" + center + "' ,street = N'" + street + "' ,chairman = N'" + chairman + "',authorized = N'" + authorized + "' ,[phone_no] ='" + phone_no + "' where name= N'" + name + "'", con);
        //    com.CommandType = CommandType.Text;
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}

        public void updateAss(string name, string type, string gov, string center, string street, string chairman, string authorized, string phone_no, string note)
        {
            com = new SqlCommand(" update [Def]  SET [type] = N'" + type + "',[gov] = N'" + gov + "',[center] = N'" + center + "',[street] = N'" + street + "',[chairman] = N'" + chairman + "',[authorized] = N'" + authorized + "',[phone_no] ='" + phone_no + "',[note] = N'" + note + "' where name= N'" + name + "'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void deleteCase(int id)
        {
            com = new SqlCommand(" delete from  [cases]  where id="+id, con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public int CheckCaseID(string caseid)
        {
            int x = 0;
            com = new SqlCommand("select count (id)  from cases where case_id=" + caseid, con);
            com.CommandType = CommandType.Text;
            // SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                con.Open();
                x = int.Parse(com.ExecuteScalar().ToString());
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return x;
        }

        public void Insertemp(string emp_name)
        {
            com = new SqlCommand(" INSERT INTO emp(emp) values(N'" + emp_name + "')", con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }


        public void backup()
        {
            com = new SqlCommand("backup", con);
            com.CommandType = CommandType.StoredProcedure;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }


       // output Inserted.id 
         //SqlDataAdapter da = new SqlDataAdapter(com);
            //try
            //{
            //    dt = new DataTable();
            //    da.Fill(dt);

            //}
            //catch
            //{
            //}
            //return dt;
        public int insertImage(Image image, string imageDescription)
        {
            int x;
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(image, typeof(byte[]));
            com = new SqlCommand("insert into images (image,imageDesc) values ( @image ,@imageDescription) SELECT SCOPE_IDENTITY() ", con);
            com.Parameters.Add("@image", SqlDbType.VarBinary).Value = bytes;
            com.Parameters.Add("@imageDescription", SqlDbType.NVarChar).Value = imageDescription;
            com.CommandType = CommandType.Text;
            con.Open();
             x=int.Parse(com.ExecuteScalar().ToString());
            con.Close();


            return x;
        }




        public byte[] selectImage(int id)
        {
            string a;
            com = new SqlCommand("select image from images where  id=" + id, con);
            com.CommandType = CommandType.Text;
            con.Open();
            byte[] bytes = (byte[])com.ExecuteScalar();
            con.Close();
            return bytes;
        }

        public DataTable selectImage_case(int Cid)
        {
            string a;
            com = new SqlCommand("select image_id from image_case where  case_id=" + Cid, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }


        public DataTable selectImage_case2(int Cid,int type)
        {
            string a;
            com = new SqlCommand("select image_id from image_case where  case_id=" + Cid+" and type=N"+type, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }

        public DataTable getAssData(string name)
        {
            com = new SqlCommand("select *  from Def where name=N'" + name + "'", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }
        public DataTable getAssNames()
        {
            com = new SqlCommand("select name  from Def ", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            try
            {
                dt = new DataTable();
                da.Fill(dt);

            }
            catch
            {
            }
            return dt;
        }


        public void deleteAss(string name)
        {
            com = new SqlCommand("delete from Def where name=N'"+name+"'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        SqlDataAdapter da;

        public DataTable search(string type, string sh1)
        {
            com = new SqlCommand("select * from cases where " + type + "  like N'%" + sh1 + "%'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable orand(string type, string sh1, string sh2, string sh3)
        {
            com = new SqlCommand("select * from cases where " + type + " like N'%" + sh1 + "%' or  " + type + " like N '%" + sh2 + "%' and  " + type + " like N '%" + sh3 + "%'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable andor(string type, string sh1, string sh2, string sh3)
        {
            com = new SqlCommand("select * from cases where " + type + " like N '%" + sh1 + "%' and  " + type + " like N '%" + sh2 + "%' or  " + type + " like N'%" + sh3 + "%'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable andand(string type, string sh1, string sh2, string sh3)
        {
            com = new SqlCommand("select * from cases where " + type + " like N'%" + sh1 + "%' and  " + type + " like N'%" + sh2 + "%' and  " + type + " like N'%" + sh3 + "%'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable or(string type, string sh1, string sh2)
        {
            com = new SqlCommand("select * from cases where " + type + " like N'%" + sh1 + "%' or  " + type + " like N'%" + sh2 + "%'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable and(string type, string sh1, string sh2)
        {
            com = new SqlCommand("select * from cases where " + type + " like N'%" + sh1 + "%' and  " + type + " like N'%" + sh2 + "%'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable oror(string type, string sh1, string sh2, string sh3)
        {
            com = new SqlCommand("select * from cases where " + type + " like N'%" + sh1 + "%' or  " + type + " like N'%" + sh2 + "%' or  " + type + " like N'%" + sh3 + "%'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetCase(int id)
        {
            com = new SqlCommand("select * from cases where id= " + id , con);
            com.CommandType = CommandType.Text;
            con.Open();
            da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void updateYear(string year)
        {
            com = new SqlCommand(" update [year]  set  year='" + year + "'", con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public string Getyear()
        {
            com = new SqlCommand("select year from year", con);
            com.CommandType = CommandType.Text;
            con.Open();
            string x = com.ExecuteScalar().ToString();
            con.Close();
            return x;
        }


        public void insertProtocal(string assName,DateTime protocolDate,int period,int conNo, Image image)
        {
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(image, typeof(byte[]));
            com = new SqlCommand(" SET DATEFORMAT dmy insert into  [protocol](assName,protocolDate,period,conNo,New,image) values( N'" + assName + "','" + protocolDate + "'," + period + "," + conNo + ",'true',@image)", con);
            com.Parameters.Add("@image", SqlDbType.VarBinary).Value = bytes;
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void updateProtocal(string assName, int period,int conNo)
        {
            com = new SqlCommand(" SET DATEFORMAT dmy update [protocol] set period = period+" + period + ",conNo="+conNo+",New='false' where assName=N'" + assName + "' and protocolDate in (SELECT MAX(protocolDate)  FROM [protocol] where assName='" + assName + "') SELECT SCOPE_IDENTITY() ", con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void insertProtocolHistory(int pid)
        {
            com = new SqlCommand(" insert into [protocolHistory] (assName,protocolDate,period,conNo,New) SELECT [assName] ,[protocolDate],[period],[conNo],[New]FROM [associations].[dbo].[protocol] where id="+pid, con);
            com.CommandType = CommandType.Text;
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public int selectprotocol(string assName, int period)
        {
            com = new SqlCommand(" select id from [protocol]  where assName= N '" + assName + "' and protocolDate in (SELECT MAX(protocolDate)  FROM [protocol] where assName= N'" + assName + "')  ", con);
            com.CommandType = CommandType.Text;
            con.Open();
            int id=int.Parse(com.ExecuteScalar().ToString());
            con.Close();
            return id;
        }


    }
}
