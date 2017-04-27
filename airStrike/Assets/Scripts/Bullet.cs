using UnityEngine;
using System.Collections;

public class Bullet : Respawnable {

    

    int mDamage = 1;

    Vector3 mCurVelocity = new Vector3();

    public delegate void onTargetAcquired();
    onTargetAcquired mTargetAcquiredFunc = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {

        transform.position += mCurVelocity * Time.deltaTime;
        base.Update();
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameConstants.kPlayerTag) || other.CompareTag(GameConstants.kEnemyTag))
        {
            Health health = other.GetComponent<Health>();
            if(health != null)
            {
                health.decreaseHealth(mDamage);
            }
            mTargetAcquiredFunc();
            deactivate();

            
        }
    }

    public void setVelocity(Vector3 velocity)
    {
        mCurVelocity = velocity;
    }

    public void setTargetAcquiredFunc(onTargetAcquired func)
    {
        mTargetAcquiredFunc = func;
    }
}
