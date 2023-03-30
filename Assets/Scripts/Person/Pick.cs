using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pick : MonoBehaviour
{
    [SerializeField] private UnityEvent _pickMoney;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Money money = null;

        if (collision.transform.TryGetComponent<Money>(out money))
        {   
            _pickMoney.Invoke();
            Destroy(money.gameObject);
           
        }
    }
}
