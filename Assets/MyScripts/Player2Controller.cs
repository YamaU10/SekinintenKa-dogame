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

        

        //inputHorizontal = Input.GetAxis("Horizontal");
        //inputVertical = Input.GetAxis("Vertical");

        if (CManager.Ins == true)
        {

            if (Input.GetButtonDown("Horizontal"))
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

        //    switch (Count)
        //    {
        //        case 0:
        //            MyCards[0].transform.position = new Vector3(MyCards[0].transform.position.x, 75, MyCards[0].transform.position.z);
        //            MyCards[0].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);

        //            MyCards[12].transform.position = p1CardPos[12].transform.position;
        //            MyCards[12].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            break;

        //        case 1:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 2:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 3:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 4:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;


        //        case 5:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 6:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 7:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 8:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 9:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 10:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 11:
        //            MyCards[Count - 1].transform.position = p1CardPos[Count - 1].transform.position;
        //            MyCards[Count - 1].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;

        //        case 12:
        //            MyCards[0].transform.position = p1CardPos[0].transform.position;
        //            MyCards[0].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);
        //            MyCards[11].transform.position = p1CardPos[11].transform.position;
        //            MyCards[11].transform.localScale = new Vector3(1.2f, 1.3f, 1.1f);

        //            MyCards[Count].transform.position = new Vector3(MyCards[Count].transform.position.x, 75, MyCards[Count].transform.position.z);
        //            MyCards[Count].transform.localScale = new Vector3(1.3f, 1.4f, 1.1f);
        //            break;
        //    }
        }


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
			MyCards[i].transform.Rotate(0, 180, 0);

        }

		CardParant.transform.localScale = new Vector3(0.46f, 0.46f, 0.46f);

        end = true;
    }
}
