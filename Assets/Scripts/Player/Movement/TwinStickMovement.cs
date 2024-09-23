using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))] //A�ade esto automaticamente en cuanto se lo assignas al player
[RequireComponent(typeof(PlayerInput))]
public class TwinStickMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float gravityvalue = -9.81f; //Asumo que esto es por si queremos que salte pero pues no creo que sea el caso
    [SerializeField] private float controllerDeadzone = 0.1f;
    [SerializeField] private float gamepadRotateSmooothing = 1000f;

    [SerializeField] private bool isGamepad; //No es necesario esto pero sirve para testeo

    private CharacterController controller;

    private Vector2 movement;
    private Vector2 aim;

    private Vector3 playerVelocity;

    private PlayerControls playerControls;
    private PlayerInput playerInput;

    // yo te escribi estas variables

    [SerializeField] private PlayerStats PS;
    [SerializeField] private Gun gun;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerControls = new PlayerControls();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    
    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            gun.Shoot(PS.Damage);
        }
    }
    void Movement()
    {
        HandleInput();
        HandleMovement();
        HandleRotation();
    }

    void HandleInput()
    {                                                                     //playerControls es el nombre de nuestro input action
        movement = playerControls.Controls.Movement.ReadValue<Vector2>();//el Action map se llama Controls
                                                                         //y la accion en si se llama Movement
        aim = playerControls.Controls.Aim.ReadValue<Vector2>(); //Lo mismo para aim
    }

    void HandleMovement()
    {
        Vector3 move = new Vector3(movement.x, gravityvalue, movement.y); //Si metemos cualquier input lo leeremos en el Vector 3 llamado "move"
        controller.Move(move *Time.deltaTime * playerSpeed);

        //Lo siguiente es para brincar, no lo vamos a usar. Pero en caso de que si, lo pongo comentado
        //De igual forma, lei por ahi que esta forma de hacer la gravedad y el salto hace que se acumule la gravedad con el tiempo y te estampe contra el piso
        //Segun eso esto es de la documentacion de unity de Character Controller

        //playerVelocity.y += gravityvalue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime); //Esto es para que caigas
    }

    void HandleRotation() 
    { 
        //Primero tenemos que saber si se esta usando un mouse o un teclado para jugar pues la rotacion va a funcionar diferente
        if (isGamepad)
        {
            //Rota al jugado
            //Este codigo fue copiado y pegado incluso en el tutorial. Se tratara de al menos explicar ligeramente
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, gamepadRotateSmooothing * Time.deltaTime);
                    //El primer rotation se puede poner directamente a la newrotation para que cambie a donde esta volteando a ver instantaneamente aparentemente
                    //Relmente estoy pensando que jugar control es sabotearte a ti mismo considerando lo lento que voltea, aunque no esta tan mal
                    //Parece que cambiar el valor [gamepadRotateSmooothing] puede ayudar a que voltie mas rapido
                }
            }
        }
        else
        {
            //Vamos a disparar un raycast a traves de la camara a donde esta el mouse para ver donde estamos apuntando en el mundo
            //Siento que tal vez haya una forma menos desmadrosa de hacer esto, para facilitar el tiro tambien
            Ray ray = Camera.main.ScreenPointToRay(aim);
            Plane groundPlane = new Plane(Vector3.up, Vector3.up);
            float rayDistance;

            if(groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);
                LookAt(point);
            }
        }
    }

    private void LookAt(Vector3 lookPoint) 
    {//Como el mouse puede estar en cualquier punto de y, es muy probable que si lo pones encima de una caja o obstaculo, el personaje se tocera para voltear a ver el mouse
     //se tiene que corregir la rotacion de este
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z); //Se esta tomando la posicion del mouse solamente en [x] y [z]
        transform.LookAt(heightCorrectedPoint);
    }

    public void OnDeviceChance(PlayerInput pi)
    {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false; //Si si es igual a gamepad nuestro gamepad es true y si no se vuelve false 
                                                                              //El nombre del control Scheme tiene que ser el mismo que lo que va entre comillas
        
    }
}
