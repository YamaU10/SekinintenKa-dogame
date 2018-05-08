using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    
	float inputHorizontal, inputVertical;
	public GameObject[] MyCards;
	GameObject[] p1CardPos;
	float timer;
	bool noChanage, end;
	int Count, PosCount;
    

	// Use this for initialization
	void Start()
	{
		p1CardPos = GameObject.FindGameObjectsWithTag("Player1CardPos");

	}

	// Update is called once per frame
	void Update()
	{
		MyCards = GameObject.FindGameObjectsWithTag("1PCARDObj");
		inputHorizontal = Input.GetAxis("Horizontal");
		inputVertical = Input.GetAxis("Vertical");

		if(inputHorizontal > 0.5f)
		{
			timer += Time.deltaTime;
			if (timer >= 0.5f)
			{
				Count += 1;
				timer = 0;
			}
		}

		switch(Count)
		{
			case 0:
				if (noChanage == true)
				{
					return;
				}
				MyCards[0].transform.position += new Vector3(0, 10, 0);
				noChanage = true;
				break;
		}

		if ( end == true)
		{
			return;
		}

		for (int i = 0; i < 13; i++)
        {
            MyCards[i].transform.position = p1CardPos[PosCount].transform.position;
            PosCount++;
        }
	}
}
