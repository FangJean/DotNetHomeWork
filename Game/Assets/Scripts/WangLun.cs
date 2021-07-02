using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WangLun : MonoBehaviour
{
	GameObject boat, vortex;
    public float boatspeed = 17.5f; //船行速度
	public float vspeed = 7.5f; //漩涡自转速度
    public float gameTime;
    public GameObject panel_lose;
    public Button btn_again;
    // Start is called before the first frame update
    void Start()
    {
        boat = GameObject.Find("boat");
		vortex = GameObject.Find("vortex");

        Invoke("Lose", gameTime);
    }

    // Update is called once per frame
    void Update()
    {
        boat.transform.Translate(-boatspeed * Time.deltaTime, 0, 0); //船匀速行驶
        vortex.transform.Rotate(new Vector3(0, 0, vspeed * Time.deltaTime)); //漩涡自转
		
		//Debug.Log(boat.transform.position.x + "," + boat.transform.position.y);
		if (boat.transform.position.x < 370 && boat.transform.position.y < 280 && boat.transform.position.y > 260)
		{
            //Destroy(boat);
            //boat.Layer = LayerMask.NameToLayer("camera");
        }
    }

    void Lose()
    {
        {
            panel_lose.SetActive(true);
            btn_again.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}