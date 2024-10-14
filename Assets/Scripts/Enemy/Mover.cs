using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerDetector))]

public class Mover : MonoBehaviour
{
    [SerializeField] private ObstacleChecker _obstacleChecker;

    private Rigidbody2D _rigidbody2D;
    private PlayerDetector _characterDetector;
    private Patrol _patrolState;
    private Pursue _purseState;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterDetector = GetComponent<PlayerDetector>();
        _patrolState = GetComponent<Patrol>();
        _purseState = GetComponent<Pursue>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_characterDetector.CanFollowPlayer2(out Vector3 targetPosition))
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
