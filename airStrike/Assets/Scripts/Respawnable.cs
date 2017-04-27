using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Respawnable : NetworkBehaviour
{
    protected RespawnableManager mManager;

    [SyncVar(hook = "OnChangeVisible")]
    bool mIsVisible = false;

    public virtual void activate(Vector3 startPosition, RespawnableManager ownerManager)
    {
        mIsVisible = true;
        //gameObject.SetActive(true);
        enabled = mIsVisible;
        gameObject.transform.position = startPosition;
        mManager = ownerManager;
    }
    protected void deactivate()
    {
        Vector3 curPos = transform.position;
        curPos.z = 100;
        transform.position = curPos;
        mIsVisible = false;
        enabled = mIsVisible;
        //gameObject.SetActive(false);
        if(mManager != null)
        {
            mManager.setToStore(this);
        }
        
    }

    protected virtual void Update()
    {
        Vector3 curPostion = transform.position;
        if (curPostion.x < GameConstants.kLeftBorder || curPostion.z > GameConstants.kRightBorder
            || curPostion.z < GameConstants.kBottomBorder || curPostion.z > GameConstants.kTopBorder)
        {
            deactivate();
        }
    }

    
    void OnChangeVisible(bool isVisible)
    {
        mIsVisible = isVisible;
        //gameObject.SetActive(mIsVisible);
        enabled = mIsVisible;
    }
    
}
