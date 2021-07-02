using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Grids : MonoBehaviour,IPointerClickHandler
{
    public bool canMove;
    public bool has;
    public Chess chess;

    private void Awake()
    {

    }
    public void InitGrid(Sprite cheese)
    {
        if (!canMove)
            Destroy(gameObject);
        else if (!has)
            Destroy(chess.gameObject);
        else
            chess.SetImage(cheese);

    }
    private void Start()
    {
     

        
    }
    
    public void SetColor(Color c)
    {
        GetComponent<Image>().color = c;
    }
   public void SetImage(Sprite sp)
    {
        chess.SetImage(sp);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChessManager.Instance.OnGridClicked(this);
    }
}
