using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Enemy _target;
    [SerializeField] private float _initialRocketForce;


    private LineRenderer _cosmeticLaserSight;
    [SerializeField] private float _laserSightLength;

    void Start()
    {
        _cosmeticLaserSight = GetComponent<LineRenderer>();
        _isReloading = false;
        _fireRateCounter = _fireRate;
    }

    void Update()
    {
        ReloadingTimer();
        LaserSight();
    }

    private void LateUpdate()
    {
        CosmeticLaserSight();
    }

    public override void Shoot()
    {
        if (_isReloading)
            return;

        GameObject rocket = Instantiate(_rocket.gameObject, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0.0f, 0.0f))));
        if (_target != null)
            rocket.GetComponent<Rocket>()._target = _target.gameObject;
        rocket.GetComponent<Rigidbody2D>().AddForce(transform.up * _initialRocketForce, ForceMode2D.Impulse);

        _isReloading = true;
    }

    private void LaserSight()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.up, _laserSightLength);
        if (rayHit.collider == null)
        {
            _target = null;
            return;
        }
        if (rayHit.collider.gameObject.GetComponent<Enemy>() == null)
        {
            _target = null;
            return;
        }
        _target = rayHit.collider.gameObject.GetComponent<Enemy>();
    }

    private void CosmeticLaserSight()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.up, _laserSightLength);

        float laserWorldLength = transform.position.y + transform.up.y * _laserSightLength;
        if (rayHit.collider != null)
            laserWorldLength -= laserWorldLength - rayHit.point.y;

        _cosmeticLaserSight.SetPosition(0, transform.position);
        _cosmeticLaserSight.SetPosition(1, new Vector3(transform.position.x, laserWorldLength));
    }


}
