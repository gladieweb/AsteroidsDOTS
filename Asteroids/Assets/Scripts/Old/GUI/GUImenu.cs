using UnityEngine;
using System.Collections;

public class GuImenu : MonoBehaviour
{

    public Vector3 position;
    public Vector3 size;

    private Rect _r = new Rect(0, 0, 100, 50);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    /*void OnGUI ()
    {

        r.x = 215;
        r.y = 110;
        r.width = size.x;
        r.height = size.y; 

        if(GUI.Button(r,"Play"))
        {
            Application.LoadLevel("Scene1");
        }

        r.x = 215;
        r.y = 150;
        r.width = size.x;
        r.height = size.y; 

        if (GUI.Button(r,"Credits"))
        {
            Application.LoadLevel("Scene2");
        }

        r.x = position.x;
        r.y = position.y;
        r.width = size.x;
        r.height = size.y;

        GUI.Box(r, "Menu");
	}*/
}
