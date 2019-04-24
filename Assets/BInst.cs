using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BInst : MonoBehaviour
{

	public GameObject prefab, p;
	//lighter
	private Vector3 v;
	//intstall position
	public bool f = false, f1 = true, s = false, r = true;
	//flags
	public GameObject d;
	//doll
	public InputField fig, fir;
	//times
	public void OnClick ()
	{		
		if (!f) {
			f = true;
			d = Instantiate (p);
			BDele i = GetComponent<BDele> ();
			i.f = false;
			i.f1 = true;
		} else if (d.GetComponent<Dollr> ())
			Destroyer ();
		
	}

	private IEnumerator MakeBox ()
	{
		Toggle tg = FindObjectOfType<Toggle> ();
		Slider sr = FindObjectOfType<Slider> ();
		Camera c = GetComponent<Camera> ();
		s = tg.isOn;
		if (sr.normalizedValue == 0)
			r = true;
		else
			r = false;
		RaycastHit hit;
		RaycastHit2D hit1;
		Physics.Raycast (c.ScreenPointToRay (Input.mousePosition), out hit); 			
		v = hit.point;
		hit1 = Physics2D.Raycast (Input.mousePosition, Input.mousePosition);
		if (!hit1) {
			GameObject g = Instantiate (prefab, v, Quaternion.AngleAxis (d.transform.eulerAngles.y, Vector3.up));
			Timer t = g.GetComponent<Timer> ();
			if (!int.TryParse (fig.text, out t.g))
				t.g = 10;
			if (!int.TryParse (fir.text, out t.r))
				t.r = 10;
			g.GetComponent<road> ().s = s;
			t.red = r;
		}
		f1 = false;
		yield return new  WaitForSeconds (1);
		f1 = true;
	}

	public void Destroyer ()
	{
		f = false;
		Destroy (d.GetComponent<Dollr> ().w);
		Destroy (d.GetComponent<Dollr> ().w2);
		Destroy (d.GetComponent<Dollr> ().a);
		Destroy (d.GetComponent<Dollr> ().b);
		Destroy (d.GetComponent<Dollr> ().e);
		Destroy (d.GetComponent<Dollr> ().f);
		Destroy (d);
	}

	void Update ()
	{
		if (f1 && f) {
			Camera c = GetComponent<Camera> ();
			RaycastHit hit;
			if (Input.GetMouseButton (0)) {
				StartCoroutine (MakeBox ());
			}
			Physics.Raycast (c.ScreenPointToRay (Input.mousePosition), out hit); 
			v = hit.point;
			if (d.GetComponent<Dollr> ().w)
			if (hit.collider != d.GetComponent<MeshCollider> ()) {
				d.transform.position = v;
				d.GetComponent<Dollr> ().Change ();
			}		
			float mw = Input.GetAxis ("Mouse ScrollWheel");
			if (mw > 0.1) {
				d.transform.eulerAngles = d.transform.eulerAngles + new Vector3 (0, -5, 0);//Left turn
				d.GetComponent<Dollr> ().Change ();
			}
			if (mw < -0.1) {
				d.transform.eulerAngles = d.transform.eulerAngles + new Vector3 (0, 5, 0);//Right Turn
				d.GetComponent<Dollr> ().Change ();
			}
		}
	}
}
