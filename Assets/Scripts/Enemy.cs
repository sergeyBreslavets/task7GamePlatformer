using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private SpriteRenderer _spriteRender;
    [SerializeField] private Transform[] _points;

    private int _curentTarget = 0;

    private void Update()
    {
        Transform target = _points[_curentTarget];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        float direction = transform.position.x - target.position.x;
        bool isRightDirection = direction < 0;
        _spriteRender.flipX = isRightDirection;

        if (transform.position == target.position)
        {
            _curentTarget++;

            if (_curentTarget == _points.Length)
            {
                _curentTarget = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Person _target;

        if (collision.transform.TryGetComponent<Person>(out _target))
        {
            _target.Kill();
        }
    }
}
