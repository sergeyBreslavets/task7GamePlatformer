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
            Destroy(money.gameObject);
            _pickMoney.Invoke();
        }
    }
}
