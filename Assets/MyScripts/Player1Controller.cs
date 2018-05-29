using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

	//float inputHorizontal, inputVertical;
	public GameObject[] MyCards;

	public GameObject[] p1CardPos;
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
		//		MyCards = GameObject.FindGameObjectsWithTag("1PCARDObj");
		//		if (MyCards.Length == 0) return;
		//MyCards.Add(GameObject.FindGameObjectWithTag("1PCARDObj"));

		//inputHorizontal = Input.GetAxis("Horizontal");
		//inputVertical = Input.GetAxis("Vertical");

		if(GameActiveMode < 4)
		switch (GameActiveMode)
		{
			case 0: //Select
				MyCards = GameObject.FindGameObjectsWithTag("1PCARDObj");
				if (MyCards.Length == 0) break;

				for (int i = 0; i < MyCards.Length; i++)
				{
					//PosCount++;
					if (MyCards[i] != null)
						MyCards[i].transform.position = p1CardPos[i].transform.position;
				}


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
						CManager.P1CardCount -= 1;
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
						MyCards[i].transform.position = p1CardPos[i].transform.position;
				}

				GameActiveMode++;
				break;
		}

		if(GameActiveMode == 4)
		switch(GameMode)
		{
			case 0:
				if (Input.GetKeyDown(KeyCode.D))
                {

                    if (Count < MyCards.Length)
                    {
                        Count += 1;
                    }
                    if (Count == MyCards.Length)
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
                        Count = MyCards.Length - 1;
                    }

                }

                //PosInit
                for (int i = 0; i < MyCards.Length; ++i)
                {
                    MyCards[i].transform.position = p1CardPos[i].transform.position;
                    MyCards[i].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
                }
                //Select
                MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
                MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
				break;

			case 1:
				
					break;
		}
  
#if DEB
		if (CManager.Ins == true)
		{
			if(Set1 ==true && Set2 == true)
			{
				if(CountSet1 == CountSet2)
				{
					if(Set1Naiyou != Set2Naiyou)
					{
						List<GameObject> _list = new List<GameObject>(MyCards); 


						_list.RemoveAt(MyCards1Number);
						_list.RemoveAt(MyCards2Number);
						Destroy(MyCards[MyCards1Number]);
                        Destroy(MyCards[MyCards2Number]);

						MyCards = _list.ToArray(); 
						CManager.P1CardCount -= 2;

						Set1 = false;
						Set2 = false;
					}
				}
			}

			if (Input.GetKeyDown(KeyCode.D))
			{
               
				if (Count < MyCards.Length)
				{
					Count += 1;
				}
				if (Count == MyCards.Length)
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
					Count = MyCards.Length-1;
                }

            }

            //PosInit
			for (int i = 0; i < MyCards.Length; ++i) {
				MyCards[i].transform.position = p1CardPos[i].transform.position;
				MyCards[i].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
			}
            //Select
			MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);

			/*			switch (Count)
			{
				case 0:
					MyCards[Count].transform.position = new Vector3(MyCards[0].transform.position.x, 75, MyCards[0].transform.position.z);
					MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);

					MyCards[12].transform.position = p1CardPos[12].transform.position;
					MyCards[12].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
					MyCards[Count + 1].transform.position = p1CardPos[Count + 1].transform.position;
                    MyCards[Count + 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

					if(Input.GetKeyDown(KeyCode.LeftShift))
					{
						Debug.Log("Click");
						if (Set1 == true && Set2 == false)
						{
							if (CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Set == false)
							{
								CountSet2 = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].CardNumber;
								Set2Naiyou = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Naiyou;
								MyCards2Number = Count;
								Set2 = true;
							}
							else if(CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Set == true)
							{
								CManager.text.text = "もう選択済みだよ！！";
							}
						}

						if (Set1 == false)
						{
							CountSet1 = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].CardNumber;
							Set1Naiyou = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Naiyou;
							MyCards1Number = Count;
							CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Set = true;
						}
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

					if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        Debug.Log("Click");
                        if (Set1 == true && Set2 == false)
                        {
                            if (CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Set == false)
                            {
                                CountSet2 = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].CardNumber;
                                Set2Naiyou = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Naiyou;
                                MyCards2Number = Count;
                                Set2 = true;
                            }
                            else if (CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Set == true)
                            {
                                CManager.text.text = "もう選択済みだよ！！";
                            }
                        }

		/*      for (int i = 0; i < 13; i++)
        {
            //PosCount++;
            if (MyCards[i] != null)
                MyCards[i].transform.position = p1CardPos[i].transform.position;

        }*/
	/*      for (int i = 0; i < 13; i++)
        {
            //PosCount++;
            if (MyCards[i] != null)
                MyCards[i].transform.position = p1CardPos[i].transform.position;

        }*/
                     if (Set1 == false)
                        {
                            CountSet1 = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].CardNumber;
                            Set1Naiyou = CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Naiyou;
                            MyCards1Number = Count;
                            CManager.CardList[MyCards[Count].GetComponent<CardText>().count].Set = true;
                        }
                        Set1 = true;
                    }
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
		/*      for (int i = 0; i < 13; i++)
        {
            //PosCount++;
            if (MyCards[i] != null)
                MyCards[i].transform.position = p1CardPos[i].transform.position;

        }*/

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
			}*/
		}
#endif

		if (end == true)
		{
			return;
		}

		if (CManager.Ins == false)
		{
			return;
		}

		/*		for (int i = 0; i < 13; i++)
		{
			//PosCount++;
			if (MyCards[i] != null)
				MyCards[i].transform.position = p1CardPos[i].transform.position;

		}*/


		end = true;
	}
}
