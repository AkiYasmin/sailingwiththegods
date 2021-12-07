using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
	public bool isActive;
	public CrewDialogManager Manager;
	public MeterBar meterBar;
	

	public string title;
	public string descritpion;
	public int moraleReward;
	public int goldReward;

	public QuestGoal goal;

	public List<Quest> questList = new List<Quest>();


	public Quest(string qTitle,string qDescrption,int morale, int gold)
    {
		title = qTitle;
		descritpion = qDescrption;
		moraleReward = morale;
		goldReward = gold;
		
    }

	public void Complete()
	{
		//goal.StatueAdded();
		isActive = false;
		//Manager.currentMeter += moraleReward;
		//change to make current meter = the actual meter at that moment and then make a new meter to add. 
		Manager.currentMeter = moraleReward + Manager.currentMeter;
		meterBar.SetMeter(Manager.currentMeter);
		Debug.Log(Manager.currentMeter + " Is how much the meter went up.");
		Debug.Log(title + " was completed!");

	}
}
