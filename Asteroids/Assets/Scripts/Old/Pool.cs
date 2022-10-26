using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;


public class Pool : MonoBehaviour {
	[FormerlySerializedAs("Types")] public GameObject[] types;
	[FormerlySerializedAs("Count")] public int[] count;
	
	//private static Pool instance = null;
	
	private static GameObject[][] _objects;
	private static int[] _id;
	// Use this for initialization
	void Awake () 
	{
		_objects = new GameObject[types.Length] [];
		_id = new int[types.Length];
		
		for(int i = 0; i < types.Length; i++)
		{
			_id[i] = 0;
			
			_objects[i]=new GameObject[count[i]];
			
			GameObject go = types[i];
			
			for(int j=0; j < count[i]; j++)
			{
				_objects[i][j]=(GameObject)GameObject.Instantiate((Object)go);
				_objects[i][j].active=false;
				_objects[i][j].GetComponent<Renderer>().enabled=false;
			}
		}
		
	}
	
	
	
	public static GameObject Create(int type)
	{
		if(_id[type] < _objects[type].Length)
		{
			GameObject go = _objects[type][_id[type]];
			
			_id[type]++;
			
			go.active=true;
			go.GetComponent<Renderer>().enabled=true;
			
			return go;
		}
		
		Debug.LogError("Not enough objects of type: " + type);
		
		return null;
	}
	
	public static void Recycle(GameObject go, int type)
	{
		_id[type]--;
		Debug.Log(_id[type]);
		_objects[type] [_id[type]]=go;
		go.active=false;
		go.GetComponent<Renderer>().enabled=false;
	}
	
	
}
