using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammaShip : Ship, IDamageSetable
{
    void Start()
    {

    }

    void Update()
    {
        MoveDownLinear();
        FireWeapons();
        OffScreenDestroy();
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
