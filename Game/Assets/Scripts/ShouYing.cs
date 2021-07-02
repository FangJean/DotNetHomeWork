using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShouYing : MonoBehaviour
{
    public Image img_leftShadow;
    public Image img_rightShadow;
    public GameObject win;
    public Image img_left;
    public Image img_right;
    public int nextLevelIndex;
    public Button btn_win;
    public Sprite[] lefts;
    public Sprite[] rights;

    public Button btn_left;
    public Button btn_right;

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
    bool IsWin()
    {
        return img_left.sprite == img_leftShadow.sprite && img_right.sprite == img_rightShadow.sprite;
    }
    void OnRightClicked()
    {
        _rightIndex++;
        _rightIndex %= rights.Length;
        img_right.sprite = rights[_rightIndex];
        if (IsWin())
            win.SetActive(true);
    }
}
