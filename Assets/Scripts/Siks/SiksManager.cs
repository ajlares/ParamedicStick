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
                if(canPlay)
                {
                    canPlay = false;
                    particles.Play();
                    GameManager.instance.HealAcount = 1;
                }
                Destroy(parent,.25f);

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
            isStayPlayer = true;
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isStayPlayer = false;
        }    
    }
}
