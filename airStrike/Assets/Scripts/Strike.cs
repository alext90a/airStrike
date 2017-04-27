using UnityEngine;
using System.Collections;

public class Strike : Respawnable
{
    [SerializeField]
    ParticleSystem mParticleSystem;

    float mTimeSinceStart = 0f;
    float mDisplayTime = 0f;
	// Use this for initialization
	void Start ()
    {

        mDisplayTime = mParticleSystem.duration; 
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
        
        mTimeSinceStart += Time.deltaTime;
        if(mTimeSinceStart > mDisplayTime)
        {
            deactivate();
        }
        base.Update();
    }



    public override void activate(Vector3 startPosition, RespawnableManager ownerManager)
    {
        base.activate(startPosition, ownerManager);
        mTimeSinceStart = 0f;
    }
}
