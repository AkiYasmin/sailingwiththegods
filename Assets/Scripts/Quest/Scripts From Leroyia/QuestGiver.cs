using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NaughtyAttributes;
using UnityEngine.UI;




public class QuestGiver : MonoBehaviour
{
	//inside edu
	public Quest quest;
	public List<Quest> questList = new List<Quest>();
	public Player player;
	private int  rnd;

	public QuestGoal goal;
	public script_player_controls controls;


	public GameObject questMenu;
	public Text titleText;
	public Text decriptionText;
	public Text moraleText;
	public Text goldText;

	public GameObject CompMenu;
	public Text CompDecriptionText;

	public int numOfCloses = 0;
	//public ShrineOptionModel Shrine;
	//public GameObject BuyShrine;


	void Awake()
    {//adding quest to the list
	 //quest.questList(UnityEngine.Random.Range(0, quest.questList.Count));//trying to use random to select the quest
		
		questList.Add(new Quest("Statue Mainia", "Add 3 statues to a city", 40, 300));//adding quest to the questList
		questList.Add(new Quest("Temple", "Add 1 temple to a city", 50, 400));
		questList.Add(new Quest(" Some item here", "Add a something in a city", 60, 500));
		questList.Add(new Quest("Bread Games", "Buy bread from the market", 20, 300));
		questList.Add(new Quest(" Water waiting for?", "Buy 4 bottle of water for the crew", 60, 500));
		rnd = Random.Range(0, questList.Count);//creating the random number for the quest in the list
		Debug.Log(rnd + " Is the random number");
		//Shrine = BuyShrine.GetComponent<ShrineOptionModel>();

		//Debug.Log("The days traveled is " + controls.numOfDaysTraveled);

	}

	void Update()
    {//controls.numOfDaysTraveled % 2 == 1 ||
		//Debug.Log("The days traveled is " + Globals.GameVars.playerShipVariables.ship.totalNumOfDaysTraveled);//add a && for even numbers
		// checking when the numbe of days traveled is even and if so the quest menu will appear
		if (Globals.GameVars.playerShipVariables.ship.totalNumOfDaysTraveled > 0.10 && quest.isActive == false && numOfCloses == 0)
        {
			OpenQuestMenu();


        }
		if(ShrineOptionModel.numOfButton == 1 && quest.isActive == true && numOfCloses==0)
        {
			
			OpenCompMenu();
        }
	
		//goal.StatueAdded();
	}
	public void OpenQuestMenu()
	{//sets the infomation in the list into quest menu

		questMenu.SetActive(true);
		titleText.text = questList[rnd].title;
		decriptionText.text = questList[rnd].descritpion;
		moraleText.text = questList[rnd].moraleReward.ToString();
		goldText.text = questList[rnd].goldReward.ToString();

		
	}

	public void OpenCompMenu()
    {
		CompMenu.SetActive(true);
		CompDecriptionText.text = questList[rnd].title + " has been completed.";
		//quest.isActive = false;

		Debug.Log("The quest is DONE!");
	}

	public void CloseMenu()
    {
		CompMenu.SetActive(false);
		quest.isActive = false;
		numOfCloses = 1;
		Debug.Log("CLOSE");
    }
	public void AcceptQuest()
	{
		CompMenu.SetActive(false);
		questMenu.SetActive(false);
		//numOfCloses = 0;
		quest.isActive = true;//setting isActive to true to check for complete
		player.quest = quest;//connecting quest in player to quest here(so player can see that quest is active
        if (quest.isActive)//checking to see if quest is active
        {
			Debug.Log("Quest is active!");
        }
		
	}

}
