using UnityEngine;
using Npgsql;
using System.Windows.Forms;

public class BSave : MonoBehaviour
{


    public void OnClick()
    {
        GameObject[] save = GameObject.FindGameObjectsWithTag("Lighter");
        try
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Database=lighters;");
            conn.Open();
            string sql = "Delete From properties";
            NpgsqlCommand com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            sql = "ALTER SEQUENCE properties_id_seq RESTART WITH 1";
            com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            for (int i = 0; i < save.Length; i++)
            {
                Timer t = save[i].GetComponent<Timer>();
                sql = "Insert Into properties (rot, coor, \"time\", side, red) Values (" + (int)save[i].transform.rotation.eulerAngles.y + ",'{"
                    + (int)save[i].transform.position.x + "," + (int)save[i].transform.position.y + "," + (int)save[i].transform.position.z + "}','{"
                    + (int)t.g + "," + (int)t.r + "}'," + save[i].GetComponent<road>().s + "," + t.red + ")";
                com = new NpgsqlCommand(sql, conn);
                com.ExecuteNonQuery();
            }
            sql = "Delete From walls";
            com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            sql = "ALTER SEQUENCE public.\"walls_id _seq\" RESTART WITH 1";
            com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            save = GameObject.FindGameObjectsWithTag("Wall");
            for (int i = 0; i < save.Length; i++)
            {
                sql = "Insert Into walls (rot, coor, scale) Values (" + (int)save[i].transform.rotation.eulerAngles.y + ",'{"
                    + (int)save[i].transform.position.x + "," + (int)save[i].transform.position.y + "," + (int)save[i].transform.position.z + "}','{"
                    + (int)save[i].transform.localScale.x + "," + (int)save[i].transform.localScale.y + "," + (int)save[i].transform.localScale.z + "}')";
                com = new NpgsqlCommand(sql, conn);
                com.ExecuteNonQuery();
            }
            sql = "Delete From stops";
            com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            sql = "ALTER SEQUENCE public.\"stops_id_seq\" RESTART WITH 1";
            com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            save = GameObject.FindGameObjectsWithTag("Stop");
            for (int i = 0; i < save.Length; i++)
            {
                sql = "Insert Into stops (rot, coor, name) Values (" + (int)save[i].transform.rotation.eulerAngles.y + ",'{"
                    + (int)save[i].transform.position.x + "," + (int)save[i].transform.position.y + "," + (int)save[i].transform.position.z + "}','" + save[i].name + "')";
                com = new NpgsqlCommand(sql, conn);
                com.ExecuteNonQuery();
            }
            sql = "Delete From spawn";
            com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            sql = "ALTER SEQUENCE public.spawn_id_seq RESTART WITH 1";
            com = new NpgsqlCommand(sql, conn);
            com.ExecuteNonQuery();
            save = GameObject.FindGameObjectsWithTag("Spawn");
            for (int i = 0; i < save.Length; i++)
            {
                spawn s = save[i].GetComponent<spawn>();
                sql = "Insert Into spawn (rot, coor, num) Values (" + (int)save[i].transform.rotation.eulerAngles.y + ",'{"
                        + (int)save[i].transform.position.x + "," + (int)save[i].transform.position.y + "," + (int)save[i].transform.position.z + "}'," + s.num + ")";
                com = new NpgsqlCommand(sql, conn);
                com.ExecuteNonQuery();
            }
            conn.Close();
        }
        catch
        {
            MessageBox.Show("Server is off or busy", "Server Error", MessageBoxButtons.OK);
        }
    }

}
