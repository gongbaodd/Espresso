using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CollectableController : MonoBehaviour
{
    [SerializeField] private CollectableConfig config;
    public event System.Action<CollectableType> OnCollectableTriggered;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCollectableTriggered?.Invoke(config.collectableType);
            Destroy(gameObject);
        }
    }
}
