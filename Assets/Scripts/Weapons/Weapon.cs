using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _fireRate;
    protected float _fireRateCounter;
    protected bool _isReloading;

    public abstract void Shoot();

    void Start()
    {

    }

    void Update()
    {

    }

    public void ReloadingTimer()
    {
        if (!_isReloading)
            return;

        _fireRateCounter -= Time.deltaTime;
        if (_fireRateCounter <= 0)
        {
            _fireRateCounter = _fireRate;
            _isReloading = false;
            return;
        }
    }
}
