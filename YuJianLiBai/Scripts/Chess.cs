using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Chess : MonoBehaviour
{
	//所在的格子
    public Grids grid;
    RectTransform _rect;
    public Image img;
	
    private void Awake()
    {
        grid = GetComponentInParent<Grids>();
        _rect = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }
	
    public void SetImage(Sprite s)
    {
        img.sprite = s;
    }
	
	//移动棋子
    public void MoveToGrid(Grids gg,UnityAction half = null, UnityAction finish = null)
    {

        grid.chess = null;
        grid = gg;
        transform.SetParent(gg.transform);
        gg.chess = this;
        gg.GetComponent<RectTransform>().SetAsLastSibling();
        StartCoroutine(MoveToGridIE(gg, half, finish));
    }
	
    IEnumerator MoveToGridIE(Grids g, UnityAction half, UnityAction finish)
    {

        Vector2 move = -_rect.anchoredPosition;
        Vector2 start = _rect.anchoredPosition;
        float _t = 0;

        while(_t < 0.25f)
        {
            _rect.anchoredPosition = start + move * _t * 2;
            yield return 0;
            _t += Time.deltaTime;
        }
		
		//移动到中间执行
        half?.Invoke();

        while (_t < 0.5f)
        {
            _rect.anchoredPosition = start + move * _t * 2;
            yield return 0;
            _t += Time.deltaTime;
        }
		
        finish?.Invoke();
    }
}
