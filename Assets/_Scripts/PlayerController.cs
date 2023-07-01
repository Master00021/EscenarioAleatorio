using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float jumpHeight = 2f; // Altura del salto
    private float ySpeed; // Velocidad vertical

    private CharacterController controller;
    private Vector3 moveDirection;

    private bool isJumping = false;
    private bool isGrounded = true;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Movimiento horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Movimiento vertical
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula la dirección del movimiento
        moveDirection = transform.forward * moveVertical + transform.right * moveHorizontal;
        moveDirection *= speed;

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            ySpeed = Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(Physics.gravity.y));
        }

        // Aplica la gravedad
        ySpeed += Physics.gravity.y * Time.deltaTime;

        // Aplica el movimiento vertical
        moveDirection.y = ySpeed;

        // Aplica el movimiento al CharacterController
        controller.Move(moveDirection * Time.deltaTime);

        // Verifica si el CharacterController está en el suelo
        if (controller.isGrounded)
        {
            isGrounded = true;
            isJumping = false;
            ySpeed = 0f;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.R)) {

            PieceSpawner.LimitePiezas = 0;
            SceneManager.LoadScene("EscenarioAleatorio", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("NextLevel")) {

            PieceSpawner.LimitePiezas = 0;
            SceneManager.LoadScene("EscenarioAleatorio", LoadSceneMode.Single);
        }
    }
}