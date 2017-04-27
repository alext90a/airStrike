using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EnemyManager : NetworkBehaviour
{

    [SerializeField]
    RespawnableManager mEnemyStore = null;

    float mTimeSinceLastLaunch = 0f;
    bool mIsServerStarted = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!mIsServerStarted)
        {
            return;
        }
        mTimeSinceLastLaunch += Time.deltaTime;
        if (mTimeSinceLastLaunch >= GameConstants.kEnemyAppearInterval)
        {
            mTimeSinceLastLaunch = 0f;
            Vector3 startPos = new Vector3();
            startPos.z = GameConstants.kTopBorder;
            startPos.x = Random.Range(GameConstants.kLeftBorder, GameConstants.kRightBorder);
            Enemy enemy = mEnemyStore.getNext() as Enemy;
            enemy.activate(startPos, mEnemyStore);
        }
    }

    public override void OnStartServer()
    {
        mIsServerStarted = true;
    }
}
