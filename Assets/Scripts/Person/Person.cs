using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Person : MonoBehaviour
{
    [SerializeField] private UnityEvent _die;
    [SerializeField] private float _timeDie = 1;

    private Vector3 _initPosition;
    private Coroutine _killAnimation;

    public void Start()
    {
        _initPosition = transform.position; 
    }

    public void Respawn()
    {   
        transform.position = _initPosition;
        StopCoroutine(_killAnimation);
    }

    public void Kill() {
        _killAnimation = StartCoroutine(KillAnimation());
    }

    private IEnumerator KillAnimation() {
        _die.Invoke();
        yield return new WaitForSeconds(_timeDie);
        Respawn();
    }
}
