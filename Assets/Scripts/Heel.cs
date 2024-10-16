using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Heel : MonoBehaviour
{
    public void Delete()
    {
        Destroy(gameObject);
    }
}
