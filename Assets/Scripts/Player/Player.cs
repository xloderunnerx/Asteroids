using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageSetable
{
    private static Player _instance;

    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _hp;


    private void Awake()
    {
        _instance = this;
    }

    public static Player GetInstance() => _instance;

    void Start()
    {
        
    }

    
    void Update()
    {
        FireWeapon();
    }

    private void FireWeapon()
    {
        if (_weapon == null)
            return;

        if (!Input.GetKey(KeyCode.Space))
            return;

        _weapon.Shoot();
    }

    public void SetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
