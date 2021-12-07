using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CrewDialogManager : MonoBehaviour
{
	public float maxMeter = 100f;
	public float currentMeter;
	public MeterBar meterBar;

	public DialogueRunner diaglogRunner;
	public GameObject diaglogScreen;
	public AudioSource testsound;

	//public script_player_controls playerControls;

	
	void Start()
    {
		currentMeter = 50f;
		meterBar.SetMeter(currentMeter);
		//diaglogRunner.AddCommandHandler("end_dialog", TurnOffScene);
		diaglogRunner.AddCommandHandler("increase", Increase10Morale);
		diaglogRunner.AddCommandHandler("decrease", Decrease10Morale);
		diaglogRunner.AddCommandHandler("decrease5", Decrease5Morale);
		diaglogRunner.AddCommandHandler("increase5", Increase5Morale);
		diaglogRunner.AddCommandHandler("playsound", TurnOnScreen);
		diaglogRunner.AddCommandHandler("stopsound", TurnOffMusic);

		//GetComponent<DialogueRunner>();

	}

	public void TurnOnScreen(string [] parameter)
	{
		//diaglogScreen.SetActive(false);
		testsound.Play();
		Debug.Log("PLAYSOUND");
	}

	public void TurnOffMusic(string [] parameter) 
	{
		testsound.Stop();
		Debug.Log("StopSound");
	}

	public void Increase10Morale(string[] parameter) 
	{
		currentMeter += 10f;
		meterBar.SetMeter(currentMeter);
		Debug.Log("Increase");
	}

	public void Increase5Morale(string[] parameter) {
		currentMeter += 5f;
		meterBar.SetMeter(currentMeter);
		Debug.Log("Increase");
	}

	public void Decrease10Morale(string[] parameter) 
	{
		currentMeter -= 10f;
		meterBar.SetMeter(currentMeter);
		Debug.Log("Decrease");
	}

	public void Decrease5Morale(string[] parameter) {
		currentMeter -= 5f;
		meterBar.SetMeter(currentMeter);
		Debug.Log("Decrease");
	}

	// Update is called once per frame
	void Update()
    {
		
	}

	
}
