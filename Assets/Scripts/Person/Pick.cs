using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Money money = null;

        if (collision.transform.TryGetComponent<Money>(out money))
        {
            Destroy(money.gameObject);
        }
    }
}
