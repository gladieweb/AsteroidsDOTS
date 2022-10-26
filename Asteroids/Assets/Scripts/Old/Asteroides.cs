using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Asteroides : MonoBehaviour 
{
	public float speed=100.0f;
	public float rotationSpeed=100.0f;
	[FormerlySerializedAs("Screenwidth")] public float screenwidth = 1024.0f;
    [FormerlySerializedAs("Screenheight")] public float screenheight = 768;
	
	Vector3 _position;
	Vector3 _direction;
	Vector3 _positionInicial;
	// Use this for initialization
	void Start () 
	{
		_positionInicial.x=500;
		_positionInicial.y=-400;
		_position=new Vector3(Random.Range(-400,400), Random.Range(-400, 400), 0)*_positionInicial.x*_positionInicial.y;
		_direction=new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, 0);
		rotationSpeed=(Random.value*2- 1.0f) * rotationSpeed;
		
		 this.transform.position = _position;
		//Position = this.transform.position;
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.rotation *= Quaternion.AngleAxis(rotationSpeed *  Time.deltaTime, Vector3.up);
		this.transform.rotation *= Quaternion.AngleAxis(rotationSpeed *  Time.deltaTime, Vector3.forward);
		
		_position+=speed* _direction*Time.deltaTime;
       
        if (_position.x < -screenwidth / 2)
        {
            _position.x = screenwidth / 2;
        }
        if (_position.x > screenwidth / 2)
        {
            _position.x = -screenwidth / 2;
        }

        if (_position.y < -screenheight / 2)
        {
            _position.y = screenheight / 2;
        }
        if (_position.y > screenheight / 2)
        {
            _position.y = -screenheight / 2;
        }

        this.transform.position = _position;
	
	}
}
