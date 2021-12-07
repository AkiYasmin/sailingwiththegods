using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CrewDialogManager : MonoBehaviour
{
<<<<<<< HEAD
	public float maxMeter = 100f;
	public float currentMeter;
=======
	public int maxMeter = 100;
	public int currentMeter;
>>>>>>> ddd2810e056a4320bd5fdb8bcb8c5205962f453e
	public MeterBar meterBar;

	public DialogueRunner diaglogRunner;
	public GameObject diaglogScreen;
	public AudioSource testsound;
<<<<<<< HEAD

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
=======
	void Start()
    {
		currentMeter = 50;
		meterBar.SetMeter(currentMeter);
		//diaglogRunner.AddCommandHandler("end_dialog", TurnOffScene);
		diaglogRunner.AddCommandHandler("increase", IncreaseMorale);
		diaglogRunner.AddCommandHandler("decrease", DecreaseMorale);

	}

	public void TurnOffScene(string [] parameter)
>>>>>>> ddd2810e056a4320bd5fdb8bcb8c5205962f453e
	{
		//diaglogScreen.SetActive(false);
		testsound.Play();
		Debug.Log("PLAYSOUND");
	}

<<<<<<< HEAD
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
=======
	public void IncreaseMorale(string[] parameter) 
	{
		currentMeter += 10;
		meterBar.SetMeter(currentMeter);
		Debug.Log("Increase");
	}
	public void DecreaseMorale(string[] parameter) 
	{
		currentMeter -= 10;
>>>>>>> ddd2810e056a4320bd5fdb8bcb8c5205962f453e
		meterBar.SetMeter(currentMeter);
		Debug.Log("Decrease");
	}

	// Update is called once per frame
	void Update()
    {
		
	}
<<<<<<< HEAD

	
=======
>>>>>>> ddd2810e056a4320bd5fdb8bcb8c5205962f453e
}
