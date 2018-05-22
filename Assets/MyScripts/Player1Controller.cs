using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

	//float inputHorizontal, inputVertical;
	public GameObject[] MyCards;
	public GameObject[] p1CardPos;
	//float timer;
	bool end, Set1, Set2;
	public int Count = 0;
	int CountSet1, CountSet2;
	CardManager CManager;


	// Use this for initialization
	void Start()
	{
		CManager = GameObject.Find("CardManager").GetComponent<CardManager>();
	}

	// Update is called once per frame
	void Update()
	{
		MyCards = GameObject.FindGameObjectsWithTag("1PCARDObj");

		//inputHorizontal = Input.GetAxis("Horizontal");
		//inputVertical = Input.GetAxis("Vertical");
        
		if (CManager.Ins == true)
		{

			if (Input.GetKeyDown(KeyCode.D))
			{
               
				if (Count < 13)
				{
					Count += 1;
				}
				if (Count == 13)
				{
					Count = 0;
				}
                
			}
			if (Input.GetKeyDown(KeyCode.A))
            {
                
                if (Count > -1)
                {
                    Count -= 1;
                }
                if (Count == -1)
                {
                    Count = 12;
                }

            }

			switch (Count)
			{
				case 0:
					MyCards[Count].transform.position = new Vector3(MyCards[0].transform.position.x, 75, MyCards[0].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);

					MyCards[12].transform.position = p1CardPos[12].transform.position;
					MyCards[12].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					if(Input.GetKeyDown(KeyCode.KeypadEnter))
					{
						if (Set1 == true && Set2 == false) CountSet2 = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].CardNumber;

						if(Set1 == false)CountSet1 = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].CardNumber;

						Set1 = true;
					}

					break;

				case 1:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 2:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 3:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 4:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;


				case 5:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 6:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 7:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 8:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 9:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 10:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 11:
					MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
					MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;

				case 12:
					MyCards[0].transform.position = p1CardPos[0].transform.position;
					MyCards[0].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[11].transform.position = p1CardPos[11].transform.position;
					MyCards[11].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
					break;
			}
		}


		if (end == true)
		{
			return;
		}

		if (CManager.Ins == false)
		{
			return;
		}

		for (int i = 0; i < 13; i++)
		{
			//PosCount++;
			if (MyCards[i] != null)
				MyCards[i].transform.position = p1CardPos[i].transform.position;

		}


		end = true;
	}
}
