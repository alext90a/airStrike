using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    [SerializeField]
    RespawnableManager mSpawnManager = null;

	// Use this for initialization
	void Start () {
        mSpawnManager = GameManager.getInstance().getBulletStore();
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
        bullet.RpcSetVelocity(transform.forward * GameConstants.kBulletStartSpeed);
    }
}
