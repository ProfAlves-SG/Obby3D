using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask ground;
    
    [Header("Movement Stats")] 
    public float moveSpeed;

    public float jumpForce;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    
    void Update()
    {
        MyInput();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    void MovePlayer()
    {
        _moveDirection = (orientation.forward * _verticalInput) + (orientation.right * _horizontalInput);
        
        rb.velocity = new Vector3(_moveDirection.x  * moveSpeed, rb.velocity.y, _moveDirection.z  * moveSpeed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.OverlapSphere(groundCheck.position, 0.1f, ground).Length > 0;
    }
}