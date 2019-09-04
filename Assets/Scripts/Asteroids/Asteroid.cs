using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        MoveDownLinear();
    }

    private void MoveDownLinear()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y -transform.up.y, Time.deltaTime * _speed), 0);
    }
}
