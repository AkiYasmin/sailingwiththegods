using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class QuestGoal 
{
	//if quest.city has a statue then give the qust.moraleReward and quest.goldReward
	//if there's a amount of statues/items needed
	//change needed amount to statue amount and attach to statue 



	public int neededAmount = 3;
	public int currentAmount = 0;
	public Quest quest;
	public Player player;
	public ShrineOptionModel Shrine;
	public QuestGiver giver;




	public bool isDone()
	{
		if (currentAmount >= neededAmount)
		{
			return true;
		}
		return false;
	}

	public void Update()
	{
		//StatueAdded();
	}

	public void StatueAdded()
	{
		Debug.Log("The Is Buy is set to:" + Shrine.IsBuy);

		//checking if the player has click the buttons to buy stuff
		if (Shrine.IsBuy== true)
		{
			Debug.Log("The player has bought a statue and complete the quest");
			giver.OpenCompMenu();
			//add a complete screen for when the quest is done. 
			if (quest.isActive)//checking id the quest is active 
			{
				Debug.Log("The quest is done");//doesnt work 
			}

		}
	}
}


