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
    public Text text;
    //GameObject CardObj;
    public Canvas Canvas;
    //public RectTransform TrueCardObj, CardObj;
	public bool Ins;
	GameObject CardObjRes;
	GameObject CardObj;
	GameObject p1Folder, p2Folder, p3Folder, p4Folder;

	int[] CardBox = new int[52];

	private void Awake()
	{
        
	}
	// Use this for initialization
	void Start()
    {
        
        //Load();
        FirstPlayer = Random.Range(1, 5);
        CardListCount = CardList.Count;
        text.text = "先行はP" + FirstPlayer + "だよ！";

		CardObjRes = (GameObject)Resources.Load("CardObj");

		p1Folder = GameObject.Find("1PCARD").gameObject;
		p2Folder = GameObject.Find("2PCARD").gameObject;
		p3Folder = GameObject.Find("3PCARD").gameObject;
		p4Folder = GameObject.Find("4PCARD").gameObject;

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

        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
            Load();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Clear();
        }

        if (Input.GetKey(KeyCode.R))
        {
            CardList.Shuffle();
        }

        if(Ins == false)
        {
            InstantiateCard();
            Ins = true;
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

    public void Clear()
    {
        CardList.Clear();
    }

    public void InstantiateCard()
    {
		int playerCount = 0;

		for (int i = 0; i < CardListCount; i++)
		{
			//CardObj = Instantiate(Resources.Load("Card") as GameObject, transform.position, Quaternion.identity);
			CardObj = Instantiate(CardObjRes, transform.position, Quaternion.identity);
			CardObj.name = "Card" + i;
			CardObj.transform.parent = Canvas.transform;
			CardObj.transform.localScale = CardObjRes.transform.localScale;
			//CardObj.GetComponent<RectTransform>().offsetMin= new Vector2(374.7f, 19.25f);
			//CardObj.GetComponent<RectTransform>().offsetMax = new Vector2(374.7f, 345.25f);
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
}
