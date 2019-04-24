using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

	public float sensitivity = 1F;
	public int speed = 1000, rspeed = 1;

	void Start ()
	{		
	}

	void Update ()
	{
		if (Input.GetMouseButton (1)) {
			float mw = Input.GetAxis ("Mouse ScrollWheel");
			if (mw > 0.1) {
				gameObject.transform.localPosition = gameObject.transform.localPosition + transform.forward * 5;//farer
			}
			if (mw < -0.1) {
				gameObject.transform.localPosition = gameObject.transform.localPosition + transform.forward * -5;//closer
			}
		} else {
			if (Input.GetKey (KeyCode.W)) {
				gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.S)) {
				gameObject.transform.position -= gameObject.transform.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.A)) {
				gameObject.transform.position -= gameObject.transform.right * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.D)) {
				gameObject.transform.position += gameObject.transform.right * speed * Time.deltaTime;
			}
		}
	}

	void FixedUpdate ()
	{
		if (Input.GetMouseButton (1)) {
			if (Input.GetKey (KeyCode.W)) {
				gameObject.transform.RotateAround (transform.position, gameObject.transform.right, rspeed);
			}
			if (Input.GetKey (KeyCode.S)) {
				gameObject.transform.RotateAround (transform.position, gameObject.transform.right, -rspeed);
			}
			if (Input.GetKey (KeyCode.A)) {
				gameObject.transform.RotateAround (transform.position, gameObject.transform.up, -rspeed);
			}
			if (Input.GetKey (KeyCode.D)) {
				gameObject.transform.RotateAround (transform.position, gameObject.transform.up, rspeed);
			}
			if (Input.GetKey (KeyCode.Q)) {
				gameObject.transform.RotateAround (transform.position, gameObject.transform.forward, rspeed);
			}
			if (Input.GetKey (KeyCode.E)) {
				gameObject.transform.RotateAround (transform.position, gameObject.transform.forward, -rspeed);
			}
		}
	}
}
