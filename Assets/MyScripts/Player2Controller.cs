using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

	//float inputHorizontal, inputVertical;
	public GameObject[] MyCards;
	public GameObject[] p2CardPos;
	public GameObject CardParant;
	//float timer;
	bool end;
	public int Count = 0;
	CardManager CManager;


	// Use this for initialization
	void Start()
	{
		CManager = GameObject.Find("CardManager").GetComponent<CardManager>();
	}

	// Update is called once per frame
	void Update()
    {

        if (end == true)
        {
            return;
        }

        if (CManager.Ins == false)
        {
            return;
        }

		MyCards = GameObject.FindGameObjectsWithTag("2PCARDObj");

        for (int i = 0; i < 13; i++)
        {
			//PosCount++;
			if (MyCards[i] != null)
				MyCards[i].transform.position = p2CardPos[i].transform.position;

        }

		CardParant.transform.localScale = new Vector3(0.46f, 0.46f, 0.46f);

        end = true;
    }
}
