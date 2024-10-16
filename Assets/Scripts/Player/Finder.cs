using System;
using UnityEngine;

public class Finder : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Heel heel))
        {
            _player.AddLife();
            heel.Delete();
        }
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Delete();
        }
    }
}
