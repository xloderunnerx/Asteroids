using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    private static AsteroidGenerator _instance;

    public Material _asteroidBorder;
    public Material _asteroidFill;

    private void Awake()
    {
        _instance = this;
    }

    public static AsteroidGenerator GetInstance() => _instance;

    void Start()
    {
        
    }


    void Update()
    {
        TestSpawn();
    }

    void TestSpawn()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position += new Vector3(0, 0, 10);


        Generate(position, 8, 0.1f);
    }

    public void Generate(Vector3 position, int vertices, float size)
    {
        GameObject asteroid = new GameObject("Asteroid");
        asteroid.transform.position = position;
        LineRenderer lr = asteroid.AddComponent<LineRenderer>();
        lr.useWorldSpace = false;
        lr.loop = true;
        lr.positionCount = vertices;
        lr.widthMultiplier = 0.1f;
        lr.numCornerVertices = 0;
        lr.numCapVertices = 0;
        lr.material = _asteroidBorder;
        Asteroid a = asteroid.AddComponent<Asteroid>();


        for (int i = 0; i < vertices; i++)
        {
            float rnd = Random.Range(1.0f, 2.0f);
            var rad = Mathf.Deg2Rad * (i * 360f / vertices);
            lr.SetPosition(i, new Vector3(Mathf.Sin(rad) * size * rnd, Mathf.Cos(rad) * size * rnd, 0));
        }

        GenerateMesh(asteroid);
    }

    void GenerateMesh(GameObject asteroid)
    {
        Vector3[] vertices = new Vector3[asteroid.GetComponent<LineRenderer>().positionCount];

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = asteroid.GetComponent<LineRenderer>().GetPosition(i);
        }

        Triangulator tr = new Triangulator(vertices);
        int[] indices = tr.Triangulate();

        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        MeshRenderer mR = asteroid.AddComponent<MeshRenderer>();
        mR.sharedMaterial = _asteroidFill;
        MeshFilter mF= asteroid.AddComponent<MeshFilter>();
        mF.mesh = msh;
    }
}
