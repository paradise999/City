using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dollr : MonoBehaviour {
	
	public GameObject prefab,prefab1,prefab2; //wall & wall left
	public GameObject a,b,e,f,w,w2; //points

	void Start () {
		w = (GameObject)Instantiate (prefab, transform.localPosition +transform.forward * -10 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //wall
		w.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		w2 = (GameObject)Instantiate (prefab1, transform.localPosition + transform.forward * -31 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //wall1
		w2.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		b = (GameObject)Instantiate (prefab2, transform.localPosition + transform.right * 4 + transform.forward * -23 - transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left end
		b.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		a = (GameObject)Instantiate (prefab2, transform.localPosition + transform.right * -4 + transform.forward * -23- transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left start
		a.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		f = (GameObject)Instantiate (prefab2, transform.localPosition + transform.right * 4 + transform.forward * -28- transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left end 2
		f.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		e = (GameObject)Instantiate (prefab2, transform.localPosition + transform.right * -4 + transform.forward * -28- transform.up* transform.localPosition.y + transform.up*10, Quaternion.identity); //left start 2
		e.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		}

	public void Change(){
		w.transform.position = transform.localPosition +transform.forward * -10 - transform.up* transform.localPosition.y + transform.up*10; //wall
		w.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		w2.transform.position = transform.localPosition + transform.forward * -31 - transform.up* transform.localPosition.y + transform.up*10; //wall1
		w2.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		b.transform.position = transform.localPosition + transform.right * 4 + transform.forward * -23 - transform.up* transform.localPosition.y + transform.up*10; //left end
		b.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		a.transform.position = transform.localPosition + transform.right * -4 + transform.forward * -23- transform.up* transform.localPosition.y + transform.up*10; //left start
		a.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		f.transform.position = transform.localPosition + transform.right * 4 + transform.forward * -28- transform.up* transform.localPosition.y + transform.up*10; //left end 2
		f.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		e.transform.position = transform.localPosition + transform.right * -4 + transform.forward * -28- transform.up* transform.localPosition.y + transform.up*10; //left start 2
		e.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,90,0);
		}
}
