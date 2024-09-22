using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject MeleAttackHitbox;
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
        if(ES.IsMele)
        {
            MeleAttackHitbox.GetComponent<MeleAplyDamage>().Damage = ES.Damage;
        }
    }

    private void Update() 
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        transform.LookAt(player.transform.position);
        if(!ES.IsDeath)
        {
            if(ES.IsMele)
            {
                //pensamiento del mele
                if(distance > ES.StopDistance)
                {
                    Walk();
                }
                else
                {
                    ENM.SetEnable(false);
                    if(ES.CanAttack)
                    {
                        // mele attack
                        StartCoroutine(MeleAttackCall());   
                    } 
                }
                 
            }
            else
            {
                // pensamiento del range
                RCE.CreateRay(player, ES.RangeMaxDistance);
                if(RCE.IsPlayer)
                {
                    if(ES.CanAttack)
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
        ES.CanAttack = false;
        yield return new WaitForSeconds(0.1f);
        ENM.SetEnable(false);
        RA.Shoot(ES.Damage, player);
        yield return new WaitForSeconds(ES.AttackColdown);
        ES.CanAttack = true;
        yield return null;
    }

    IEnumerator MeleAttackCall()
    {
        ES.CanAttack = false;
        yield return new WaitForSeconds(0.2f);
        MeleAttackHitbox.SetActive(true);
        player.GetComponent<PlayerStats>().Life = ES.Damage;
        yield return new WaitForSeconds(0.2f);
        MeleAttackHitbox.SetActive(false);
        yield return new WaitForSeconds(ES.AttackColdown);
        yield return null;
        ES.CanAttack = true;
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
