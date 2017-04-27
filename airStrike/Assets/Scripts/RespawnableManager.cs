using UnityEngine;
using System.Collections.Generic;

public class RespawnableManager : MonoBehaviour {

    [SerializeField]
    GameObject mPrefabObj = null;

    LinkedList<Respawnable> mObjectStore = new LinkedList<Respawnable>();
    private void Awake()
    {
        cloningPrefab();
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
        return nextObj;
    }

    public void setToStore(Respawnable obj)
    {
        mObjectStore.AddLast(obj);
    }

    void cloningPrefab()
    {
        for (int i = 0; i < GameConstants.kObjAmount; ++i)
        {
            GameObject gameObj = GameObject.Instantiate(mPrefabObj, transform) as GameObject;
            mObjectStore.AddLast(gameObj.GetComponent<Respawnable>());
        }
    }

}
