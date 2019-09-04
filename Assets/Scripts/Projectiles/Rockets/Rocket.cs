using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] public GameObject _target;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float FindTargetAngle()
    {
        if (_target == null)
            return 0;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(_target.transform.position.x - transform.position.x, _target.transform.position.y - transform.position.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        return angle;

    }
}
