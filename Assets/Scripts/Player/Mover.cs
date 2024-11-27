using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(PlayerInput))]

public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private readonly int _runHash = Animator.StringToHash("Run");
    private readonly int _jumpHash = Animator.StringToHash("Jump");
    private readonly int _idleHash = Animator.StringToHash("Idle");

    private Rigidbody2D _rigidbody2d;
    private GroundChecker _groundChecker;
    private Animator _animator;
    private float _rotateAngle = 180;
    private float _directionX;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _rigidbody2d.freezeRotation = true;
    }

    private void Update()
    {
        Jump(_playerInput.IsJump);
    }

    private void FixedUpdate()
    {
        Move(_playerInput.DirectionX);
    }

    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction, 0);

        Rotate(direction);
        _rigidbody2d.velocity = new Vector2(direction * _speed, _rigidbody2d.velocity.y);

        if (direction != 0 && _groundChecker.IsGround())
        {
            _animator.Play(_runHash);
        }
        else
        {
            _animator.Play(_idleHash);
        }
    }

    private void Rotate(float diriction)
    {
        if (diriction < 0)
        {
            transform.eulerAngles = Vector3.up * _rotateAngle;
        }
        else if (diriction > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void Jump(bool isJump)
    {
        if (_groundChecker.IsGround())
        {
            if (isJump)
            {
                _rigidbody2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _animator.Play(_jumpHash);
            }
        }
    }
}
