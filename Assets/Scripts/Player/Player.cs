using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageSetable
{
    private static Player _instance;
    
    [SerializeField] private Vector2 _startPosition;
    [SerializeField ]private bool _isReadyToPlay;

    [SerializeField] private Weapon _weapon;
    [SerializeField] private PlayerEngineController _engine;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private int _hp;


    private void Awake()
    {
        _instance = this;
    }

    public static Player GetInstance() => _instance;

    void Start()
    {
        HpController.GetInstance().Hp = _hp;
        _isReadyToPlay = false;
    }

    void Update()
    {
        MovingToStartPosition();
        FireWeapon();
    }

    private void FireWeapon()
    {
        if (!_isReadyToPlay)
            return;

        if (_weapon == null)
            return;

        if (!Input.GetKey(KeyCode.Space))
            return;

        _weapon.Shoot();
    }

    public void SetDamage(int damage)
    {
        _hp -= damage;
        HpController.GetInstance().Hp = _hp;
        if (_hp <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void MovingToStartPosition()
    {
        if (_isReadyToPlay)
            return;

        transform.position = new Vector2(Mathf.Lerp(transform.position.x, _startPosition.x, Time.deltaTime * 5), Mathf.Lerp(transform.position.y, _startPosition.y, Time.deltaTime *5));
        if (Vector2.Distance(transform.position, _startPosition) < 0.05f)
            Init();
    }

    public void Init()
    {
        _isReadyToPlay = true;
        _engine.enabled = true;
        _controller.enabled = true;
        transform.position = _startPosition;
    }
}
