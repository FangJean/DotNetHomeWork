using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChessManager : MonoBehaviour
{
    public static ChessManager Instance { get; private set; }
    public int colNum;
    public int rowNum;
    public Sprite chess;
    Grids[,] allGrids;
    public int winNum;
    public GameObject panel_win;
    public Button btn_next;
    public int nextLevelIndex;
    Chess _currentChess;
    private void Awake()
    {
        
        Instance = this; 
        allGrids = new Grids[colNum, rowNum];

        for(int i =0;i<colNum;i++)
        {
            for(int j =0;j<rowNum;j++)
            {
                allGrids[i, j] = transform.GetChild(j * colNum + i).GetComponent<Grids>();
            }
        }


        foreach(var v in allGrids)
        {
            v.InitGrid(chess);
        }
    }
    bool HasGrid(Cor c)
    {
        if (c.x < 0 ||c.x >= colNum || c.y< 0 || c.y >= rowNum)
            return false;
        if (allGrids[c.x, c.y] == null)
            return false;
        return true;
    }
    bool HasChess(Cor c)
    {
        if (c.x < 0 || c.x >= colNum || c.y < 0 || c.y >= rowNum)
            return false;
        if (allGrids[c.x, c.y] == null)
            return false;
        return allGrids[c.x, c.y].chess != null;
    }
    List<Grids> moveableGrids = new List<Grids>();

    Cor  GetXY(Grids g)
    {
        Cor result = new Cor();
        
        for (int i =0;i<colNum;i++)
            for(int j = 0;j<rowNum;j++)
            {
                if (allGrids[i, j] == g)
                {
                    result.x = i;
                    result.y = j;
                    return result;
                }

            }
        return result;
    }
    public void OnGridClicked(Grids g)
    {
        if (_currentChess == null && g.chess !=null)
        {

            Chess c = g.chess;

            _currentChess = c;
            print(_currentChess?.grid.transform.name);
            _currentChess.grid.SetColor(Color.green);
            Cor cor = GetXY(_currentChess.grid);
            Cor left = new Cor(cor);
            left.x -= 2;
            if (HasGrid(left) && !HasChess(left))
            {
                Cor mid = new Cor(left);
                mid.x++;
                if(HasGrid(mid) && HasChess(mid))
                    moveableGrids.Add(allGrids[left.x, left.y]);
            }
            Cor right = new Cor(cor);
            right.x += 2;
            if(HasGrid(right) && !HasChess(right))
            {
                Cor mid = new Cor(right);
                mid.x--;
                if (HasGrid(mid) && HasChess(mid))
                    moveableGrids.Add(allGrids[right.x, right.y]);
            }
            Cor up = new Cor(cor);
            up.y += 2;
            if(HasGrid(up) && !HasChess(up))
            {
                Cor mid = new Cor(up);
                mid.y--;
                if (HasGrid(mid) && HasChess(mid))
                    moveableGrids.Add(allGrids[up.x, up.y]);
            }
            Cor down = new Cor(cor);
            down.y -= 2;
            if(HasGrid(down) && !HasChess(down))
            {
                Cor mid = new Cor(down);
                mid.y++;
                if (HasGrid(mid) && HasChess(mid))
                    moveableGrids.Add(allGrids[down.x, down.y]);
            }
            foreach(var v in moveableGrids)
            {
                v.SetColor(Color.green);
            }
        }
        else if(_currentChess == g.chess)
        {
            g.SetColor(Color.white);
            foreach (var v in moveableGrids)
                v.SetColor(Color.white);
            moveableGrids.Clear();
            _currentChess = null;
        }
        else if(_currentChess !=null && moveableGrids.Contains(g))
        {
            Cor mid = new Cor();
            Cor end = GetXY(g);
            Cor start = GetXY(_currentChess.grid);
            mid.SetMid(start, end);
            _currentChess.grid.SetColor(Color.white);
            _currentChess.MoveToGrid(g, Half,Finish);
            _currentChess.grid.SetColor(Color.white);
            foreach (var v in moveableGrids)
                v.SetColor(Color.white);
            moveableGrids.Clear();
            _currentChess = null;
            void Half()
            {
              Destroy(allGrids[mid.x, mid.y].chess.gameObject);
            }

            void Finish()
            {
                if(IsWin())
                {
                    gameObject.SetActive(false);
                    panel_win.SetActive(true);
                    btn_next.onClick.AddListener(() => SceneManager.LoadScene(nextLevelIndex));
                }
            }
        }

    }

    bool IsWin()
    {
        int numLeft = 0;
        foreach(var v in allGrids)
        {
            if (v != null && v.chess != null)
                numLeft++;
        }
        return numLeft <= winNum;
    }

}

public class Cor
{
   public int x;
   public int y;
    public Cor()
    {

    }

    public Cor (Cor o)
    {
        x = o.x;
        y = o.y;
    }
    public void SetMid(Cor f1,Cor f2)
    {
        x = (f1.x + f2.x) / 2;
        y = (f1.y + f2.y) / 2;
    }
}
