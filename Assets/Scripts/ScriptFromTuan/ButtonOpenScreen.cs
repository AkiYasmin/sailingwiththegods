using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine.UI;

public class ButtonOpenScreen : MonoBehaviour
{
	public GameObject diaglogScreen;
	GameVars GameVars;
	public bool useDebugDialog = false;
	public string debugDialogNode = "Start_Debug";
	public string dialogNode = "Start_Crew";
	public void TurnOnDiaglog() 
	{
		diaglogScreen.SetActive(true);
		diaglogScreen.GetComponent<DialogScreen>().StartCrewDialog( useDebugDialog ? debugDialogNode : dialogNode, "port"); 

	}
	public void TurnOffDiaglog() 
	{
		diaglogScreen.SetActive(false);
	}
}
