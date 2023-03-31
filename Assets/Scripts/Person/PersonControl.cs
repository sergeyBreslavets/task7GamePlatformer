using UnityEngine;
using UnityEngine.Events;

public class PersonControl : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _jumpForce = 20;
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private KeyCode _jump = KeyCode.Space;

    [SerializeField] private UnityEvent _personMoveLeft;
    [SerializeField] private UnityEvent _personMoveRight;
    [SerializeField] private UnityEvent _personStop;
    [SerializeField] private UnityEvent _personJump;

    private bool _isGrounded = true;

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.transform.TryGetComponent<Ground>(out Ground ground))
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null && collision.transform.TryGetComponent<Ground>(out Ground ground))
            _isGrounded = false;
    }

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        MoveHorizont(_speed * Time.deltaTime * direction);

        if (Input.GetKey(_jump) && _isGrounded)
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
}
