using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class AidKit : MonoBehaviour
{
    public void Delete()
    {
        Destroy(gameObject);
    }
}
