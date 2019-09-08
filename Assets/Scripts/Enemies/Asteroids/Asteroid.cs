using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Enemy, IDamageSetable
{
    private float _size;
    public float Size
    {
        get { return _size; }
        set { _size = value; }
    }

    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    void Start()
    {
        _hp = 0;
    }
    
    void Update()
    {
        MoveDownLinear();
        OffScreenDestroy();
    }

    private void MoveDownLinear()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y -transform.up.y, Time.deltaTime * _speed), 0);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public void OffScreenDestroy()
    {
        if (transform.position.y + _size < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == null)
            return;

        collision.gameObject.GetComponent<IDamageSetable>().SetDamage((int)(_size * 100));
        Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            Die();
    }
}
