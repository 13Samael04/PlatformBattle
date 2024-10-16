using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
    public event Action<Coin> Destroyed;

    public void Delete()
    {
        Destroyed?.Invoke(this);
    }
}
