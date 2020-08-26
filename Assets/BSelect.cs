using UnityEngine;
using UnityEngine.UI;

public class BSelect : MonoBehaviour
{

    public Text t;
    public GameObject o;
    private bool f = false;
    //flags

    public void OnClick()
    {
        if (!f)
        {
            f = true;
            BInst i = GetComponent<BInst>();
            i.f1 = true;
            if (i.d)
                i.Destroyer();
            BDele i1 = GetComponent<BDele>();
            i1.f = false;
            i1.f1 = true;
        }
        else
        {
            f = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (f)
        {
            if (Input.GetMouseButton(0))
            {
                Camera c = GetComponent<Camera>();
                Timer v;
                GameObject g;
                RaycastHit hit;
                RaycastHit2D hit1;
                Physics.Raycast(c.ScreenPointToRay(Input.mousePosition), out hit, 200f, 1 << 8);
                if (hit.collider != null)
                {
                    hit1 = Physics2D.Raycast(Input.mousePosition, Input.mousePosition);
                    g = hit.collider.gameObject;
                    if (!hit1 && g.name.IndexOf("Lighter(Clone)") != -1)
                    {
                        o = g;
                        v = g.GetComponent<Timer>();
                        t.text = "Select Lighter:" + "\nRed:" + v.red + "\nGreen time:" + v.g + "\nRed time:" + v.r + "\nOnesided:" + g.GetComponent<road>().s;
                    }
                }

                f = !f;
            }
        }
    }
}