using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    private static HpController _instance;
    [SerializeField] private Text _hpText;

    private int _hp;

    public int Hp
    {
        get { return _hp; }
        set
        {
            if (value > 0)
                _hp = value;
            else _hp = 0;
            _hpText.text = "HP: " + _hp.ToString();
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public static HpController GetInstance() => _instance;

    void Start()
    {

    }

    void Update()
    {

    }
}
