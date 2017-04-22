using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroupType
{
    red,
    black,
}

public enum ChessType
{
    empty = 0,

    red_general = 1,
    red_shi,
    red_elephant,
    red_car,
    red_horse,
    red_gun,
    red_solider,

    black_general = 11,
    black_shi,
    black_elephant,
    black_car,
    black_horse,
    black_gun,
    black_solider,
}
    // 棋盘类
public class board : MonoBehaviour {
	public const int Height = 10;
	public const int Weight = 9;
    public GameObject templetChess; // 棋子模板对象 通过这个对象克隆其他旗子
    
   
	private ChessType[,] _dataArr;
	private ChessType[,] _initDataArr = {
		{ChessType.red_car, ChessType.red_horse, ChessType.red_elephant, ChessType.red_shi, ChessType.red_general, ChessType.red_shi, ChessType.red_elephant, ChessType.red_horse, ChessType.red_car},
		{ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty},
		{ChessType.empty, ChessType.red_gun, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.red_gun, ChessType.empty},
		{ChessType.red_solider, ChessType.empty, ChessType.red_solider, ChessType.empty, ChessType.red_solider, ChessType.empty, ChessType.red_solider, ChessType.empty, ChessType.red_solider},
		{ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty},
		{ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty},
		{ChessType.black_solider, ChessType.empty, ChessType.black_solider, ChessType.empty, ChessType.black_solider, ChessType.empty, ChessType.black_solider, ChessType.empty, ChessType.black_solider},
		{ChessType.empty, ChessType.black_gun, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.black_gun, ChessType.empty},
		{ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty, ChessType.empty},
		{ChessType.black_car, ChessType.black_horse, ChessType.black_elephant, ChessType.black_shi, ChessType.black_general, ChessType.black_shi, ChessType.black_elephant, ChessType.black_horse, ChessType.black_car},
	};

    // 轮到哪一方下子
    public GroupType CurrentGroup { get; set; }

    // 当前玩家属于哪一方
    public GroupType PlayerGroup{ get; set;}

    // 玩家当前选中的棋子位置
    private chessPos _currentSelectPos;


    // 根据旗子类型获取阵营类型
    public GroupType getGroupType(ChessType chessType)
    {
        if ((int)chessType > 10)
            return GroupType.black;

        return GroupType.red;
    }

	//设置棋盘数据
	public void setData(ChessType[,] boardData = null)
	{
		if (boardData == null) {
			// 如果没有设置 就用默认棋盘数据
			_dataArr = _initDataArr;
		} else {
			// 设置残局数据 或者没有完成的棋盘
			_dataArr = boardData;	
		}
		return;
	}

    // 绘制旗子
    private void drawChess(int posH, int posW, ChessType type)
    {
        if (type == ChessType.empty)
        {
            return;
        }

        GameObject chessObj = Instantiate(templetChess);
        chess chessScript = chessObj.GetComponent<chess>();
        chessScript.type = type;
        chessScript.Pos = new chessPos();
        chessScript.Pos.hIndex = posH;
        chessScript.Pos.wIndex = posW;
        chessScript.draw();

    }

    // 绘制棋盘
    public void drawBoard()
    {
        if (_dataArr == null)
        {
            return;
        }

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Weight; j++)
            {
                drawChess(i, j, _dataArr[i, j]);
            }
        }

    }

    // 处理用户对棋盘位置的点击事件
    private void onClickPos(int posH, int posW)
    {
        // 判断是否轮到玩家操作
        if (PlayerGroup != CurrentGroup)
            return;

        ChessType selectChessType = _dataArr[posH, posW];

        // 判断是选子 还是 落子
        if (_currentSelectPos.hIndex == -1)
        {
            if (selectChessType == ChessType.empty)
                return;

            if (getGroupType(selectChessType) != PlayerGroup)
                return;

            _currentSelectPos.hIndex = posH;
            _currentSelectPos.wIndex = posW;
        }
        else
        {
            if (selectChessType == ChessType.empty)
            {
                ChessType oldChessType = _dataArr[_currentSelectPos.hIndex, _currentSelectPos.wIndex];
                _dataArr[_currentSelectPos.hIndex, _currentSelectPos.wIndex] = ChessType.empty;
                _dataArr[posH, posW] = oldChessType;
            }

            _currentSelectPos.hIndex = -1;
            _currentSelectPos.wIndex = -1;

            // 绘制棋盘
            drawBoard();
            

        }

    }

	// Use this for initialization
	void Start () {
        setData();
        drawBoard();

        // 设置红方先走
        CurrentGroup = GroupType.red;
        // 设置玩家为红方
        PlayerGroup = GroupType.red;

        // 玩家选中棋子置为null
        _currentSelectPos = new chessPos();
        _currentSelectPos.hIndex = -1;
        _currentSelectPos.wIndex = -1;



    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) == false)
        {
            return;
        }

        Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            {
                chessPos pos = c.gameObject.GetComponent<chessPos>();
                Debug.Log(string.Format("pos is {0}, {1}", pos.hIndex, pos.wIndex));


                onClickPos(pos.hIndex, pos.wIndex);

            }
        }

    }
}



