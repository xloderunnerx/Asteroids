using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngineController : MonoBehaviour
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _rotationSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        RotateEngine();
    }

    void RotateEngine()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -Input.GetAxis("Horizontal") * _maxAngle)), Time.deltaTime * _rotationSpeed);
    }
}
