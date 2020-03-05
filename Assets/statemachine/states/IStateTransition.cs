using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateTransition
{
	IEnumerable Exit();

	IEnumerable Enter();
}
