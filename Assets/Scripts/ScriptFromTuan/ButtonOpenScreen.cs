using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine.UI;
using Yarn.Unity;




public class ButtonOpenScreen : MonoBehaviour
{
	public GameObject diaglogScreen;
	GameVars GameVars;
	public bool useDebugDialog = false;
	public string[] debugDialogNode; //"Start_Debug";
	public string dialogNode; //= "Start_Crew";
	public SpriteRandom spriteRandom;
	public AudioSource audioSource;
	
	//int i;
	public void TurnOnDiaglog() 
	{
		diaglogScreen.SetActive(true);


		//foreach(string debugDialogNode in debugDialogNode) 
		//{
		//	int i = UnityEngine.Random.Range(0, 2);
		//}
		int i = UnityEngine.Random.Range(0, 4); //random the dialogue 


		diaglogScreen.GetComponent<DialogScreen>().StartCrewDialog(useDebugDialog ? debugDialogNode[i] : dialogNode, "port");
		spriteRandom.RandomSpriteFunction();

		
		//diaglogScreen.GetComponent<DialogScreen>().StartCrewDialog( useDebugDialog ? debugDialogNode []: dialogNode, "port"); 

	}

	//public int GetRandomNum() 
	//{
	//	return UnityEngine.Random.Range(0, 2);
	//}
	public void TurnOffDiaglog() 
	{
		diaglogScreen.SetActive(false);
		audioSource.Stop();
	}
	void Awake()
	{
		//int i = UnityEngine.Random.Range(0, 2);
	}

	


}
