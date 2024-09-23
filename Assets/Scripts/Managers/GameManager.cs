using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy( this);
        }    
    }
    [SerializeField] private int healAcount;
    [SerializeField] private int killsAcount;
    
    public int HealAcount
    {
        get 
        {
            return healAcount;
        }
        set
        {
            healAcount += value;
        }
    }

    public int KillsAcount
    {
        get
        {
            return killsAcount;        
        }
        set
        {
            killsAcount += value;
        }
    }
}
