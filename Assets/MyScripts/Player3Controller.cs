using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Controller : MonoBehaviour {

	public GameObject[] MyCards;
	public GameObject[] p3CardPos;
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
        }


        if (end == true)
        {
            return;
        }

        if (CManager.Ins == false)
        {
            return;
        }

        MyCards = GameObject.FindGameObjectsWithTag("3PCARDObj");

        for (int i = 0; i < 13; i++)
        {
            //PosCount++;
            if (MyCards[i] != null)
                MyCards[i].transform.position = p3CardPos[i].transform.position;

        }

        CardParant.transform.localScale = new Vector3(0.46f, 0.46f, 0.46f);

        end = true;
    }
}
