using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    public GameObject sex;
    private bool _mouseState;
    private Vector3 _mousePos;
    private GameObject _target;
    //0이 유닛 1이 슬롯
    private int _targetType = -1;
    public Sprite motion;
    //빈 슬롯이면 바꿔야지
    public Sprite box ;
    //매각시 필요한 변수들
    public SpriteRenderer sellsprite;
    //드랍 검사
    private Ray dropCheck;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;

            _target = GetClickedObject(out hitInfo);

            

            if (_target != null && _target.CompareTag("Slot"))
            {
                if (_target.transform.GetComponent<PlayerSlot>().ison != false)
                {
                    _mouseState = true;
                    _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                    _target.transform.position = new Vector3(_mousePos.x, _mousePos.y, _target.transform.position.z);
                    _targetType = 0;

                    Debug.Log("유닛 집음");
                }
            }



            else if (_target != null && _target.CompareTag("EnemySlot"))
            {
                if (_target.transform.GetComponent<PlayerSlot>().ison != false)
                {
                    _mouseState = true;
                    _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                    _target.transform.position = new Vector3(_mousePos.x, _mousePos.y, _target.transform.position.z);
                    _targetType = 0;
                }

            }

            else if (_target != null && _target.CompareTag("Unit"))
            {

                _mouseState = true;
                _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                _target.transform.position = new Vector3(_mousePos.x, _mousePos.y, _target.transform.position.z);
                _targetType = 1;

            }
        }


        if (_mouseState)
        {
            
            //마우스포지션 받아서 월드로 변환하고 타겟이미지가 그포지션 따라다니게 함 + 놨을때 마지막으로 남은 drop위치 체크하기위해 레이쏨
            _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            _target.transform.position = new Vector3(_mousePos.x, _mousePos.y, _target.transform.position.z);
            dropCheck = Camera.main.ScreenPointToRay(Input.mousePosition);

            //카드가 일정위치 올라가면 기물이미지로 변경되게
            if (_target.CompareTag("Unit") && _target.transform.position.y >= -3.0f)
            {
                //_target.GetComponent<SpriteRenderer>().sprite = motion;
                _target.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        //드랍
        if (Input.GetMouseButtonUp(0))
        {
            _mouseState = false;

            RaycastHit[] hits = Physics.RaycastAll(dropCheck);



            if (_targetType == 1)
            {
                //다중 레이캐스트시 0,1은 slot과 card 
                if (hits.Length == 2)
                {
                    if (hits[0].transform.gameObject.CompareTag("Slot") && hits[1].transform.gameObject.CompareTag("Unit"))
                    {
                        if (hits[0].transform.GetComponent<PlayerSlot>().ison == false)
                        {
                            hits[0].transform.gameObject.GetComponent<PlayerSlot>().picename = hits[1].transform.gameObject.GetComponent<PlayerUnit>().picename;
                            hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite = hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            Debug.Log(hits[0].transform.gameObject.GetComponent<PlayerSlot>().picename);
                            hits[0].transform.GetComponent<PlayerSlot>().ison = true;
                            hits[1].transform.gameObject.GetComponent<PlayerUnit>().gameObject.SetActive(false);
                            if (hits[1].transform.gameObject.GetComponent<PlayerUnit>().code == 0)
                            {
                                Synerge.demoncount++;
                            }
                            if (hits[1].transform.gameObject.GetComponent<PlayerUnit>().code == 1)
                            {
                                Synerge.angelcount++;
                            }
                            sex.GetComponent<Synerge>().change();
                        }
                    }
                    else if (hits[1].transform.gameObject.CompareTag("Slot") && hits[0].transform.gameObject.CompareTag("Unit"))
                    {
                        if (hits[1].transform.GetComponent<PlayerSlot>().ison == false)
                        {
                            hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename = hits[0].transform.gameObject.GetComponent<PlayerUnit>().picename;
                            hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            Debug.Log(hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename);
                            hits[1].transform.GetComponent<PlayerSlot>().ison = true;
                            hits[0].transform.gameObject.GetComponent<PlayerUnit>().gameObject.SetActive(false);
                            if(hits[0].transform.gameObject.GetComponent<PlayerUnit>().code ==0)
                            {
                                Synerge.demoncount++;
                            }
                            if (hits[0].transform.gameObject.GetComponent<PlayerUnit>().code == 1)
                            {
                                Synerge.angelcount++;
                            }

                            sex.GetComponent<Synerge>().change();
                        }
                    }

                }
            }
            else if (_targetType == 0)
            {/*
                if (hits.Length == 2)
                {
                    if (hits[1].transform.gameObject.CompareTag("Slot") && hits[0].transform.gameObject.CompareTag("Slot"))
                    {
                        if (hits[0].transform.gameObject.GetComponent<PlayerSlot>().ison == false)
                        {
                            hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite = hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite = box;
                            hits[0].transform.gameObject.GetComponent<PlayerSlot>().picename = hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename;
                            hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename = "";
                            hits[0].transform.gameObject.GetComponent<PlayerSlot>().ison = true;
                            hits[1].transform.gameObject.GetComponent<PlayerSlot>().ison = false;
                            _targetType = -1;
                            Debug.Log("한쪽만 교체 완료");
                        }


                        if (hits[0].transform.gameObject.GetComponent<PlayerSlot>().ison == true)
                        {
                            Sprite change = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            string change_name = hits[0].transform.gameObject.GetComponent<PlayerSlot>().picename;

                            hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite = hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite = change;


                            
                            hits[0].transform.gameObject.GetComponent<PlayerSlot>().picename = hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename;
                            hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename = change_name;
                            _targetType = -1;
                            Debug.Log("둘 다 완료");

                        }


                        Debug.Log("교체 완료");
                    }
                    
                    if (hits[0].transform.gameObject.CompareTag("Slot") && hits[1].transform.gameObject.CompareTag("Slot"))
                    {
                        if (hits[1].transform.gameObject.GetComponent<PlayerSlot>().ison == false)
                        {
                            hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite = hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite = box;
                            hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename = hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename;
                            hits[0].transform.gameObject.GetComponent<PlayerSlot>().picename = "";
                            hits[1].transform.gameObject.GetComponent<PlayerSlot>().ison = true;
                            hits[0].transform.gameObject.GetComponent<PlayerSlot>().ison = false;
                            _targetType = -1;
                            Debug.Log("한쪽만 교체 완료");
                        }


                        if (hits[1].transform.gameObject.GetComponent<PlayerSlot>().ison == true)
                        {
                            Sprite change = hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            string change_name = hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename;

                            hits[1].transform.gameObject.GetComponent<SpriteRenderer>().sprite = hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite;
                            hits[0].transform.gameObject.GetComponent<SpriteRenderer>().sprite = change;
                            hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename = hits[1].transform.gameObject.GetComponent<PlayerSlot>().picename;
                            hits[0].transform.gameObject.GetComponent<PlayerSlot>().picename = change_name;

                            Debug.Log("둘 다 완료");

                        }
                        Debug.Log("교체 완료");
                    }

                }
                */
            }

            _targetType = -1;
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        
        return target;
    }


}
