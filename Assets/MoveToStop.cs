using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveToStop : MonoBehaviour
{
    private GameObject s;
    private RaycastHit hit;
    private float time = 0;
    public string[] massstop;
    private int i = 0, l;

    void Start()
    {
        l = massstop.Length - 1;
        s = GameObject.Find(massstop[0]);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(s.transform.position);
    }

    void Update()
    {
        if (time < 15 && FindObjectOfType<Terrain>().GetComponent<BStart>().start)
            time += Time.deltaTime;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Physics.Raycast(transform.position, transform.forward, out hit, 6);
        if (hit.collider != null && hit.collider.isTrigger)
        {
            if (hit.distance < 5)
            {
                agent.isStopped = true;
                GetComponent<MeshCollider>().isTrigger = true;
            }
        }
        else
        {
            agent.isStopped = false;
        }
        if (hit.collider == null && agent.isStopped)
            agent.isStopped = false;
        if (hit.collider == null)
            if (agent.remainingDistance <= 10 && i != l)
            {
                Stay();
                i++;
                s = GameObject.Find(massstop[i]);
                agent.SetDestination(s.transform.position);
            }
            else if (agent.remainingDistance <= 10 && i == l)
            {
                Stay();
                i = 0;
                s = GameObject.Find(massstop[i]);
                agent.SetDestination(s.transform.position);
            }
    }

    private IEnumerator Stay()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        yield return new WaitForSeconds(5);
        agent.isStopped = false;
    }
}