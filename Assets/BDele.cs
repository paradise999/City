using System.Collections;
using UnityEngine;

public class BDele : MonoBehaviour
{

    private GameObject v;
    //intstall position
    public bool f = false, f1 = true;
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

        }
        else
        {
            f = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (f1 && f)
        {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(MakeBox());
            }
        }
    }

    private IEnumerator MakeBox()
    {
        Camera c = GetComponent<Camera>();
        RaycastHit hit;
        RaycastHit2D hit1;
        Physics.Raycast(c.ScreenPointToRay(Input.mousePosition), out hit, 200f, 1 << 8);
        if (hit.collider != null)
        {
            v = hit.collider.gameObject;
            hit1 = Physics2D.Raycast(Input.mousePosition, Input.mousePosition);
            if (!hit1 && v.name == "Lighter(Clone)")
            {
                road r = v.GetComponent<road>();
                Destroy(r.a);
                Destroy(r.b);
                Destroy(r.e);
                Destroy(r.f);
                Destroy(r.w);
                Destroy(r.w2);
                Destroy(v);
            }
        }
        f1 = false;
        yield return new WaitForSeconds(1);
        f1 = true;
    }
}
