using UnityEngine;

public class RayCastEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool isPlayer;
    [SerializeField] private GameObject spawn;
    
    public void CreateRay(GameObject target, int MaxDistance)
    {
        RaycastHit hit;
        Ray ray = new Ray(spawn.transform.position, target.transform.position - spawn.transform.position);    
        if(Physics.Raycast(ray, out hit, MaxDistance, layerMask))
        {
            Debug.Log("raycast");
            if(hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(spawn.transform.position ,target.transform.position - spawn.transform.position, Color.red);
                isPlayer = true;
            }
            else
            {
                Debug.DrawRay(spawn.transform.position ,target.transform.position - spawn.transform.position, Color.white);
                isPlayer = false;
            }
        }
    }

    public bool IsPlayer
    {
        get
        {
            return isPlayer;
        }
    }

}
