using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyShipsSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> _enemyShips;
    private float _spawnRationCounter;
    [SerializeField ]private float _spawnRatio;

    void Start()
    {
        _enemyShips = Resources.LoadAll<GameObject>("Prefabs/Enemies/Ships/").ToList();
    }

    
    void Update()
    {
        Spawn(GetRandomPositionAboveScreen());
    }

    private void Spawn(Vector2 position)
    {
        if (!SpawnTimer())
            return;

        Instantiate(_enemyShips[Random.Range(0, _enemyShips.Count)], position, Quaternion.identity);
    }

    private bool SpawnTimer()
    {
        _spawnRationCounter -= Time.deltaTime;
        if (_spawnRationCounter <= 0)
        {
            _spawnRationCounter = _spawnRatio;
            return true;
        }
        return false;
    }

    private Vector2 GetRandomPositionAboveScreen() => Camera.main.transform.position - transform.position + GetWorldViewPort(new Vector2(UnityEngine.Random.Range(0.0f, 1.0f), 1 + 0.1f));

    Vector3 GetWorldViewPort(Vector2 normalizedPos) => Camera.main.ViewportToWorldPoint(new Vector3(normalizedPos.x, normalizedPos.y, Camera.main.nearClipPlane));

}
