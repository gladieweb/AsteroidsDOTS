using UnityEngine;
using System.Collections;

public class GuIintro : MonoBehaviour
{

    public Vector3 positionI;
    public Vector3 sizeI;
    int _cont = 0;
    private Rect _r = new Rect(0, 0, 100, 50);
    // Use this for initialization
    void Start()
    {
        _cont = 0;

    }

    // Update is called once per frame
    /*void OnGUI()
    {
        cont++;

        if (cont==350)
        {
            Application.LoadLevel("Menu");
        }
        r.x = positionI.x;
        r.y = positionI.y;
        r.width = sizeI.x;
        r.height = sizeI.y;

        GUI.Box(r, "CHRIS-SOFTWARE");

        r.x = 215;
        r.y = 100;
        r.width = sizeI.x;
        r.height = sizeI.y;

        GUI.Box(r, "PRESENTS: ASTERROIDS");
    }*/
}
