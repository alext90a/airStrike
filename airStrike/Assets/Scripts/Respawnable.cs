using UnityEngine;
using System.Collections;

public class Respawnable : MonoBehaviour
{
    protected RespawnableManager mManager;

    public void activate(Vector3 startPosition, RespawnableManager ownerManager)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = startPosition;
        mManager = ownerManager;
    }
    protected void deactivate()
    {
        gameObject.SetActive(false);
        mManager.setToStore(this);
    }
}
