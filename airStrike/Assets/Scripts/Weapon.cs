using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    [SerializeField]
    RespawnableManager mSpawnManager = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void launchBullet(Bullet.onTargetAcquired func)
    {
        Bullet bullet = mSpawnManager.getNext() as Bullet;
        bullet.activate(transform.position, mSpawnManager);
        bullet.setVelocity(transform.forward * GameConstants.kBulletStartSpeed);
        bullet.setTargetAcquiredFunc(func);
    }
}
