using UnityEngine;
using UnityEngine.UI;
using Npgsql;
using System.Windows.Forms;

public class DropdownChange : MonoBehaviour
{
    public NpgsqlConnection conn;


    void Start()
    {
        try
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Database=lighters;");
            conn.Open();
            string sql = "select * from route";
            NpgsqlCommand com = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            string result;
            object result1 = 0, result2 = 0, result3 = true, result4 = true;
            while (reader.Read())
            {
                result = reader.GetValue(1).ToString(); //rotation               
                GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = result });
            }
        }
        catch
        {
            MessageBox.Show("Server is off or busy", "Server Error", MessageBoxButtons.OK);
            UnityEngine.Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
