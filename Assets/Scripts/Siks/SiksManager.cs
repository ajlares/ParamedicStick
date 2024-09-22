using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SiksManager : MonoBehaviour
{
    [SerializeField] private bool isStayPlayer;
    [SerializeField] private float healTime;
    [SerializeField] private float indextime;
    [SerializeField] private GameObject parent;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private bool canPlay;
    

    private void Update() 
    {
        if(isStayPlayer)
        {
            if(indextime >= healTime)
            {
                Debug.Log("c curo");
                if(canPlay)
                {
                    canPlay = false;
                    particles.Play();
                }
                Destroy(parent,1);

            }
            indextime += Time.deltaTime;
        }
        else
        {
            indextime = 0f;
        } 

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            isStayPlayer = true;
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isStayPlayer = false;
            Debug.Log("Player");
        }    
    }
}
