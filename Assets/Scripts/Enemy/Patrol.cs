using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ObstacleChecker _obstacleChecker;

    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);
    private bool _isLeft = true;

    public void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (_obstacleChecker.CheckGround() == false)
        {
            if (_isLeft == true)
            {
                transform.rotation = TurnLeft;
                _isLeft = false;
            }
            else
            {
                transform.rotation = TurnRight;
                _isLeft = true;
            }
        }
    }
}
