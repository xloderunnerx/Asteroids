using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GunTower : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private float _rotationSpeed;

    void Start()
    {
        if (Player.GetInstance() == null)
            return;
        _target = Player.GetInstance().gameObject;
    }

    void Update()
    {
        RotateOnTarget();
    }

   

    private void RotateOnTarget()
    {
        if (_target == null)
            return;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, FindTargetAngle() - 90), Time.deltaTime * _rotationSpeed);
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
