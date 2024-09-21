using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private NavMeshAgent agent;

    public void SetEnable(bool valeu)
    {   
        agent.enabled = valeu;
    }   
    public void NavMove()
    {

        agent.SetDestination(target.transform.position);
    }

    public void SetTarget(GameObject Player)
    {
        target = Player;
    }
}