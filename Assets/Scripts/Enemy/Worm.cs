using UnityEngine;

public class Worm : MonoBehaviour
{
    [SerializeField] private ObstacleChecker _obstacleChecker;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _lifeCount = 1;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private PlayerDetector _characterDetector;
    private Patrol _patrolState;
    private Pursue _purseState;
    private int _wormHash = Animator.StringToHash("Worm");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterDetector = GetComponent<PlayerDetector>();
        _patrolState = GetComponent<Patrol>();
        _purseState = GetComponent<Pursue>();
    }

    private void Start()
    {
        _animator.Play(_wormHash);
    }

    private void Update()
    {
        Move();
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

    public void TakeDamage(int damage)
    {
        _lifeCount -= damage;
        Debug.Log($"у врана жизней {_lifeCount}");

        if ( _lifeCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (_characterDetector.CanFollowPlayer(out Vector3 targetPosition))
        {
            _purseState.FollowToPlayer(targetPosition);
            Debug.Log("приследование");
        }
        else
        {
            _patrolState.Move();
            Debug.Log("Патруль");
        }
    }
}
