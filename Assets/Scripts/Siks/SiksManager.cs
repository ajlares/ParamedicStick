using UnityEngine;

public class SiksManager : MonoBehaviour
{
    [SerializeField] private bool isStayPlayer;
    [SerializeField] private float healTime;
    [SerializeField] private float indextime;
    [SerializeField] private GameObject parent;
    [SerializeField] private ParticleSystem particles1;
    [SerializeField] private ParticleSystem particles2;
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
                    particles1.Play();
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
            particles2.Play();
            isStayPlayer = true;
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            particles2.Stop();
            isStayPlayer = false;
        }    
    }
}
