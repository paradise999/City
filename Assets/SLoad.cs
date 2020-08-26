using UnityEngine;
using UnityEngine.UI;
using Npgsql;
using System.Windows.Forms;

public class SLoad : MonoBehaviour
{
    public NpgsqlConnection conn;

    // Start is called before the first frame update


    // Update is called once per frame
    public void OnClick()
    {
        string name = FindObjectOfType<Dropdown>().captionText.text;
        Text t = GameObject.Find("List").GetComponentInChildren<Text>();
        t.text = "";
        try
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=12345;Database=lighters;");
            conn.Open();
            string sql = "select stops from route where name = '" + name + "'";
            NpgsqlCommand com = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            object result = 0;
            while (reader.Read())
            {
                result = reader.GetValue(0);
                string[] s = (string[])result;
                for (int i = 0; i < s.Length; i++)
                {
                    t.text += s[i] + "\n";
                }

            }
        }
        catch
        {
            MessageBox.Show("Server is off or busy", "Server Error", MessageBoxButtons.OK);
            UnityEngine.Application.Quit();
        }
    }
}
