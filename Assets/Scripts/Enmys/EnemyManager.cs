using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject player; // player
    [SerializeField] private GameObject MeleAttackHitbox; //hitbox donde hace daño el enemigo mele 
    [SerializeField] private EnemyAnimationController EAC; // controlador de animaciones de enemigos
    [SerializeField] private EnemyNavMesh ENM; // controlador del movimiento del enemigo
    [SerializeField] private EnemyStats ES; // estadisticas del enemigo
    [SerializeField] private  RangeAttack RA; // script principal de ataque del range
    [SerializeField] private RayCastEnemy RCE; // hace un rayo a la direccion del jugador
    [SerializeField] private float distance; // es la distancia actual del enemigo al jugador 
    [SerializeField] private ParticleSystem meat;// sistema de particulas antes de la muerte
    [SerializeField] private List<AudioSource> sounds;

    private void Start()
    {
        // encuentra al player en escena
        player = GameObject.FindGameObjectWithTag("Player"); 
        //reparte las cosas que necesitan a los scripts
        InitSetup();

    }

    private void Update() 
    { 
        // calcula la distancia actual entre el jugador y el enemigo
        distance = Vector3.Distance(this.transform.position, player.transform.position);
        // hace que el enemigo voltie a ver al jugador
            var lookPose = player.transform.position - transform.position;
            lookPose.y = 0;
            var rotation = Quaternion.LookRotation(lookPose);
            transform.rotation = rotation;
        // si no esta muerto el enemigo hace cosas
        if(!ES.IsDeath)
        {
            // si es mele hace algo
            if(ES.IsMele)
            {
                //pensamiento del mele
                // si la distancia actual es menor a la distancia de parar hace algo
                if(distance > ES.StopDistance && ES.CanAttack)
                {
                    // sigue al jugador+
                    //ES.CanAttack = true;
                    EAC.CallAnim(1);
                    Walk();
                }
                // si no es asi
                else
                {
                    // deja de caminar
                    ENM.SetEnable(false);
                    // si puede atacar
                    if(ES.CanAttack)
                    {
                        // mele attack
                        EAC.CallAnim(2);
                        ES.CanAttack = false;
                    } 
                }
                 
            }
            // si no hace otra cosa
            else
            {
                // pensamiento del range 
                // crea un rayo al enemigo para ver si lo tiene en la mira
                RCE.CreateRay(player, ES.RangeMaxDistance);
                // si si lo tiene en la mira ataca
                if(RCE.IsPlayer)
                {
                    if(player.transform.position.y < transform.position.y + 5 && player.transform.position.y > transform.position.y - 5)
                    {
                    // si puede atacar
                    if(ES.CanAttack)
                    {
                        // ataca
                        StartCoroutine(AttackRangeCall());
                    }
                    }
                    else
                    {
                        EAC.CallAnim(1);
                        Walk();
                    }

                }
                // si no lo tiene en la mira camina
                else
                {
                    EAC.CallAnim(1);
                    Walk();
                }
            }
        }
        // si esta muerto
        else
        {
            ENM.SetEnable(false);
            Instantiate(meat,transform.position,Quaternion.identity);
            GameManager.instance.KillsAcount = 1;
            Destroy(gameObject);

        }
    }

    // Funcion para caminar
    private void Walk()
    {
        // revisa que el enemigo tenga registrado al player
        if(player != null)
        {
            // activa el caminado
            ENM.SetEnable(true);
            // activa el navmesh
            ENM.NavMove();
        }
    }
    // setup inicial de las cosas
    private void InitSetup()
    {
        // le pasa erl target al navmesh
        ENM.SetTarget(player);
         // si es mele le pasa el daño a su respectivo script
        if(ES.IsMele)
        {
            MeleAttackHitbox.GetComponent<MeleAplyDamage>().Damage = ES.Damage;
        }
    }

    // corutina del ataque de range
    IEnumerator AttackRangeCall()
    {
        EAC.CallAnim(2);
        ES.CanAttack = false;        
        yield return new WaitForSeconds(0.1f);
        ENM.SetEnable(false);
        sounds[0].Play();
        RA.Shoot(ES.Damage, player);
        EAC.CallAnim(0);
        yield return new WaitForSeconds(ES.AttackColdown);
        ES.CanAttack = true;
        yield return null;
    }

    // corutina del ataque a mele
    public void OnHitbox()
    {
        sounds[0].Play();
        MeleAttackHitbox.SetActive(true);
    }
    public void OfHitbox()
    {
        MeleAttackHitbox.SetActive(false);
    }
    public void CanAttack()
    {
        ES.CanAttack = true;
    }

    #region getersYSeters

    // geter para que otros scripts puedan acceder a la distancia
    public float Distance
    {
        get
        {
            return distance;
        }
    }
    #endregion
}
