using UnityEngine;
using System.Collections;

public class Enemy : Respawnable {

    [SerializeField]
    Health mHealth = null;

    Vector3 mCurSpeed = new Vector3(0f, 0f, -1f);

	// Use this for initialization
	void Start () {
        mHealth.setDeathFunc(onZeroHealth);
        mHealth.setCurrentHealth(GameConstants.kEnemyStartHealth);
	}
	
	// Update is called once per frame
	protected override void Update () {

        transform.position += mCurSpeed * Time.deltaTime;

        //base.Update();
	
	}

    void onZeroHealth()
    {
        deactivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameConstants.kPlayerTag))
        {
            Health health = other.GetComponent<Health>();
            health.decreaseHealth(GameConstants.kEnemyDamage);
            deactivate();
        }
    }
}
