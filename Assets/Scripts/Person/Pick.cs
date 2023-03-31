using UnityEngine;
using UnityEngine.Events;

public class Pick : MonoBehaviour
{
    [SerializeField] private UnityEvent _pickMoney;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Money>(out Money money))
        {
            Destroy(money.gameObject);
            _pickMoney.Invoke();
        }
    }
}
