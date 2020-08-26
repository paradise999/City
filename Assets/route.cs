using System.Collections;
using UnityEngine;

public class route : MonoBehaviour
{

    public GameObject prefab;
    private GameObject l;
    private bool f = true;
    private int i = 0, n;
    public int num = 10;
    private float time = 0;
    public string[] m;

    void Start()
    {
        string str;
        str = gameObject.name.ToString();
        str = str.Substring(str.Length - 1, 1);
        int.TryParse(str, out n);

    }

    void Update()
    {
        if (f && i < num && FindObjectOfType<Terrain>().GetComponent<BStart>().start)
        {
            if (time < n)
                time += Time.deltaTime;
            else
                StartCoroutine(MakeBox());
        }
        if (i == num)
            Destroy(gameObject);
    }

    private IEnumerator MakeBox()
    {
        i++;
        l = Instantiate(prefab, transform.localPosition - new Vector3(10,0,10), Quaternion.identity);
        l.GetComponent<MoveToStop>().massstop = m;
        f = false;
        yield return new WaitForSeconds(7);
        f = true;
    }
}