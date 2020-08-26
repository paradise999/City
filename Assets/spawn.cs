using System.Collections;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject prefab;
    private bool f = true;
    private int i = 0, n;
    public int num = 10;
    private float time = 0;

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
        Instantiate(prefab, transform.localPosition + transform.forward * 5 + transform.right * 5, Quaternion.identity);
        f = false;
        yield return new WaitForSeconds(7);
        f = true;
    }
}