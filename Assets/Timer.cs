using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Timer : MonoBehaviour
{
	public bool pusk, red = true;
	public int g, r;
		
	void Update ()
	{
		if (pusk && FindObjectOfType<Terrain>().GetComponent<BStart>().start)
			StartCoroutine (MakeBox ());
	}

	private IEnumerator MakeBox () 
	{
		road ro = GetComponent<road> ();
		if (!ro.s) {
			if (red) {
				ro.w.GetComponent<NavMeshObstacle> ().enabled = true;
				ro.w.GetComponent<MeshCollider> ().isTrigger = true;
				gameObject.GetComponent<Renderer> ().material.color = Color.red;
				pusk = false;
				yield return new  WaitForSeconds (r);
				pusk = true;
				red = !red;
			} else {
				gameObject.GetComponent<Renderer> ().material.color = Color.green;
				ro.w.GetComponent<MeshCollider> ().isTrigger = false;
				ro.w.GetComponent<NavMeshObstacle> ().enabled = false;
				pusk = false;
				yield return new WaitForSeconds (g);
				pusk = true;
				red = !red;
			}
		} else {
			if (red) {
				ro.w.GetComponent<NavMeshObstacle> ().enabled = true;
				ro.w2.GetComponent<NavMeshObstacle> ().enabled = true;
				ro.w.GetComponent<MeshCollider> ().isTrigger = true;
				gameObject.GetComponent<Renderer> ().material.color = Color.red;
				pusk = false;
				yield return new  WaitForSeconds (r);
				pusk = true;
				red = !red;
			} else {				
				gameObject.GetComponent<Renderer> ().material.color = Color.green;
				ro.w.GetComponent<NavMeshObstacle> ().enabled = false;
				ro.w2.GetComponent<NavMeshObstacle> ().enabled = false;
				ro.w.GetComponent<MeshCollider> ().isTrigger = false;
				pusk = false;
				yield return new WaitForSeconds (g);
				pusk = true;
				red = !red;
			}
		}

	}

}

