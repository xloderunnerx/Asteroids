using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegularBullet : MonoBehaviour
{
    [SerializeField] private int _damage;


    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == null)
            return;

        collision.gameObject.GetComponent<IDamageSetable>().SetDamage(_damage);
        Destroy(gameObject);
    }
}
