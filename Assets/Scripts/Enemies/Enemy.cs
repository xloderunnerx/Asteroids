using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _hp;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void Die();
}
