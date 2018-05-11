using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardText : MonoBehaviour
{

	CardManager CManager;
	public Text Naiyou, Number1, Number2;
	public int count;

	// Use this for initialization
	void Start()
	{
		CManager = GameObject.Find("CardManager").GetComponent<CardManager>();

		if (count.IsEven() == true)
        {
            Number1.text = CManager.CardList[count].CardNumber.ToString();
            Number2.text = CManager.CardList[count].CardNumber.ToString();

            Number1.color = Color.red;
            Number2.color = Color.red;
        }
        else
        {
            Number1.text = CManager.CardList[count].CardNumber.ToString();
            Number2.text = CManager.CardList[count].CardNumber.ToString();

            Number1.color = Color.blue;
			Number2.color = Color.blue;
        }

		Naiyou.text = CManager.CardList[count].Naiyou;
	}

	// Update is called once per frame
	void Update()
	{
		if (this.gameObject.transform.parent.name == "1PCARD")
		{
			this.gameObject.tag = "1PCARDObj";
		}
		if (this.gameObject.transform.parent.name == "2PCARD")
		{
			this.gameObject.tag = "2PCARDObj";
		}
		if (this.gameObject.transform.parent.name == "3PCARD")
		{
			this.gameObject.tag = "3PCARDObj";
		}
		if (this.gameObject.transform.parent.name == "4PCARD")
		{
			this.gameObject.tag = "4PCARDObj";
		}

	}

}


