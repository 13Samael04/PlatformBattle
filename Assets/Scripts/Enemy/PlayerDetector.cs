using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private Vector2 _boxSize;

    private Vector3 _position;

    public bool CanFollowPlayer() => Physics2D.BoxCast(transform.position, _boxSize, 0f, transform.right, 0f, _playerMask);

    public bool CanFollowPlayer2(out Vector3 targetPosition) 
    {
        targetPosition = Vector2.zero;
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, _boxSize, 0f, transform.right, 0f, _playerMask);

        if (hit.collider != null)
        {
            targetPosition = hit.collider.bounds.center;
            return Physics2D.BoxCast(transform.position, _boxSize, 0f, transform.right, 0f, _playerMask);
        }

        return false;
    }
}
