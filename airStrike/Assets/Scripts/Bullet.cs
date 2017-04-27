using UnityEngine;
using System.Collections;

public class Bullet : Respawnable {

    int mDamage = 1;

    Vector3 mCurVelocity = new Vector3();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += mCurVelocity * Time.deltaTime;

        Vector3 curPostion = transform.position;
        if(curPostion.x < GameConstants.kLeftBorder || curPostion.z > GameConstants.kRightBorder
            || curPostion.z < GameConstants.kBottomBorder || curPostion.z > GameConstants.kTopBorder)
        {
            deactivate();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameConstants.kPlayerTag) || other.CompareTag(GameConstants.kEnemyTag))
        {
            Health health = other.GetComponent<Health>();
            if(health != null)
            {
                health.addHealth(-mDamage);
            }
            deactivate();
        }
    }

    public void setVelocity(Vector3 velocity)
    {
        mCurVelocity = velocity;
    }
}
