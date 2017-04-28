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

    Collider mCollider;

    private void Awake()
    {
        mCollider = GetComponent<Collider>();
    }

    public virtual void activate(Vector3 startPosition, RespawnableManager ownerManager)
    {
        mIsVisible = true;
        gameObject.transform.position = startPosition;
        mManager = ownerManager;
        RpcChangeVisible(true, startPosition);
        showObject(true);
    }
    protected void deactivate()
    {
        Vector3 curPos = transform.position;
        curPos.z = 100;
        transform.position = curPos;
        mIsVisible = false;
        
        if(mManager != null)
        {
            mManager.setToStore(this);
        }
        RpcChangeVisible(false, transform.position);
        showObject(false);
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

    [ClientRpc]
    public void RpcChangeVisible(bool isVisible, Vector3 startPosition)
    {
        transform.position = startPosition;
        showObject(isVisible);
    }

    protected virtual void showObject(bool isVisible)
    {
        enabled = isVisible;
        if(mVisualObject != null)
        {
            mVisualObject.SetActive(isVisible);
        }
        if(mCollider != null)
        {
            mCollider.enabled = isVisible;
        }
        
    }
}
