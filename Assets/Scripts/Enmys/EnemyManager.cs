using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private EnemyAnimationController EAC;
    [SerializeField] private EnemyNavMesh ENM;
    [SerializeField] private EnemyStats ES;
    [SerializeField] private MeleAttack MA;
    [SerializeField] private  RangeAttack RA;
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
        transform.LookAt(player.transform.position);
        if(!ES.IsDeath)
        {
            if(ES.IsMele)
            {
                if(distance > ES.StopDistance)
                {
                    Walk();
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
                    if(ES.CanShoot)
                    {
                        StartCoroutine(AttackRangeCall());
                    }

                }
                else
                {
                    Walk();
                }
            }
        }
        else
        {
            Debug.Log("el chavon murio");
        }
    }

    private void Walk()
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

    IEnumerator AttackRangeCall()
    {
        ES.CanShoot = false;
        RA.Shoot(ES.Damage, player);
        yield return new WaitForSeconds(ES.AttackColdown);
        ES.CanShoot = true;
        yield return null;
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
