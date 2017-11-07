﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade
{
	int maxTick;
	int currentTick;
	public bool exploded = false;

    public Vector3 Position { get; protected set; }

    public GrenadeEvent OnChange = new GrenadeEvent();
    //public GrenadeEvent OnRemove = new GrenadeEvent();

    public Grenade (int mxT)
	{
		maxTick = mxT;
		currentTick = maxTick;
        TurnManager.Instance.RegisterGrenade(this);
	}

    public void SetPosition(Vector3 pos)
    {
        Position = pos;
        OnChange.Invoke(this);
    }

	public void ChangeTick(int tick)
	{
        //if (exploded)
         //   OnRemove.Invoke(this);
		currentTick += tick;
		Debug.LogFormat("ticking... {0}", currentTick);
		if(currentTick <= 0)
			Explode();
	}

	public void Explode()
	{
		exploded = true;
        OnChange.Invoke(this);
	}
}
