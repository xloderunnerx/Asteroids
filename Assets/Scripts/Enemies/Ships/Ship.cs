using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : Enemy
{

    [SerializeField] protected List<Weapon> _weapons;
    [SerializeField] protected float _speed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void FireWeapons()
    {
        foreach(Weapon w in _weapons)
        {
            w.Shoot();
        }
    }

    public void MoveDownLinear()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y - transform.up.y, Time.deltaTime * _speed), 0);
    }

}
