using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChessManager : MonoBehaviour
{
    public static ChessManager Instance { get; private set; }
	
	//行列数
    public int colNum;  
    public int rowNum;
	
	//棋图片
    public Sprite chess;
	
	//所有棋格子
    Grids[,] allGrids;
	
	//胜利条件——剩余棋子数量
    public int winNum;
	
    public GameObject panel_win;
    public Button btn_next;
    public int nextLevelIndex;
	
	//选中的棋子
    Chess _currentChess;
    private void Awake()
    {
        
        Instance = this; 
        allGrids = new Grids[colNum, rowNum];

		//初始化数组
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
	
	//格子是否存在
    bool HasGrid(Cor c)
    {
        if (c.x < 0 ||c.x >= colNum || c.y< 0 || c.y >= rowNum)
            return false;
        if (allGrids[c.x, c.y] == null)
            return false;
        return true;
    }
	
	//格子里是否有棋子
    bool HasChess(Cor c)
    {
        if (c.x < 0 || c.x >= colNum || c.y < 0 || c.y >= rowNum)
            return false;
        if (allGrids[c.x, c.y] == null)
            return false;
        return allGrids[c.x, c.y].chess != null;
    }
	
	//可以移动的棋子所在格子
    List<Grids> moveableGrids = new List<Grids>();

    //得到格子坐标
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
	
	//点击格子
    public void OnGridClicked(Grids g)
    {
		//如果是第一次选择
        if (_currentChess == null && g.chess !=null)
        {

            Chess c = g.chess;

            _currentChess = c;
            print(_currentChess?.grid.transform.name);
            _currentChess.grid.SetColor(Color.green);
            Cor cor = GetXY(_currentChess.grid);
            Cor left = new Cor(cor);
            left.x -= 2;
			
			//判断上下左右格子是否可以点击
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
			
			//可以移动的地方设置为灰色
            foreach(var v in moveableGrids)
            {
                v.SetColor(Color.grey);
            }
        }
		
		//如果点击两次格子则取消选中
        else if(_currentChess == g.chess)
        {
            g.SetColor(Color.white);
            foreach (var v in moveableGrids)
                v.SetColor(Color.white);
            moveableGrids.Clear();
            _currentChess = null;
        }
		
		//如果可以移动
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
	
    //如果剩余棋子小于胜利要求的棋子则胜利
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

//坐标类
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
	
	//取中点
    public void SetMid(Cor f1,Cor f2)
    {
        x = (f1.x + f2.x) / 2;
        y = (f1.y + f2.y) / 2;
    }
}
