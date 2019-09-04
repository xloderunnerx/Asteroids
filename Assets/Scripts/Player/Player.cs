using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

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
}
