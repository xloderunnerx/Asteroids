using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AsteroidSpawner : MonoBehaviour
{
    private static AsteroidSpawner _instance;

    [SerializeField] private Material _asteroidBorder;
    [SerializeField] private Material _asteroidFill;

    [SerializeField] private float _spawnRatio;
    private float _spawnRationCounter;

    [SerializeField] private float _borderSize;
    [SerializeField] private float _size;
    [SerializeField] private int _verticesCount;
    [SerializeField] private float _speed;

    [SerializeField] private bool _randomizeValues;

    private void Awake()
    {
        _instance = this;
    }

    public static AsteroidSpawner GetInstance() => _instance;

    void Start()
    {
        _spawnRationCounter = _spawnRatio;

    }


    void Update()
    {
        //TestSpawn();
        Spawn(GetRandomPositionAboveScreen());
    }

    private void TestSpawn()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position += new Vector3(0, 0, 10);

        Spawn(position);
    }

    private void Spawn(Vector3 position)
    {
        if (!SpawnTimer())
            return;

        GameObject asteroid = new GameObject("Asteroid");
        asteroid.transform.position = position;

        int randomVerticesCount = UnityEngine.Random.Range(_verticesCount / 2, _verticesCount * 2);
        float randomSize = UnityEngine.Random.Range(_size / 2, _size * 2);

        LineRenderer lr = asteroid.AddComponent<LineRenderer>();
        lr.useWorldSpace = false;
        lr.loop = true;
        lr.positionCount = randomVerticesCount;
        lr.widthMultiplier = _borderSize;
        lr.numCornerVertices = 0;
        lr.numCapVertices = 0;
        lr.material = _asteroidBorder;

        Asteroid a = asteroid.AddComponent<Asteroid>();
        a.Speed = UnityEngine.Random.Range(_speed / 2, _speed * 2);
        a.Size = randomSize;

        for (int i = 0; i < randomVerticesCount; i++)
        {
            float rnd = UnityEngine.Random.Range(1.0f, 2.0f);
            var rad = Mathf.Deg2Rad * (i * 360f / randomVerticesCount);
            lr.SetPosition(i, new Vector3(Mathf.Sin(rad) * randomSize * rnd, Mathf.Cos(rad) * randomSize * rnd, 0));
        }

        GenerateMesh(asteroid);
    }

    private void GenerateMesh(GameObject asteroid)
    {
        Vector3[] vertices = new Vector3[asteroid.GetComponent<LineRenderer>().positionCount];

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = asteroid.GetComponent<LineRenderer>().GetPosition(i);
        }

        Triangulator triangulator = new Triangulator(vertices);
        int[] indices = triangulator.Triangulate();

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = indices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        MeshRenderer meshRenderer = asteroid.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = _asteroidFill;

        MeshFilter meshFilter = asteroid.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        PolygonCollider2D polygonCollider2D = asteroid.AddComponent<PolygonCollider2D>();
        Vector3[] positions = new Vector3[asteroid.GetComponent<LineRenderer>().positionCount];
        asteroid.GetComponent<LineRenderer>().GetPositions(positions);
        polygonCollider2D.points = Array.ConvertAll(positions, v => (Vector2)v);

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
