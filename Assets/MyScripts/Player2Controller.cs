using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

	//float inputHorizontal, inputVertical;
	public GameObject[] MyCards;
	public GameObject[] p2CardPos;
	//float timer;
	bool end;
	public int Count = 0;
	public int CountSet1, CountSet2, MyCards1Number, MyCards2Number;
	public string Set1Naiyou, Set2Naiyou;
	CardManager CManager;

	int GameActiveMode = 0, GameMode = 0;
	bool[] DelCardFlag = new bool[20];

	// Use this for initialization
	void Start()
	{
		CManager = GameObject.Find("CardManager").GetComponent<CardManager>();

		for (int i = 0; i < DelCardFlag.Length; ++i)
		{
			DelCardFlag[i] = false;
		}
	}

	// Update is called once per frame
	void Update()
	{

		if (GameActiveMode < 4)
			switch (GameActiveMode)
			{
				case 0: //Select
					MyCards = GameObject.FindGameObjectsWithTag("2PCARDObj");
					if (MyCards.Length == 0) break;

					for (int i = 0; i < MyCards.Length; ++i)
					{
						if (DelCardFlag[i] == false)
						{
							CountSet1 = CManager.CardList[MyCards[i].GetComponent<CardText>().count].CardNumber;
							Set1Naiyou = CManager.CardList[MyCards[i].GetComponent<CardText>().count].Naiyou;

							for (int ii = i + 1; ii < MyCards.Length; ++ii)
							{
								CountSet2 = CManager.CardList[MyCards[ii].GetComponent<CardText>().count].CardNumber;
								Set2Naiyou = CManager.CardList[MyCards[ii].GetComponent<CardText>().count].Naiyou;

								if (CountSet1 == CountSet2 && Set1Naiyou != Set2Naiyou)
								{
									DelCardFlag[i] = true;
									DelCardFlag[ii] = true;
									break;
								}
							}
						}
					}

					for (int i = 0; i < MyCards.Length; ++i)
					{
						if (DelCardFlag[i])
						{
							MyCards[i].transform.position = new Vector3(MyCards[i].transform.position.x, 75, MyCards[i].transform.position.z);
							MyCards[i].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
						}
					}

					//NEXT
					GameActiveMode++;
					break;
				case 1: //Waitß
					if (Input.GetKeyDown(KeyCode.Space))
					{
						GameActiveMode++;
					}
					break;
				case 2: //del
					List<GameObject> _list = new List<GameObject>(MyCards);
					int max = MyCards.Length;

					for (int i = max - 1; i >= 0; --i)
					{
						if (DelCardFlag[i])
						{
							_list.RemoveAt(i);
							Destroy(MyCards[i]);
							CManager.P2CardCount -= 1;
						}
					}

					MyCards = _list.ToArray();

					GameActiveMode++;
					break;
				case 3: //POS
					for (int i = 0; i < MyCards.Length; i++)
					{
						//PosCount++;
						if (MyCards[i] != null)
							MyCards[i].transform.position = p2CardPos[i].transform.position;
					}

					GameActiveMode++;
					break;
			}
	}
}
