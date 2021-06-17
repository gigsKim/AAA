using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSynerge : MonoBehaviour
{

    public GameObject Silust;
    public GameObject Stext;
    public GameObject Sdetail;
    public string SdetailText;

    public Sprite[] ilust = new Sprite[5];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        Debug.Log("시작");
        Sdetail.SetActive(true);
        Sdetail.GetComponent<Text>().text = SdetailText; 

    }

    private void OnMouseExit()
    {
        Sdetail.SetActive(false);

    }

    public void Showoff()
    {
        Silust.SetActive(false);
        Stext.SetActive(false);

    }
    

    public  void Synergedetail(int a)
    {
        Silust.SetActive(true);
        Stext.SetActive(true);

        Silust.GetComponent<SpriteRenderer>().sprite = ilust[a];
        if(a == 0){
            SdetailText = "";
            Stext.GetComponent<Text>().text = "천사" +" "+ Synerge.angelcount+"\n";
            SdetailText += "<size=25>"+ "천사" +"</size>"+"\n\n";
            SdetailText += "천사는 모든 유닛에 초당 체력 회복을 부여합니다. \n\n";
            if (Synerge.angelcount >= 2)
                SdetailText +=  "2) 조금 회복" +"\n";
            else
                SdetailText += "<color=silver>" + "2) 조금 회복" + "</color>" + "\n";

            if (Synerge.angelcount >= 4)
                SdetailText += "4) 많이 회복" + "\n";
            else
                SdetailText += "<color=silver>" + "4) 많이 회복" + "</color>" + "\n";

           if (Synerge.angelcount >= 6)
                SdetailText += "6) 존나 많이 회복" + "\n";
            else
                SdetailText += "<color=silver>" + "6) 아주 많이 회복" + "</color>" + "\n";


        }


        if (a == 1){
            SdetailText = "";
            Stext.GetComponent<Text>().text = "악마" + " " + Synerge.demoncount;
            SdetailText += "<size=25>" + "악마" + "</size>" + "\n\n";
            SdetailText += "악마는 모든 유닛에 추가 공격력 부여합니다. \n\n";
            if (Synerge.demoncount >= 2)
                SdetailText += "2) 조금 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "2) 조금 쌔짐" + "</color>" + "\n";

            if (Synerge.demoncount >= 4)
                SdetailText += "4) 많이 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "4) 많이 쌔짐" + "</color>" + "\n";

            if (Synerge.demoncount >= 6)
                SdetailText += "6) 존나 많이 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "6) 아주 많이 쌔짐" + "</color>" + "\n";
        }

        if (a == 2){
            Stext.GetComponent<Text>().text = "인간" + " " + Synerge.humancount;
            SdetailText += "<size=25>" + "인간" + "</size>" + "\n\n";
            SdetailText += "인간은 모든 유닛에 추가 체력을 부여합니다. \n\n";

            if (Synerge.humancount >= 2)
                SdetailText += "2) 조금 증가함" + "\n";
            else
                SdetailText += "<color=silver>" + "2) 조금 증가함" + "</color>" + "\n";

            if (Synerge.humancount >= 4)
                SdetailText += "4) 많이 증가함" + "\n";
            else
                SdetailText += "<color=silver>" + "4) 많이 증가함" + "</color>" + "\n";

            if (Synerge.humancount >= 6)
                SdetailText += "6) 존나 많이 증가함" + "\n";
            else
                SdetailText += "<color=silver>" + "6) 아주 많이 증가함" + "</color>" + "\n";
        }

        if (a == 3){
            Stext.GetComponent<Text>().text = "정령" + " " + Synerge.spritcount;
            SdetailText += "정령은 나는 정령 너는 정령? 우리모두 천사\n";

            if (Synerge.humancount >= 2)
                SdetailText += "2) 조금 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "2) 조금 쌔짐" + "</color>" + "\n";

            if (Synerge.humancount >= 4)
                SdetailText += "4) 많이 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "4) 많이 쌔짐" + "</color>" + "\n";

            if (Synerge.humancount >= 6)
                SdetailText += "6) 존나 많이 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "6) 존나 많이 쌔짐" + "</color>" + "\n";


        }
        if (a == 4){
            Stext.GetComponent<Text>().text = "짐승" + Synerge.oraclecount;
            SdetailText += "짐승은 나만 짐승 너는 천사 우리 중 나만 짐승\n";

            if (Synerge.humancount > 2)
                SdetailText += "2) 조금 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "2) 조금 쌔짐" + "</color>" + "\n";

            if (Synerge.humancount > 4)
                SdetailText += "4) 많이 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "4) 많이 쌔짐" + "</color>" + "\n";

            if (Synerge.humancount > 6)
                SdetailText += "6) 존나 많이 쌔짐" + "\n";
            else
                SdetailText += "<color=silver>" + "6) 존나 많이 쌔짐" + "</color>" + "\n";
        }
    }
}
