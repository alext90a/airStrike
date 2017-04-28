using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text mPlayerScoreText = null;
    [SerializeField]
    RespawnableManager mStrikeStore = null;
    [SerializeField]
    RespawnableManager mEnemyStore = null;

    protected static GameManager mInstance = null;

    public static GameManager getInstance()
    {
        return mInstance;
    }

    private void Awake()
    {
        mInstance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Text getPlayerScoreText()
    {
        return mPlayerScoreText;
    }

    public RespawnableManager getStrikeStore()
    {
        return mStrikeStore;
    }

    public RespawnableManager getEnemyManager()
    {
        return mEnemyStore;
    }
}
