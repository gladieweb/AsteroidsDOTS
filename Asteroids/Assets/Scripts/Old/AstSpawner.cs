using UnityEngine;
using System.Collections;

public class AstSpawner : MonoBehaviour {
	private Pool _pool;
	
	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < 5; i++)
		{
			Pool.Create(0);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
