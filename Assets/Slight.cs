using UnityEngine;
using System.Windows.Forms;
using Npgsql;

public class Slight : MonoBehaviour
{

    private GameObject l;
    public GameObject prefab, prefab1, prefab2, prefab3;
    //lighter
    private int i = 0;
    //flag
    public NpgsqlConnection conn;

    void Start()
    {
        try
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Database=lighters;");
            conn.Open();
            string sql = "select * from properties";
            NpgsqlCommand com = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            string result, resulti;
            object result1 = 0, result2 = 0, result3 = true, result4 = true;
            while (reader.Read())
            {
                result = reader.GetValue(1).ToString(); //rotation
                result1 = reader.GetValue(2); //position
                result2 = reader.GetValue(3); //time
                result3 = reader.GetValue(4); //side
                result4 = reader.GetValue(5); //red
                int[] a = (int[])result1;
                int[] b = (int[])result2;
                bool s = (bool)result3;
                bool red = (bool)result4;
                l = (GameObject)Instantiate(prefab, new Vector3(a[0], a[1], a[2]), Quaternion.AngleAxis(int.Parse(result), Vector3.up));
                Timer t = l.GetComponent<Timer>();
                t.g = b[0];
                t.r = b[1];
                l.GetComponent<road>().s = s;
                t.red = red;
                l.name = l.name + i;
                i++;
            }
            i = 0;
            sql = "select * from spawn";
            com = new NpgsqlCommand(sql, conn);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetValue(1).ToString(); //rotation
                result1 = reader.GetValue(2); //position
                result2 = reader.GetValue(3); //num
                int[] a = (int[])result1;
                int b = (int)result2;
                l = (GameObject)Instantiate(prefab1, new Vector3(a[0], a[1], a[2]), Quaternion.AngleAxis(int.Parse(result), Vector3.up));
                spawn t = l.GetComponent<spawn>();
                t.num = b;
                l.name = l.name + i;
                i++;
            }
            sql = "select * from stops";
            com = new NpgsqlCommand(sql, conn);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                resulti = reader.GetValue(0).ToString(); //id
                result = reader.GetValue(1).ToString(); //rotation
                result1 = reader.GetValue(2); //position                
                int[] a = (int[])result1;
                int b = (int)result2;
                l = (GameObject)Instantiate(prefab2, new Vector3(a[0], a[1], a[2]), Quaternion.AngleAxis(int.Parse(result), Vector3.up));
                l.name = "stop" + resulti;
            }
            sql = "select * from route";
            com = new NpgsqlCommand(sql, conn);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetValue(1).ToString(); //name
                result1 = reader.GetValue(2); //route                
                string[] a = (string[])result1;
                l = (GameObject)Instantiate(prefab3);
                l.name = result.ToString();
                l.GetComponent<route>().m = a;

            }
        }
        catch
        {
            MessageBox.Show("Server is off or busy", "Server Error", MessageBoxButtons.OK);
            UnityEngine.Application.Quit();
        }
    }

}

