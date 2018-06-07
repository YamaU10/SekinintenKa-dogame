using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Controller : MonoBehaviour {

	//float inputHorizontal, inputVertical;
    public GameObject[] MyCards;
	//public GameObject[] p3CardPos;
    //float timer;
    bool end;
    public int Count = 0;
    public int CountSet1, CountSet2, MyCards1Number, MyCards2Number;
    public string Set1Naiyou, Set2Naiyou;
    CardManager CManager;
    int QCount, RandomCard;

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
        if(CManager.GameEnd == false)
        if (CManager.P3End == false)
        {
            if (GameActiveMode < 4)
                switch (GameActiveMode)
                {
                    case 0: //Select
                        MyCards = GameObject.FindGameObjectsWithTag("3PCARDObj");
                        if (MyCards.Length == 0) break;

                        for (int i = 0; i < MyCards.Length; ++i)
                        {
                            if (DelCardFlag[i] == false)
                            {
                                CountSet1 = CManager.CardList[MyCards[i].GetComponent<CardText>().count].CardNumber;
                                Set1Naiyou = CManager.CardList[MyCards[i].GetComponent<CardText>().count].Naiyou;

                                for (int ii = i + 1; ii < MyCards.Length; ++ii)
                                {
                                    if (DelCardFlag[ii] == false)
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
                        }
                        //NEXT
                        GameActiveMode++;
                        break;
                    case 1: //Waitß
                        if (Input.GetButtonDown("ConB"))
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
                                CManager.P3CardCount -= 1;
                                CManager.P3DeathCard();
                            }
                        }

                        MyCards = _list.ToArray();

                        GameActiveMode++;
                        break;
                    case 3:
                        GameActiveMode++;
                        break;
                }

            if (CManager.P3Turn == true)
                if (GameActiveMode == 4)
                    switch (GameMode)
                    {
                        case 0:
                            for (int i = 0; i < MyCards.Length; ++i)
                            {
                                if (DelCardFlag[i] == false)
                                {
                                    CountSet1 = CManager.CardList[MyCards[i].GetComponent<CardText>().count].CardNumber;
                                    Set1Naiyou = CManager.CardList[MyCards[i].GetComponent<CardText>().count].Naiyou;

                                    for (int ii = i + 1; ii < MyCards.Length; ++ii)
                                    {
                                        if (DelCardFlag[ii] == false)
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
                            }
                            GameMode++;
                            break;

                        case 1:
                            int max = MyCards.Length;
                            List<GameObject> _list = new List<GameObject>(MyCards);
                            for (int i = max - 1; i >= 0; --i)
                            {
                                if (DelCardFlag[i])
                                {
                                    _list.RemoveAt(i);
                                    Destroy(MyCards[i]);
                                    CManager.P3CardCount -= 1;
                                    CManager.P3DeathCard();
                                }
                            }

                            MyCards = _list.ToArray();

                            GameMode++;
                            break;
                        case 2:
                            RandomCard = Random.Range(0, MyCards.Length);
                            QCount = Random.Range(2, 5);
                            GameMode++;
                            break;

                        case 3:

                            if (QCount == 2)
                            {
                                if (CManager.P1CardCount < 13 && CManager.P1CardCount > 0)
                                {
                                    MyCards[RandomCard].transform.parent = CManager.p1Folder.transform;
                                    MyCards[RandomCard].GetComponent<CardText>().CardImage.GetComponent<Image>().enabled = true;
                                    MyCards[RandomCard].GetComponent<CardText>().Naiyou.text = CManager.CardList[MyCards[RandomCard].GetComponent<CardText>().count].Naiyou;
                                    MyCards[RandomCard].GetComponent<CardText>().Number1.text = CManager.CardList[MyCards[RandomCard].GetComponent<CardText>().count].CardNumber.ToString();
                                    MyCards[RandomCard].GetComponent<CardText>().Number2.text = CManager.CardList[MyCards[RandomCard].GetComponent<CardText>().count].CardNumber.ToString();
                                    MyCards[RandomCard].GetComponent<CardText>().CardImage.GetComponent<Image>().sprite = null;

                                    CManager.P1CardCount++;
                                    CManager.P3CardCount--;
                                    //CManager.P1ActiveCard();

                                    _list = new List<GameObject>(MyCards);
                                    _list.RemoveAt(Count);

                                    MyCards = _list.ToArray();
                                    //NEXT
                                    GameMode++;
                                }
                                else if (CManager.P1CardCount > 13 || CManager.P1CardCount < 0)
                                {
                                    GameMode--;
                                }
                            }
                            else if (QCount == 3)
                            {
                                if (CManager.P2CardCount < 13 && CManager.P2CardCount > 0)
                                {
                                    MyCards[RandomCard].transform.parent = CManager.p2Folder.transform;
                                    MyCards[RandomCard].GetComponent<CardText>().CardImage.GetComponent<Image>().enabled = false;
                                    MyCards[RandomCard].GetComponent<CardText>().Naiyou.text = "";
                                    MyCards[RandomCard].GetComponent<CardText>().Number1.text = "";
                                    MyCards[RandomCard].GetComponent<CardText>().Number2.text = "";

                                    CManager.P2CardCount++;
                                    CManager.P3CardCount--;
                                    CManager.P2ActiveCard();

                                    _list = new List<GameObject>(MyCards);
                                    _list.RemoveAt(Count);

                                    MyCards = _list.ToArray();
                                    //NEXT
                                    GameMode++;
                                }
                                else if (CManager.P2CardCount > 13 || CManager.P2CardCount < 0)
                                {
                                    GameMode--;
                                }
                            }
                            else if (QCount == 4)
                            {
                                if (CManager.P4CardCount < 13 && CManager.P4CardCount > 0)
                                {
                                    MyCards[RandomCard].transform.parent = CManager.p4Folder.transform;
                                    MyCards[RandomCard].GetComponent<CardText>().CardImage.GetComponent<Image>().enabled = false;
                                    MyCards[RandomCard].GetComponent<CardText>().Naiyou.text = "";
                                    MyCards[RandomCard].GetComponent<CardText>().Number1.text = "";
                                    MyCards[RandomCard].GetComponent<CardText>().Number2.text = "";

                                    CManager.P4CardCount++;
                                    CManager.P3CardCount--;
                                    CManager.P4ActiveCard();

                                    _list = new List<GameObject>(MyCards);
                                    _list.RemoveAt(Count);

                                    MyCards = _list.ToArray();
                                    //NEXT
                                    GameMode++;
                                }
                                else if (CManager.P4CardCount > 13 || CManager.P4CardCount < 0)
                                {
                                    GameMode--;
                                }
                            }
                            break;
                        case 4:
                            GameMode = 0;
                            CManager.TurnEnd = true;
                            break;
                    }
        }
    }

    public void Refind()
    {
        MyCards = GameObject.FindGameObjectsWithTag("3PCARDObj");
    }
}
