using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaShip : Ship, IDamageSetable
{
 

    void Start()
    {
        
    }

    void Update()
    {
        MoveDownLinear();
        FireWeapons();
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            Die();
    }

}
