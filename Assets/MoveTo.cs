using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;

public class MoveTo : MonoBehaviour
{
	private Vector3 pos;
	private RaycastHit hit;
	private float time = 0;

	void Start ()
	{		
		System.Random r = new System.Random ();
		pos.x = transform.position.x - r.Next (0, (int)transform.position.x - 1);
		pos.y = transform.position.y;
		pos.z = transform.position.z - r.Next (0, (int)transform.position.z - 1);
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (pos);
	}

	void Update ()
	{			
		if (time < 15 && FindObjectOfType<Terrain>().GetComponent<BStart>().start)
			time += Time.deltaTime;
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		Physics.Raycast (transform.position, transform.forward, out hit, 6);
		if (hit.collider != null && hit.collider.isTrigger) {
			if (hit.distance < 5) {
				agent.isStopped = true;
				GetComponent<MeshCollider> ().isTrigger = true;			
			} 
		} else  {
			agent.isStopped = false;
		}
		if (hit.collider == null && agent.isStopped)
			agent.isStopped = false;
		if (hit.collider == null && time>=10)
		if (agent.remainingDistance == 0)
			Destroy (gameObject);
	}		
}