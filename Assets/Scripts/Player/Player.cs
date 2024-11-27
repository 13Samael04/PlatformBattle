using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _lifeCount;

    private int _damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Worm>(out Worm worm))
        {
            Attack(worm);
        }
    }

    public void AddLife()
    {
        _lifeCount++;
    }

    public void TakeDamage(int damage)
    {
        _lifeCount -= damage;
        Debug.Log(_lifeCount);
    }

    private void Attack(Worm worm)
    {
        worm.TakeDamage(_damage);
    }
}
