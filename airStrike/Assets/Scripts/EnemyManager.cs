using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    RespawnableManager mEnemyStore = null;

    float mTimeSinceLastLaunch = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        mTimeSinceLastLaunch += Time.deltaTime;
        if(mTimeSinceLastLaunch >= GameConstants.kEnemyAppearInterval)
        {
            mTimeSinceLastLaunch = 0f;
            Vector3 startPos = new Vector3();
            startPos.z = GameConstants.kTopBorder;
            startPos.x = Random.Range(GameConstants.kLeftBorder, GameConstants.kRightBorder);
            Enemy enemy = mEnemyStore.getNext() as Enemy;
            enemy.activate(startPos, mEnemyStore);
        }
	}


}
