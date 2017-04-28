using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class RespawnableManager : NetworkBehaviour {

    [SerializeField]
    GameObject mPrefabObj = null;

    LinkedList<Respawnable> mObjectStore = new LinkedList<Respawnable>();
    HashSet<Respawnable> mActiveObjects = new HashSet<Respawnable>();
    private void Awake()
    {
        
    }

    public Respawnable getNext()
    {
        if(mObjectStore.Count == 0)
        {
            Debug.LogError("Not enough objects in manager: " + name);
            cloningPrefab();
        }
        Respawnable nextObj = mObjectStore.First.Value;
        mObjectStore.RemoveFirst();
        mActiveObjects.Add(nextObj);
        return nextObj;
    }

    public void setToStore(Respawnable obj)
    {
        mActiveObjects.Remove(obj);
        mObjectStore.AddLast(obj);
    }

    void cloningPrefab()
    {
        for (int i = 0; i < GameConstants.kObjAmount; ++i)
        {
            GameObject gameObj = GameObject.Instantiate(mPrefabObj) as GameObject;
            mObjectStore.AddLast(gameObj.GetComponent<Respawnable>());            
            NetworkServer.Spawn(gameObj);
        }
    }

    public override void OnStartServer()
    {
        cloningPrefab();
    }



    public override void OnStartClient()
    {
        if(isServer)
        {
            Debug.Log("player connected");
        }
    }
}
