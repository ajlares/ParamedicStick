using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyAnimationController EAC;
    [SerializeField] private EnemyNavMesh ENM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private MeleAttack MA;
    [SerializeField] private  RangeAttack RA;
    [SerializeField] private GameObject player;
    [SerializeField] private RayCastEnemy RCE;
    [SerializeField] private float distance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitSetup();
    }

    private void Update() 
    {
         distance = Vector3.Distance(this.transform.position, player.transform.position);
        if(!ES.IsDeath)
        {
            if(ES.IsMele)
            {
                if(distance > ES.StopDistance)
                {
                    MeleeMind();
                }
                else
                {
                    ENM.SetEnable(false);
                    //att    
                }
                 
            }
            else
            {
                RCE.CreateRay(player);
                if(RCE.IsPlayer)
                {
                    ENM.SetEnable(false);
                    // att
                }
                else
                {
                    RangeMind();
                }
            }
        }
        else
        {
            Debug.Log("el chavon murio");
        }
    }

    private void MeleeMind()
    {
        if(player != null)
        {
            ENM.SetEnable(true);
            NavMeshCall();
        }
    }
    private void RangeMind()
    {
        if(player != null)
        {
            ENM.SetEnable(true);
            NavMeshCall();
        }
    }
    private void InitSetup()
    {
        ENM.SetTarget(player);
    }

    private void NavMeshCall()
    {
        ENM.NavMove();
    }

    #region getersYSeters

    public float Distance
    {
        get
        {
            return distance;
        }
    }
    #endregion
}
