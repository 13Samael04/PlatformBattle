using UnityEngine;


public class Pursue : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ObstacleChecker _obstacleChecker;

    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public void FollowToPlayer(Vector3 player)
    {
        Vector3 direcion = (player - transform.position).normalized;
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
        transform.rotation = GetRotation(player);
    }

    private Quaternion GetRotation(Vector3 player)
    {
        if (player.x < transform.position.x)
        {
            return TurnRight;
        }
        if (player.x > transform.position.x)
        {
            return TurnLeft;
        }

        return transform.rotation;
    }
}
