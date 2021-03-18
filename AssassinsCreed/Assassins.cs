using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace AssassinsCreed
{
    public class Assassins
    {
        static string connectionStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionStr);
        public void RetrieveAllAssassins()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from assassins", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("AssassinID \tAssassin Name \t\t Profile\t\tSeries Name");
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t{3}", reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void AddCharacter(string name,string profile,string series)
        {
           try
            {
                SqlCommand cmd = new SqlCommand("insert into assassins values (@assassinName,@profile,@series)", con);
                cmd.Parameters.AddWithValue("@assassinName", name);
                cmd.Parameters.AddWithValue("@profile", profile);
                cmd.Parameters.AddWithValue("@series", series);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Record Successfully inserted");
                else
                    Console.WriteLine("Failed to insert the assassin.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteCharacter(int id)
        {
            try {
                SqlCommand cmd = new SqlCommand("delete from assassins where assassinID=@assassinID", con);
                cmd.Parameters.AddWithValue("@assassinID", id);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if(rowsAffected>0)
                    Console.WriteLine("Record Successfully deleted");
                else
                    Console.WriteLine("Failed to delted the assassin. Check the Assassin ID");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }   
        }

        public void UpdateCharacter(string name,int id)
        {
          try
            {
                SqlCommand cmd = new SqlCommand("update assassins set assassinName= @assassinName where assassinID=@assassinID", con);
                cmd.Parameters.AddWithValue("@assassinName", name);
                cmd.Parameters.AddWithValue("@assassinID", id);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Record Successfully updated");
                else
                    Console.WriteLine("Failed to update the assassin. Check the Assassn ID");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void SearchCharacter(string name)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from assassins where assassinName=@name", con);
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("AssassinID \tAssassin Name \t\t Profile\t\tSeries Name");
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t{3}", reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void CountCharacters()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select count(assassinID) from assassins", con);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                Console.WriteLine("There's {0} assassins in our Creeed",count); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DisplayTemplars()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from assassins where profile='Templar' or profile='Chinese Templar'", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine("{0}\t\t{1}\t\t\t{2}\t\t{3}", reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
