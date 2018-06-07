using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{

	public List<Card> CardList = new List<Card>();
	//Card card = new Card();
	public int FirstPlayer;
	int CardListCount;
	public Text text, text2;
	//GameObject CardObj;
	public Canvas Canvas;
	//public RectTransform TrueCardObj, CardObj;
	public bool Ins;
	GameObject CardObjRes;
	GameObject CardObj;
    public GameObject p1Folder, p2Folder, p3Folder, p4Folder;
	public GameObject[] P2Clone, P3Clone, P4Clone;
	public int P1CardCount = 13, P2CardCount = 13, P3CardCount = 13, P4CardCount = 13;
    public bool TurnEnd, GameEnd;
    public bool P1Turn, P2Turn, P3Turn, P4Turn, P1End, P2End, P3End, P4End;
    public Text P1Text, P2Text, P3Text, P4Text;

	int[] CardBox = new int[52];

	private void Awake()
	{

	}
	// Use this for initialization
	void Start()
	{
        FirstPlayer = Random.Range(1, 5);
        switch(FirstPlayer)
        {
            case 1:
                P1Turn = true;
                break;

            case 2:
                P2Turn = true;
                break;

            case 3:
                P3Turn = true;
                break;

            case 4:
                P4Turn = true;
                break;
        }

        if(P1CardCount == 0)
        {
            P1End = true;
        }
        if(P2CardCount == 0)
        {
            P2End = true;
        }
        if(P3CardCount == 0)
        {
            P3End = true;
        }
        if(P4CardCount == 0)
        {
            P4End = true;
        }
		//Load();
		
		CardListCount = CardList.Count;
		text.text = "先行はP" + FirstPlayer + "だよ！";
        text2.text = text.text;

		CardObjRes = (GameObject)Resources.Load("CardObj");

		p1Folder = GameObject.Find("1PCARD").gameObject;
		p2Folder = GameObject.Find("2PCARD").gameObject;
		p3Folder = GameObject.Find("3PCARD").gameObject;
		p4Folder = GameObject.Find("4PCARD").gameObject;
		//P2Clone = GameObject.FindGameObjectsWithTag("P2CloneCard");
		//P3Clone = GameObject.FindGameObjectsWithTag("P3CloneCard");
		//P4Clone = GameObject.FindGameObjectsWithTag("P4CloneCard");

		//
		for (int i = 0; i < CardListCount; ++i)
		{
			CardBox[i] = i;
		}
		//Shafull
		int a, b, c;
		for (int i = 0; i < 1000; ++i)
		{
			a = Random.Range(0, CardListCount);
			b = Random.Range(0, CardListCount);

			c = CardBox[b];
			CardBox[b] = CardBox[a];
			CardBox[a] = c;
		}
	}

    // Update is called once per frame
    void Update()
    {
        P1Text.text = P1CardCount.ToString();
        P2Text.text = P2CardCount.ToString();
        P3Text.text = P3CardCount.ToString();
        P4Text.text = P4CardCount.ToString();
        text2.text = text.text;

        if (GameEnd == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
                Load();
            }

            if (Ins == false)
            {
                InstantiateCard();
                Ins = true;
            }


            if (TurnEnd)
            {
                RefindAllCard();

                switch (FirstPlayer)
                {
                    case 1:

                        P1Turn = false;
                        if (P2End == false)
                        {
                            P2Turn = true;
                            FirstPlayer++;
                        }
                        else if (P2End == true && P3End == false)
                        {
                            P3Turn = true;
                            FirstPlayer = 3;

                        }
                        else if (P3End == true && P4End == false)
                        {
                            P4Turn = true;
                            FirstPlayer = 4;
                        }
                        else if (P4End == true && P1End == false)
                        {
                            GameEnd = true;
                        }
                        else if( P2End == true && P3End == true)
                        {
                            P4Turn = true;
                            FirstPlayer = 4;
                        }
                        else if(P2End == true && P3End == true && P4End == true)
                        {
                            GameEnd = true;
                        }

                        break;

                    case 2:

                        P2Turn = false;
                        if (P3End == false)
                        {
                            FirstPlayer++;
                            P3Turn = true;
                        }
                        else if (P3End == true && P4End == false)
                        {
                            P4Turn = true;
                            FirstPlayer = 4;
                        }
                        else if (P4End == true && P1End == false)
                        {
                            P1Turn = true;
                            FirstPlayer = 1;
                        }
                        else if (P1End == true && P2End == false)
                        {
                            GameEnd = true;
                        }
                        else if (P3End == true && P4End == true)
                        {
                            P1Turn = true;
                            FirstPlayer = 1;
                        }
                        else if (P1End == true && P3End == true && P4End == true)
                        {
                            GameEnd = true;
                        }

                        break;

                    case 3:

                        P3Turn = false;
                        if (P4End == false)
                        {
                            FirstPlayer++;
                            P4Turn = true;
                        }
                        else if (P4End == true && P1End == false)
                        {
                            P1Turn = true;
                            FirstPlayer = 1;
                        }
                        else if (P1End == true && P2End == false)
                        {
                            P2Turn = true;
                            FirstPlayer = 2;
                        }
                        else if (P2End == true && P3End == false)
                        {
                            GameEnd = true;
                        }
                        else if (P1End == true && P4End == true)
                        {
                            P2Turn = true;
                            FirstPlayer = 2;
                        }
                        else if (P1End == true && P2End == true && P4End == true)
                        {
                            GameEnd = true;
                        }

                        break;

                    case 4:

                        P4Turn = false;
                        if (P1End == false)
                        {
                            FirstPlayer = 1;
                            P1Turn = true;
                        }
                        else if (P1End == true && P2End == false)
                        {
                            P2Turn = true;
                            FirstPlayer = 2;
                        }
                        else if (P2End == true && P3End == false)
                        {
                            P3Turn = true;
                            FirstPlayer = 3;
                        }
                        else if (P3End == true && P4End == false)
                        {
                            GameEnd = true;
                        }
                        else if (P1End == true && P2End == true)
                        {
                            P3Turn = true;
                            FirstPlayer = 3;
                        }
                        else if (P1End == true && P2End == true && P3End == true)
                        {
                            GameEnd = true;
                        }


                        break;


                }

                text.text = "P" + FirstPlayer + "の番だよ！";
                text2.text = text.text;
                Debug.Log(FirstPlayer);
                TurnEnd = false;
            }
        }
    }

	public void Save()
	{
		PlayerPrefsUtility.SaveList<Card>("CardListSaveKey", CardList);
	}

	public void Load()
	{
		CardList = PlayerPrefsUtility.LoadList<Card>("CardListSaveKey");
	}

    public void InstantiateCard()
    {
		int playerCount = 0;

		for (int i = 0; i < CardListCount; i++)
		{
			
			CardObj = Instantiate(CardObjRes, transform.position, Quaternion.identity);
			CardObj.name = "Card" + i;
			CardObj.transform.parent = Canvas.transform;
			CardObj.transform.localScale = CardObjRes.transform.localScale;
			CardObj.transform.position = CardObjRes.transform.position;
			CardObj.GetComponent<CardText>().count = i;
		}

		for (int i = 0; i < CardListCount; i++)
		{

			CardObj = GameObject.Find("Card" + CardBox[i]);

			if (playerCount == 0)
			{
				CardObj.transform.parent = p1Folder.transform;
				//PosCount++;
				//if (PosCount < 13)
				//{
				//	CardObj.transform.position = p1CardPos[PosCount].transform.position;
				//}
                
			}
			else if (playerCount == 1)
			{
				CardObj.transform.parent = p2Folder.transform;
			}
			else if (playerCount == 2)
			{
				CardObj.transform.parent = p3Folder.transform;
			}
			else if (playerCount == 3)
			{
				CardObj.transform.parent = p4Folder.transform;
			}

			if (++playerCount >= 4)
			{
				playerCount = 0;
			}


		}
    }

	public void P2DeathCard()
	{
		P2Clone[P2CardCount].SetActive(false);
	}

    public void P2ActiveCard()
    {
        P2Clone[P2CardCount -1].SetActive(true);

    }

    public void P3DeathCard()
	{
		P3Clone[P3CardCount].SetActive(false);
	}

    public void P3ActiveCard()
    {
        P3Clone[P3CardCount -1].SetActive(true);
    }

    public void P4DeathCard()
	{
		P4Clone[P4CardCount].SetActive(false);
	}

    public void P4ActiveCard()
    {
        P4Clone[P4CardCount -1].SetActive(true);
    }

    public void RefindCard(int no)
    {
        if ( no == 1 ){
//            p1Folder = GameObject.Find("1PCARD").gameObject;
        } else if ( no == 2 ) {
            p2Folder.GetComponent<Player2Controller>().Refind();
            
        }
    }

    public void RefindAllCard()
    {
        p1Folder.GetComponent<Player1Controller>().Refind();
        p2Folder.GetComponent<Player2Controller>().Refind();
        p3Folder.GetComponent<Player3Controller>().Refind();
        p4Folder.GetComponent<Player4Controller>().Refind();
    }
}
