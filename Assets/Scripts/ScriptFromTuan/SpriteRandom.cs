using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteRandom : MonoBehaviour
{
	//public Image[] image;
	public Sprite[] spriteMember;
	//public CrewMember crew;
    // Start is called before the first frame update
    void Start()
    {

		

	}

	public void RandomSpriteFunction() 
	{
		int i = Random.Range(0, spriteMember.Length);
		GetComponent<Image>().sprite = spriteMember[i];
		//crew.PortraitSprite();
	}

	// Update is called once per frame
	void Update()
    {
		
	}
}
