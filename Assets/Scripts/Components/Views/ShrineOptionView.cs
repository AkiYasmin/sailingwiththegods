using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShrineOptionModel : Model
{
	GameVars GameVars => Globals.GameVars;

	public string Name;
	public int Cost;
	public int CloutGain;
	public string BenefitHint;
	public bool IsBuy = false;
	//public QuestGoal goal;
	public QuestGiver giver;
	public GameObject something;
	public static int numOfButton = 0;



	public ShrineOptionModel(string name, int cost, int cloutGain, string benefitHint)
	{
		Name = name;
		Cost = cost;
		CloutGain = cloutGain;
		BenefitHint = benefitHint;
	}
		public void Start()
    {
		giver= something.GetComponent<QuestGiver>();
	}

	public void Buy()
	{

		if (GameVars.playerShipVariables.ship.currency > Cost)
		{
			GameVars.playerShipVariables.ship.currency -= Cost;
			GameVars.ShowANotificationMessage("You built a " + Name + " for " + GameVars.currentSettlement.name + "! " + BenefitHint);
			GameVars.AdjustPlayerClout(1);
			GameVars.playerShipVariables.ship.builtMonuments += GameVars.currentSettlement.name + " -- " + Name + "\n";
			IsBuy = true;//checks when something is bought
			numOfButton = 1;
		
			IsBought();
		}
		else
		{
			GameVars.ShowANotificationMessage("You don't have enough money to build a " + Name + " for " + GameVars.currentSettlement.name);
		}

	}
	public bool IsBought()
	{
		if(IsBuy== true)
        {
			Debug.Log(IsBuy);
			//giver.OpenQuestMenu();
			return true;
		}
		return false;
	}

	
	

}





public class ShrineOptionView : ViewBehaviour<ShrineOptionModel>
{
	[SerializeField] StringView Name = null;
	[SerializeField] StringView BenefitHint = null;
	[SerializeField] ButtonView Buy = null;
	

	public override void Bind(ShrineOptionModel model)
	{
		base.Bind(model);

		Name.Bind(ValueModel.New(model.Name));
		BenefitHint.Bind(ValueModel.New(model.BenefitHint));
		Buy.Bind(ValueModel.New(new ButtonViewModel
		{
			Label = model.Cost + " dr",
			OnClick = model.Buy
		
		}));
		
	}
	
}
