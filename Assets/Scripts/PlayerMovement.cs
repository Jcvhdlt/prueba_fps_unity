using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller; // CharacterController del jugador
    public float speed = 12f; // velocidad del jugador
    public float gravity = -9.81f; // gravedad del jugador
    Vector3 velocity; // velocidad del jugador

    public Transform groundCheck; // Transform del objeto que se usa para verificar si el jugador esta en el suelo
    public float sphereRadius = 0.3f; // radio de la esfera que se usa para verificar si el jugador esta en el suelo
    public LayerMask groundMask; // mascara de la capa del suelo

    private bool isGrounded; // variable que indica si el jugador esta en el suelo

    public float jumpHeight = 3f; // altura del salto
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask); // se verifica si el jugador esta en el suelo
        if(isGrounded && velocity.y < 0) // si el jugador esta en el suelo y la velocidad en y es menor a 0.
        {
            velocity.y = -2f; // se le asigna -2 a la velocidad en y
        }
      float x = Input.GetAxis("Horizontal"); // se obtiene el movimiento en x
      float y = Input.GetAxis("Vertical"); // se obtiene el movimiento en y 

      Vector3 move = transform.right * x + transform.forward * y; // se obtiene el vector de movimiento
      controller.Move(move * speed * Time.deltaTime); // se mueve el jugador

      if(Input.GetKeyDown(KeyCode.Space) && isGrounded ) // si se presiona la tecla de espacio y el jugador esta en el suelo
      {
          velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // se le asigna la velocidad del salto a la velocidad en y
      }

      velocity.y += gravity * Time.deltaTime; // se aplica la gravedad
        controller.Move(velocity * Time.deltaTime); // se mueve el jugador
    }

}
