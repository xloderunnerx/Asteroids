using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _horizontalSpeed;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        

        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _horizontalSpeed, _rigidbody2D.velocity.y);
    }

}
