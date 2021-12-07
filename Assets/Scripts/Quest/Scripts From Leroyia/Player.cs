using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Quest quest;
	public CrewDialogManager Manager;
	public int morale = 40;
	public int gold = 1000;
	public List<Quest> Quests { get; set; }


	public void SetUp()
	{
		
		morale += 20;
		gold += 10;
		

		if (quest.isActive)
		{
			Debug.Log("This Quest is active");
			//quest.goal.StatueAdded();
			if (quest.goal.isDone())
			{
				//morale += quest.moraleReward;//adding morale that the player has
				gold += quest.goldReward;
				quest.Complete();
			
			}
		}

	}
}
