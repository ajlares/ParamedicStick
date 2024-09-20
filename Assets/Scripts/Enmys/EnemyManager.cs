using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyAnimationController EAC;
    [SerializeField] private EnemyNavMesh ENM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private MeleAttack MA;
    [SerializeField] private  RangeAttack RA;
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitSetup();
    }

    private void Update() 
    {
        if(!ES.IsDeath())
        {
            if(ES.IsMele())
            {
                MeleeMind();
            }
            else
            {
                RangeMind();
            }
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
}
