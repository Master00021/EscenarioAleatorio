using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _movementControl;
    [SerializeField] private InputActionReference _jumpControl ;

    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _rotationSpeed = 4f;
    [SerializeField] private float _jumpHeigth = 1.0f;
    [SerializeField] private float _gravityValue = -9.81f;
    
    private CharacterController _controller;
    private Transform _mainCameraTransform;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    

    private void Awake() {
        
        _controller = GetComponent<CharacterController>();
        _mainCameraTransform = Camera.main.transform;
    }

    private void OnEnable() {
        
        _movementControl.action.Enable();
        _jumpControl.action.Enable();
    }

    private void OnDisable() {
        
        _movementControl.action.Disable();
        _jumpControl.action.Disable();
    }

    private void Update() {
        
        _groundedPlayer = _controller.isGrounded;

        if (_groundedPlayer && _playerVelocity.y < 0) {

            _playerVelocity.y = 0f;
        }

        Vector2 _movement = _movementControl.action.ReadValue<Vector2>();

        Vector3 _move = new Vector3(_movement.x, 0, _movement.y);

        _move = _mainCameraTransform.forward * _move.z + _mainCameraTransform.right * _move.x;
        _move.y =  0f;

        _controller.Move(_move * _playerSpeed * Time.deltaTime);

        if (_jumpControl.action.triggered && _groundedPlayer) {

            _playerVelocity.y += Mathf.Sqrt(_jumpHeigth * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);

        if (_movement != Vector2.zero) {

            float _targetAngle = Mathf.Atan2(_movement.x, _movement.y) * Mathf.Rad2Deg + _mainCameraTransform.eulerAngles.y;

            Quaternion _rotation = Quaternion.Euler(0f, _targetAngle, 0f);

            transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("NextLevel")) {

            PieceSpawner.LimitePiezas = 0;

            SceneManager.LoadScene("EscenarioAleatorio");
        }
    }
}