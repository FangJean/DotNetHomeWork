using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flower : MonoBehaviour
{
    public GameObject wine;
    public GameObject flower;
    public bool move = false;
    public bool isMove = false;
    private Vector3 offset;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePos = Input.mousePosition;
        offset = transform.position - mousePos;
    }
    public void OnDrag(PointerEventData eventData)
    {
        wine.transform.position = Input.mousePosition + offset;
    }
    //����ʵ����ק�ƶ��ƺ���һ���̶�λ�ã���Ļ��ߣ�������һ�ζԻ�
}

