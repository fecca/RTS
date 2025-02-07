using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileView : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(direction);
        _rigidbody.linearVelocity = direction * speed;
        
        Destroy(gameObject, 1.0f);
    }
}