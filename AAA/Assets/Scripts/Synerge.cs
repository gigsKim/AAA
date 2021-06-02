using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Synerge : MonoBehaviour
{
    public GameObject newtext;
    // 1번 천사 , 2번 악마, 3번 정령, 4번 인간 , 5번 신령
    public static int angelcount ;
    public static int demoncount ;
    public static int spritcount;
    public static int humancount ;
    public static int oraclecount ;

    public GameObject[] synobj = new GameObject[5];
    public Boolean[] synoff = new Boolean[5];
    public int[] syn = new int[5];
    
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
        newtext.SetActive(true);
        
    }

    private void OnMouseExit()
    {
        newtext.SetActive(false);
        

    }


    //입력이 있었을때 시너지 숫자 변경후 재정렬함
    public void change()
    {
        syn[0] = angelcount;
        syn[1] = demoncount;
        syn[2] = spritcount;
        syn[3] = humancount;
        syn[4] = oraclecount;


        Array.Sort(syn);
        Array.Reverse(syn);
        for (int i = 0; i < 5; i++)
        {
            
            synoff[i] = true;
            
        }
        sortsyn();
        
    }

    //시너지를 정렬하고 시너지 개수를 보여주는 함수
    void sortsyn()
    {

        for(int i =0; i < 5; i++)
        {
            if (syn[i] > 0)
            {

                if (syn[i] == angelcount && synoff[0] == true)
                {
                    synobj[i].GetComponent<ShowSynerge>().Synergedetail(0);
                    synoff[0] = false;

                }

                else if (syn[i] == demoncount && synoff[1] == true)
                {
                    synobj[i].GetComponent<ShowSynerge>().Synergedetail(1);
                    synoff[1] = false;

                }

                else if (syn[i] == humancount && synoff[2] == true)
                {
                    synobj[i].GetComponent<ShowSynerge>().Synergedetail(2);
                    synoff[2] = false;

                }

                else if (syn[i] == spritcount && synoff[3] == true)
                {
                    synobj[i].GetComponent<ShowSynerge>().Synergedetail(3);
                    synoff[3] = false;

                }

                else if (syn[i] == oraclecount && synoff[4] == true)
                {
                    synobj[i].GetComponent<ShowSynerge>().Synergedetail(4);
                    synoff[4] = false;

                }

            }
            else
                synobj[i].GetComponent<ShowSynerge>().Showoff();
        }

    }

}

