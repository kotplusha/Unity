using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameController{
	void damagePlayer ();
	void killPlayer();
	void respawnPlayer();
}

public interface IHealthManager{
	void reset ();
	void addOne ();
	void damageOne ();
	int getHealth();
}