using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour 
{
    public float speed = 100.0f;
    [FormerlySerializedAs("Type")] public int type = 1;
    [FormerlySerializedAs("Screenwidth")] public float screenwidth = 1024.0f;
    [FormerlySerializedAs("Screenheight")] public float screenheight = 768;
    Vector3 _position;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        _position = this.transform.position;
        _position += transform.up * speed * Time.deltaTime;

        if (_position.x < -screenwidth || _position.x > screenwidth || _position.y < -screenheight || _position.y > screenheight)
        {
            Pool.Recycle(this.gameObject, type);
        }

        this.transform.position = _position;
	
	}
}
