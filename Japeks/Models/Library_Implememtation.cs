using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Japeks.Models;

namespace Japeks.Models
{
    public class Library_Implementation
    {
        public List<Library> GetBk()
        {
            List<Library> bklist = new List<Library>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from book2";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlquery, mysqlconn);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                bklist.Add(new Library
                {
                    id = Convert.ToInt32(dr["id"]),
                    author = Convert.ToString(dr["author"]),
                    book_name = Convert.ToString(dr["book_name"]),
                    genre = Convert.ToString(dr["genre"]),
                    
                    isbn = Convert.ToString(dr["isbn"])
                });
            }

            return bklist;
        }

        public bool insertbk(Library bkinsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into book2(author,book_name,genre,isbn) values ('" + bkinsert.author + "','" + bkinsert.book_name + "', '" + bkinsert.genre + "',  '" + bkinsert.isbn + "' )";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool editbk(Library bkedit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update book2 set author = '" + bkedit.author + "', isbn = '" +bkedit.isbn+ "', genre = '" + bkedit.genre + "' , book_name = '" + bkedit.book_name + "' where id= '" + bkedit.id + "'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
           

            //string sqlquery3 = "update book set isbn = '" + bkedit.isbn + "' where id= '" + bkedit.id + "'";
            //sqlcomm = new MySqlCommand(sqlquery3, mysqlconn);
            //string sqlquery4 = "update book set isbn = '" + bkedit.isbn + "' where id= '" + bkedit.id + "'";
            //sqlcomm = new MySqlCommand(sqlquery4, mysqlconn);

            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deletebk(int id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "delete from book2 where id = " + id;
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);

            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}