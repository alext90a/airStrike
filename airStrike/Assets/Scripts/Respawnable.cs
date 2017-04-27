using UnityEngine;
using System.Collections;

public class Respawnable : MonoBehaviour
{
    protected RespawnableManager mManager;

    public virtual void activate(Vector3 startPosition, RespawnableManager ownerManager)
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

    protected virtual void Update()
    {
        Vector3 curPostion = transform.position;
        if (curPostion.x < GameConstants.kLeftBorder || curPostion.z > GameConstants.kRightBorder
            || curPostion.z < GameConstants.kBottomBorder || curPostion.z > GameConstants.kTopBorder)
        {
            deactivate();
        }
    }
}
