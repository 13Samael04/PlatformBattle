using UnityEngine;


public class Worm : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    private Animator _animator;
    private int _wormHash = Animator.StringToHash("Worm");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(_wormHash);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Attack(player);
        }
    }

    private void Attack(Player player)
    {
        player.TakeDamage(_damage);
    }
}
