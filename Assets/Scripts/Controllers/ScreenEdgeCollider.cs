using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScreenEdgeCollider : MonoBehaviour
{

    public List<EdgeCollider2D> _edges;

    void Start()
    {
        _edges = new List<EdgeCollider2D>();
        for (int i = 0; i < 3; i++)
        {
            gameObject.AddComponent<EdgeCollider2D>();
        }
        UpdateColliders();
    }

    void Update()
    {
        UpdateColliders();
    }

    void UpdateColliders()
    {

        Vector2 delta = Camera.main.transform.position - transform.position;
        List<EdgeCollider2D> edgeColliders = GetComponents<EdgeCollider2D>().ToList();

        edgeColliders[0].points = new Vector2[] { delta + GetWorldViewPort(new Vector2(0, 0)), delta + GetWorldViewPort(new Vector2(0, 1)) };
        edgeColliders[1].points = new Vector2[] { delta + GetWorldViewPort(new Vector2(0, 1)), delta + GetWorldViewPort(new Vector2(1, 1)) };
        edgeColliders[2].points = new Vector2[] { delta + GetWorldViewPort(new Vector2(1, 1)), delta + GetWorldViewPort(new Vector2(1, 0)) };
        //edgeColliders[3].points = new Vector2[] { delta + GetWorldViewPort(new Vector2(1, 0)), delta + GetWorldViewPort(new Vector2(0, 0)) };
        _edges.Clear();
        _edges = edgeColliders;
    }

    Vector2 GetWorldViewPort(Vector2 normalizedPos)
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(normalizedPos.x, normalizedPos.y, Camera.main.nearClipPlane));
    }

}
