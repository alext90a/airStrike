using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    int mDamage = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
        }
    }
}
