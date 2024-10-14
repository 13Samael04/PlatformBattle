using UnityEngine;

public class ObstacleChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _maskGround;
    [SerializeField] private float _distance;

    public bool CheckGround() => Physics2D.Raycast(transform.position, Vector2.down, _distance, _maskGround);
}
