using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
{

    //float inputHorizontal, inputVertical;
    public GameObject[] MyCards;

    public GameObject[] p1CardPos;
    //float timer;
    bool end;
    public int Count = 0, QCount = 2;
    public int CountSet1, CountSet2, MyCards1Number, MyCards2Number;
    public string Set1Naiyou, Set2Naiyou;
    CardManager CManager;
    public GameObject QCanvas, P2Image, P3Image, P4Image;

    int GameActiveMode = 0, GameMode = 0;
    bool[] DelCardFlag = new bool[20];
    bool MoveFlag;
    float timer;
    bool next = true;
    float my;

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
        //Debug.Log(QCount);
        float inputHorizontal = Input.GetAxis("Horizontal2");
        float inputVertical = Input.GetAxis("Vertical2");

        if (MoveFlag == false)
        {
            if (inputHorizontal >= 0.5f || inputHorizontal <= -0.5f)
            {

                timer += Time.deltaTime;
                if (timer > 0.1f)
                {
                    MoveFlag = true;
                    timer = 0;
                }
            }
        }

        if(CManager.GameEnd == false)
        if (CManager.P1End == false)
        {
            if (GameActiveMode < 4)
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



                        for (int i = 0; i < MyCards.Length; ++i)
                        {
                            if (DelCardFlag[i])
                            {
                                my = MyCards[i].transform.position.y;
                                my = my * 1.2f;
                                MyCards[i].transform.position = new Vector3(MyCards[i].transform.position.x, my, MyCards[i].transform.position.z);
                                MyCards[i].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
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

                        for (int i = 0; i < DelCardFlag.Length; i++)
                        {
                            DelCardFlag[i] = false;
                        }
                        GameActiveMode++;
                        break;
                }

            if (CManager.P1Turn)
                if (GameActiveMode == 4)
                    switch (GameMode)
                    {
                        case 0:
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

                            for (int i = 0; i < MyCards.Length; ++i)
                            {
                                if (DelCardFlag[i])
                                {
                                    my = MyCards[i].transform.position.y;
                                    my = my * 1.2f;

                                    MyCards[i].transform.position = new Vector3(MyCards[i].transform.position.x, my, MyCards[i].transform.position.z);
                                    MyCards[i].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
                                }
                            }

                            //NEXT
                            GameMode++;

                            break;

                        case 1: //Waitß

                            for (int i = 0; i < MyCards.Length; ++i)
                            {
                                if (DelCardFlag[i])
                                {
                                    CManager.text.text = "このカードを除去します\nBボタンを押してください";
                                    next = false;
                                    break;
                                }
                            }
                            if (next == true)
                            {
                                CManager.text.text = "セットはありません\nBボタンを押してください";
                            }
                            //if (next == false)
                            {
                                //CManager.text.text = "このカードを除去します\nBボタンを押してください";
                                if (Input.GetButtonDown("ConB"))
                                {
                                    GameMode++;
                                    CManager.text.text = "カードを選んでね！";
                                }
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

                            GameMode++;
                            break;

                        case 3: //POS
                            for (int i = 0; i < MyCards.Length; i++)
                            {
                                //PosCount++;
                                if (MyCards[i] != null)
                                    MyCards[i].transform.position = p1CardPos[i].transform.position;
                            }

                            for (int i = 0; i < DelCardFlag.Length; i++)
                            {
                                DelCardFlag[i] = false;
                            }
                            Count = 0;
                            GameMode++;
                            break;

                        case 4:
                            if (inputHorizontal >= 0.5f)
                            {
                                if (MoveFlag == true)
                                {
                                    if (Count < MyCards.Length)
                                    {
                                        Count += 1;
                                    }
                                    if (Count == MyCards.Length)
                                    {
                                        Count = 0;
                                    }
                                    MoveFlag = false;
                                }
                            }
                            if (inputHorizontal <= -0.5f)
                            {
                                if (MoveFlag)
                                {
                                    if (Count > -1)
                                    {
                                        Count -= 1;
                                    }
                                    if (Count == -1)
                                    {
                                        Count = MyCards.Length - 1;
                                    }
                                    MoveFlag = false;
                                }
                            }
                            if (Input.GetButtonDown("ConB"))
                            {
                                QCanvas.SetActive(true);
                                GameMode++;
                            }



                            //PosInit
                            for (int i = 0; i < MyCards.Length; ++i)
                            {
                                MyCards[i].transform.position = p1CardPos[i].transform.position;
                                MyCards[i].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
                            }
                            //Select
                            my = MyCards[Count].transform.position.y;
                            my = my * 1.2f;
                            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, my, MyCards[Count].transform.position.z);
                            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
                            break;

                        case 5:
                            inputHorizontal = Input.GetAxis("Horizontal2");
                            inputVertical = Input.GetAxis("Vertical2");

                            if (inputHorizontal <= 0.5f)
                            {
                                if (MoveFlag)
                                {
                                    QCount -= 1;
                                    if (QCount == 1)
                                    {
                                        QCount = 4;
                                    }
                                    MoveFlag = false;
                                }
                            }
                            if (inputHorizontal >= 0.5f)
                            {
                                if (MoveFlag)
                                {
                                    QCount++;
                                    if (QCount == 5)
                                    {
                                        QCount = 2;
                                    }
                                    MoveFlag = false;
                                }
                            }

                            if (Input.GetButtonDown("ConA"))
                            {
                                GameMode--;
                                QCanvas.SetActive(false);
                            }

                            if (QCount == 2)
                            {
                                if (CManager.P2CardCount < 13 && CManager.P2CardCount > 0)
                                {
                                    P2Image.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);
                                    P3Image.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                                    P4Image.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

                                    if (Input.GetButtonDown("ConB"))
                                    {
                                        MyCards[Count].transform.parent = CManager.p2Folder.transform;
                                        MyCards[Count].GetComponent<CardText>().CardImage.GetComponent<Image>().enabled = false;
                                        //MyCards[Count].tag = "P2CARDObj";
                                        CManager.P2CardCount++;
                                        CManager.P1CardCount--;
                                        CManager.P2ActiveCard();

                                        List<GameObject> _List = new List<GameObject>(MyCards);
                                        //int max = MyCards.Length;

                                        _List.RemoveAt(Count);



                                        MyCards = _List.ToArray();

                                        for (int i = 0; i < MyCards.Length; i++)
                                        {
                                            //PosCount++;
                                            if (MyCards[i] != null)
                                                MyCards[i].transform.position = p1CardPos[i].transform.position;
                                        }
                                        //NEXT
                                        QCanvas.SetActive(false);
                                        GameMode++;
                                    }

                                }
                                else if (CManager.P2CardCount >= 13 && CManager.P2CardCount <= 0)
                                {
                                    CManager.text.text = "P2には送れないよ！";
                                }
                            }
                            if (QCount == 3)
                            {
                                if (CManager.P3CardCount < 13 && CManager.P3CardCount > 0)
                                {
                                    P3Image.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);
                                    P2Image.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                                    P4Image.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);


                                    if (Input.GetButtonDown("ConB"))
                                    {
                                        MyCards[Count].transform.parent = CManager.p3Folder.transform;
                                        MyCards[Count].GetComponent<CardText>().CardImage.GetComponent<Image>().enabled = false;
                                        //MyCards[Count].tag = "P2CARDObj";
                                        CManager.P3CardCount++;
                                        CManager.P1CardCount--;
                                        CManager.P3ActiveCard();

                                        List<GameObject> _List = new List<GameObject>(MyCards);
                                        //int max = MyCards.Length;

                                        _List.RemoveAt(Count);



                                        MyCards = _List.ToArray();

                                        for (int i = 0; i < MyCards.Length; i++)
                                        {
                                            //PosCount++;
                                            if (MyCards[i] != null)
                                                MyCards[i].transform.position = p1CardPos[i].transform.position;
                                        }
                                        //NEXT
                                        QCanvas.SetActive(false);
                                        GameMode++;
                                    }

                                }
                                else if (CManager.P3CardCount >= 13 && CManager.P3CardCount <= 0)
                                {
                                    CManager.text.text = "P3には送れないよ！";
                                }

                            }
                            if (QCount == 4)
                            {
                                if (CManager.P4CardCount < 13 && CManager.P4CardCount > 0)
                                {
                                    P4Image.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);
                                    P3Image.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                                    P2Image.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);



                                    if (Input.GetButtonDown("ConB"))
                                    {
                                        MyCards[Count].transform.parent = CManager.p4Folder.transform;
                                        MyCards[Count].GetComponent<CardText>().CardImage.GetComponent<Image>().enabled = false;
                                        //MyCards[Count].tag = "P2CARDObj";
                                        CManager.P4CardCount++;
                                        CManager.P1CardCount--;
                                        CManager.P4ActiveCard();

                                        List<GameObject> _List = new List<GameObject>(MyCards);
                                        //int max = MyCards.Length;

                                        _List.RemoveAt(Count);



                                        MyCards = _List.ToArray();

                                        for (int i = 0; i < MyCards.Length; i++)
                                        {
                                            //PosCount++;
                                            if (MyCards[i] != null)
                                                MyCards[i].transform.position = p1CardPos[i].transform.position;
                                        }
                                        //NEXT
                                        QCanvas.SetActive(false);
                                        GameMode++;
                                    }

                                }
                                else if (CManager.P4CardCount >= 13 && CManager.P4CardCount <= 0)
                                {
                                    CManager.text.text = "P4には送れないよ！";
                                }
                            }

                            //GameMode++;
                            break;
                        case 6:
                            GameMode = 0;
                            CManager.TurnEnd = true;
                            break;
                    }




            if (end == true)
            {
                return;
            }

            if (CManager.Ins == false)
            {
                return;
            }
            end = true;
        }
    }

    public void Refind()
    {
        MyCards = GameObject.FindGameObjectsWithTag("1PCARDObj");
    }
}
