using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameController
{
	bool canClick ();
	void clicked (CardScript card);
	void init ();

}
