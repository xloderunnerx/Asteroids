using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    private static GameInit _instance;

    [SerializeField] private List<GameObject> _toInit;

    private void Awake()
    {
        _instance = this;
    }

    public static GameInit GetInstance() => _instance;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Init()
    {
        foreach(GameObject g in _toInit)
        {
            g.SetActive(true);
        }
    }
}
