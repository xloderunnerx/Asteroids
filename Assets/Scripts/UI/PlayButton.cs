using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] List<GameObject> _hideOnPress;
    private bool _isHiding;
    [SerializeField] private float _hidingSpeed;

    void Start()
    {
        _isHiding = false;
        GetComponent<Button>().onClick.AddListener(Hide);
    }

    
    void Update()
    {
        Hiding();
    }

    private void Hide()
    {
        _isHiding = true;
        foreach (GameObject g in _hideOnPress)
        {
            if (g.GetComponent<Button>() != null)
                g.GetComponent<Button>().enabled = false;
        }
    }

    private void Hiding()
    {
        if (!_isHiding)
            return;

        foreach(GameObject g in _hideOnPress)
        {
            Color clr = g.GetComponent<CanvasRenderer>().GetColor();
            clr.a -= Time.deltaTime * _hidingSpeed;
            g.GetComponent<CanvasRenderer>().SetColor(clr);
            if(clr.a <= 0)
            {
                GameInit.GetInstance().Init();
                Destroy(transform.parent.gameObject);
            }
        }
        
    }
}
