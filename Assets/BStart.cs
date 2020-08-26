using UnityEngine;
using UnityEngine.UI;

public class BStart : MonoBehaviour
{

    public bool start = false;
    public void OnClick()
    {
        if (!start)
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "Stop";
        else
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "Start";
        start = !start;
    }
}