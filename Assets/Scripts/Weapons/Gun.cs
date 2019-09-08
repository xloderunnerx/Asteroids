using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _shootOffset;

    void Start()
    {
        _isReloading = false;
        _fireRateCounter = _fireRate;
    }

    void Update()
    {
        ReloadingTimer();
    }

    public override void Shoot()
    {
        if (_isReloading)
            return;

        if (_bullet == null)
            return;

        GameObject bullet = Instantiate(_bullet, transform.position + transform.up * _shootOffset, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * _bulletForce, ForceMode2D.Impulse);

        _isReloading = true;
    }

}
