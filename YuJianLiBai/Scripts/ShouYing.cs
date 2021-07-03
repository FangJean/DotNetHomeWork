using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShouYing : MonoBehaviour
{
	//左右手影子
    public Image img_leftShadow;
    public Image img_rightShadow;
	
	//左右手图片
    public Image img_left;
    public Image img_right;
	
	//所有图片
    public Sprite[] lefts;
    public Sprite[] rights;

    //左右切换按钮
    public Button btn_left;
    public Button btn_right;
	
	public GameObject win;
	
	public int nextLevelIndex;
	
    public Button btn_win;

    //当前的索引
    int _leftIndex;
    int _rightIndex;
	
    void Start()
    {
        btn_left.onClick.AddListener(OnLeftClicked);
        btn_right.onClick.AddListener(OnRightClicked);
        btn_win.onClick.AddListener(() => SceneManager.LoadScene(nextLevelIndex));
    }
	
    void Update()
    {

    }

    void OnLeftClicked()
    {
        _leftIndex++;
        _leftIndex %= lefts.Length;
        img_left.sprite = lefts[_leftIndex];

        if (IsWin())
            win.SetActive(true);
    }

    void OnRightClicked()
    {
        _rightIndex++;
        _rightIndex %= rights.Length;
        img_right.sprite = rights[_rightIndex];
        if (IsWin())
            win.SetActive(true);
    }
	
	//如果手和影子图片一样，就胜利
    bool IsWin()
    {
        return img_left.sprite == img_leftShadow.sprite && img_right.sprite == img_rightShadow.sprite;
    }
}
