using UnityEngine;
using System.Collections.Generic;

public struct Prefab
{
	public GameObject prefab;
	public float spawnProb;
};

public abstract class Spawner : MonoBehaviour {
	public GameObject[] prefabs;
    public float[] prefabProb;
    int count = 0;
    Dictionary<string, GameObject> spawned = new Dictionary<string, GameObject>();

	public virtual GameObject spawn(int i){
        GameObject thisPrefab = prefabs[i];
        string prefabName = thisPrefab.name;
        float spawnprob = prefabProb[i];
        GameObject spawngo = null;
        float floatroll = Random.Range(0f, 1f);
        if (floatroll < spawnprob)
        {
            thisPrefab.name = prefabName + count.ToString();
            spawngo = GameObjUtil.Instantiate(thisPrefab, this.transform.position);
        }
        if(spawngo != null){
            if (!spawned.ContainsKey(spawngo.name))
            {
                spawned.Add(spawngo.name, spawngo);
                count++;
            }
        }
        thisPrefab.name = prefabName;
        return spawngo;
	}

	public GameObject spawnOnlyOne(int i){
        GameObject thisPrefab = prefabs[i];
        if(!spawned.ContainsKey(thisPrefab.name + "(Clone)")){
            return spawn(i);
        }
        return null;
	}

    public virtual bool despawn(string objstr){
        Debug.Log(objstr);
        if(spawned.ContainsKey(objstr)){
            if(spawned[objstr] != null){
                GameObjUtil.Destroy(spawned[objstr]);
            }
            spawned.Remove(objstr);
            count --;
            return true;
        }
        return false;
    }

	public virtual void despawnAll(){
        foreach(string s in spawned.Keys){
            if(spawned[s] != null){
                GameObjUtil.Destroy(spawned[s]);
            }
        }
        spawned.Clear();
        count = 0;
	}
}
