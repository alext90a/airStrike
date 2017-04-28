using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Respawnable : NetworkBehaviour
{
    [SerializeField]
    GameObject mVisualObject = null;

    protected RespawnableManager mManager;

    //[SyncVar(hook = "OnChangeVisible")]
    [SyncVar]
    bool mIsVisible = false;



    public virtual void activate(Vector3 startPosition, RespawnableManager ownerManager)
    {
        mIsVisible = true;
        //gameObject.SetActive(true);
        enabled = mIsVisible;
        gameObject.transform.position = startPosition;
        mManager = ownerManager;
        RpcChangeVisible(true, startPosition);
        mVisualObject.SetActive(true);
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
        RpcChangeVisible(false, transform.position);
        mVisualObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if(!isServer)
        {
            return;
        }
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

    [ClientRpc]
    public void RpcChangeVisible(bool isVisible, Vector3 startPosition)
    {
        transform.position = startPosition;
        enabled = isVisible;
        mVisualObject.SetActive(isVisible);
    }
}
