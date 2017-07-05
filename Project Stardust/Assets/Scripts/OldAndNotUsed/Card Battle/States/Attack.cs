using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBattle
{
	[CreateAssetMenu(fileName = "Attack", menuName = "States/Attack", order = 1)]
	public class AttackState : TurnState
	{
		public override void EndTurnPressed() { Component.FindObjectOfType<GameManager>().NextState(); }
	}
}