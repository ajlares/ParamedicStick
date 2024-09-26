using UnityEngine;

public class SiksManager : MonoBehaviour
{
    [SerializeField] private bool isStayPlayer;
    [SerializeField] private float healTime;
    [SerializeField] private float indextime;
    [SerializeField] private GameObject parent;
    [SerializeField] private ParticleSystem particles1;
    [SerializeField] private ParticleSystem particles2;
    [SerializeField] private AudioSource reviveSound;
    
    private void Update() 
    {
        if(isStayPlayer)
        {
            if(indextime >= healTime)
            {
                Instantiate(particles1,transform.position,Quaternion.identity);
                GameManager.instance.HealAcount = 1;
                Destroy(parent);
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
            particles2.Play();
            reviveSound.Play();
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isStayPlayer = false;
            particles2.Stop();
            reviveSound.Stop();
        }    
    }
}
