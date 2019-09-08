using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerRegularRocket : Rocket
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private ParticleSystem _explosionProjectiles;

    void Start()
    {
        Destroy(gameObject, 10.0f);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RotateOnTarget();
        TargetSearching();
    }

    public void FixedUpdate()
    {
        MoveUp();
    }

    private void TargetSearching()
    {
        if (_target != null)
            return;

        Collider2D[] potentialTargets = Physics2D.OverlapCircleAll(transform.position, 2);
        if (Array.ConvertAll(potentialTargets, c => c.gameObject).Where(t => t.GetComponent<Enemy>() != null).Count() == 0)
            return;

        _target = Array.ConvertAll(potentialTargets, c => c.gameObject).Where(t => t.GetComponent<Enemy>() != null).ElementAt(0);
    }

    private void MoveUp()
    {
        _rigidbody2D.velocity = transform.up * _movementSpeed;
    }

    private void RotateOnTarget()
    {
        if (_target == null)
            return;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, FindTargetAngle() - 90), Time.deltaTime * _rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() == null)
            return;

        _explosionProjectiles.Emit(UnityEngine.Random.Range(2, 5));

        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject, 1.0f);
        }
        transform.DetachChildren();

        collision.gameObject.GetComponent<IDamageSetable>().SetDamage(_damage);
        Destroy(gameObject);
    }

}
