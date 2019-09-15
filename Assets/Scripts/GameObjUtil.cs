using UnityEngine;
using System.Collections.Generic;

public class GameObjUtil {

	private static Dictionary<RecycleGameObj, ObjPool> pools = new Dictionary<RecycleGameObj,ObjPool> ();

	public static GameObject Instantiate(GameObject prefab, Vector3 pos){
		GameObject instance = null;
		var recycledScript = prefab.GetComponent<RecycleGameObj> ();
		if (recycledScript != null) {
			var pool = GetObjPool (recycledScript);
			instance = pool.NextObject (pos).gameObject;
		} else {
			instance = GameObject.Instantiate (prefab);
			instance.transform.position = pos;
		}
		return instance;
	}

	public static void Destroy(GameObject gameObject){
		if(gameObject == null)
			return;
		var recycleGameObject = gameObject.GetComponent<RecycleGameObj> ();
		if (recycleGameObject != null) {
			recycleGameObject.Shutdown ();
		} else {
			GameObject.Destroy (gameObject);
		}
	}

	private static ObjPool GetObjPool(RecycleGameObj reference){
		ObjPool pool = null;
		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		} else{
			var poolContainer = new GameObject (reference.gameObject.name+"ObjectPool");
			pool = poolContainer.AddComponent<ObjPool> ();
			pool.prefab = reference;
			pools.Add (reference,pool);
		}

		return pool;
	}
}
