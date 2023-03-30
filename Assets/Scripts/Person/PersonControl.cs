using UnityEngine;
using UnityEngine.Events;

public class PersonControl : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpForce = 20;
    [SerializeField] private CapsuleCollider2D _capsuleCollider;
    [SerializeField] private Rigidbody2D _rigidbody2d;

    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;

    [SerializeField] private UnityEvent _personMoveLeft;
    [SerializeField] private UnityEvent _personMoveRight;
    [SerializeField] private UnityEvent _personStop;
    [SerializeField] private UnityEvent _personJump;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        MoveHorizont(_speed * Time.deltaTime * direction);

        if (Input.GetKey(_jump) && IsGrounded())
        {
            _personJump.Invoke();
            _rigidbody2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
        }
    }

    private void MoveHorizont(float x)
    {
        if (x > 0)
            _personMoveRight.Invoke();
        else if (x < 0)
            _personMoveLeft.Invoke();
        else
            _personStop.Invoke();

        transform.Translate(x, 0, 0);
    }

    private bool IsGrounded()
    {
        float offset = .01f;
        float halfColliderY = _capsuleCollider.size.y / 2f;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - halfColliderY - offset);
        float distance = 0.1f;
        RaycastHit2D groundCheck = Physics2D.Raycast(origin, -transform.up, distance);
        bool isGround = groundCheck && groundCheck.transform.TryGetComponent<Ground>(out Ground ground);
        return isGround;
    }
}
