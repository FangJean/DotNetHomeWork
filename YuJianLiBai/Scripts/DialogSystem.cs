using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//读取剧情
public class DialogSystem : MonoBehaviour
{
    public Text textBox;
    public Text name;
    public TextAsset textFile;
    public int index;
    public int nextLevelIndex; //跳转场景Index
    public int totalIndex;
    //int id = SceneManager.GetActiveScene().buildIndex;
    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetText(textFile);
        index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            textBox.text = textList[index];
            name.text = textList[index - 1];
            index =index + 2;
        }
        if (index==totalIndex && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

    void GetText(TextAsset file)
    {
        textList.Clear();
        index = 1;

        var lineText = file.text.Split('\n');

        foreach(var line in lineText)
        {
            textList.Add(line);
        }
    }
}
