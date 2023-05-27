using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// Simple character Controller
/// </Summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 3;
    [SerializeField] private int jumpForce = 5;
    [SerializeField] private int gameOverDropLimit = -5;
    [SerializeField] private Transform spawnPoint;

    private Rigidbody _rigidBody;
    private Animator _animator;
    private bool _isGrounded;
    private bool _isDying;

    void Awake()
    {
        PlayerHealth.Instance.OnLostLife += OnLostLife;
    }

    void Start() 
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        _animator.SetBool("IsMoving", Mathf.Abs(_rigidBody.velocity.x) > 0.2 || 
            Mathf.Abs(_rigidBody.velocity.z) > 0.2);

        // GetAxisRaw will return value between 0 & 1
        float leftRight = Input.GetAxisRaw("Horizontal") * speed;
        float upDown = Input.GetAxisRaw("Vertical") * speed;

        // Y value is kept at current value as no change
        _rigidBody.velocity = new Vector3(leftRight, _rigidBody.velocity.y, upDown);
        // have player face direction of travel
        var facingDirection = _rigidBody.velocity;
        facingDirection.y = 0; // remove any up or down velocity as don't need it to face way we're moving
        // only change to face direction if we're moving, which will prevent reset when stopped
        if (facingDirection.x != 0 || facingDirection.z != 0)
        {
            transform.forward = facingDirection;
        }

        if (_isGrounded && isJumping)
        {
            _rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

        if (!_isDying && transform.position.y < gameOverDropLimit)
        {
            _isDying = true;
            PlayerHealth.Instance.LoseLife();
        }
    }

    // Collision param contains info ref the collision point between this mesh and another mesh
    // Using this method to check if we've landed on something, which we assume to be the ground
    private void OnCollisionEnter(Collision other) 
    {
        // the .normal here is the face of the other object we've collided with
        // if that face is pointing up, we've landed on it
        if (other.contacts[0].normal == Vector3.up)
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayerHealth.Instance.LoseLife();
            if (PlayerHealth.Instance.IsAlive)
            {
                // reset level - this is done by game over controller atm
            }
        }
    }

    // reset player back to respawn point when lost a life and still have lives left
    // Game Over script will reload the scene when lives hit zero
    private void OnLostLife(object sender, int lives)
    {
        if (lives > 0)
        {
            if (spawnPoint != null) 
            {
                transform.position = spawnPoint.transform.position;
                transform.rotation = spawnPoint.transform.rotation;
            }

            _isDying = false;
        }
    }
}
