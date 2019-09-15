using UnityEngine;
using System.Collections.Generic;

public class ObjPool : MonoBehaviour {
	public RecycleGameObj prefab;
	private List<RecycleGameObj> poolInstances = new List<RecycleGameObj> ();

	private RecycleGameObj CreateInstance(Vector3 pos){
		var clone = GameObject.Instantiate (prefab);
		clone.transform.position = pos;
		clone.transform.parent = transform;
		poolInstances.Add (clone);
		return clone;
	}

	public RecycleGameObj NextObject(Vector3 pos){
		RecycleGameObj instance = null;
		foreach (var go in poolInstances) {
			//if (go.gameObject == null)
			//	return instance;
			if (!(go.gameObject.activeSelf)) {
				instance = go;
				instance.transform.position = pos;
			}
		}
		if(instance == null)
			instance = CreateInstance (pos);
		instance.Restart ();
		return instance;
	}
}
