using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _lifeCount;

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
