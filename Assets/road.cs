using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class road : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab; //wall
	public GameObject prefabw; //wall2
	public GameObject prefab1; //point
	public GameObject a,b,e,f,w,w2; //points
	public bool s = false;
	void Start ()
	{				
		if (!s) {
		w = (GameObject)Instantiate (prefab, transform.localPosition +transform.forward * -10 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //wall
		w.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		w2 = (GameObject)Instantiate (prefabw, transform.localPosition + transform.forward * -31 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //wall1
		w2.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		b = (GameObject)Instantiate (prefab1, transform.localPosition + transform.right * 4 + transform.forward * -23 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left end
		b.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		a = (GameObject)Instantiate (prefab1, transform.localPosition + transform.right * -4 + transform.forward * -23- transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left start
		a.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		f = (GameObject)Instantiate (prefab1, transform.localPosition + transform.right * 4 + transform.forward * -28- transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left end 2
		f.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		e = (GameObject)Instantiate (prefab1, transform.localPosition + transform.right * -4 + transform.forward * -28- transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left start 2
		e.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
			OffMeshLink[] o = GetComponents<OffMeshLink>();
			o [0].startTransform = a.transform;
			o [0].endTransform = b.transform;
			o [1].startTransform = e.transform;
			o [1].endTransform = f.transform;
		} else {
			w = (GameObject)Instantiate (prefab, transform.localPosition +transform.forward * -10 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //wall
			w.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
			w2 = (GameObject)Instantiate (prefab, transform.localPosition + transform.forward * -31 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //wall1
			w2.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		}
	}
		
}
