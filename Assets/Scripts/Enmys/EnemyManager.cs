using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject player; // player
    [SerializeField] private GameObject MeleAttackHitbox; //hitbox donde hace daño el enemigo mele 
    [SerializeField] private EnemyAnimationController EAC; // controlador de animaciones de enemigos
    [SerializeField] private EnemyNavMesh ENM; // controlador del movimiento del enemigo
    [SerializeField] private EnemyStats ES; // estadisticas del enemigo
    [SerializeField] private MeleAttack MA; // script principal de ataque del mele
    [SerializeField] private  RangeAttack RA; // script principal de ataque del range
    [SerializeField] private RayCastEnemy RCE; // hace un rayo a la direccion del jugador
    [SerializeField] private float distance; // es la distancia actual del enemigo al jugador 

    private void Start()
    {
        // encuentra al player en escena
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
        var rotation = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        transform.LookAt(rotation);
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
