using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _hp;
    [SerializeField] protected int _score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void Die();

    public void OffScreenDestroy()
    {
        if (transform.position.y + GetComponent<Renderer>().bounds.size.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
            Destroy(gameObject);
    }

    public void AddScore(int score)
    {
        ScoreController.GetInstance().Score += score;
    }
}
