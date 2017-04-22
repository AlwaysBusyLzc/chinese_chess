using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chess : MonoBehaviour {

    private Dictionary<ChessType, string> type2Resname = new Dictionary<ChessType, string> { 
        {ChessType.red_car, "r_c"}, {ChessType.red_horse, "r_m"}, {ChessType.red_elephant, "r_x"}, {ChessType.red_shi, "r_s"}, {ChessType.red_general, "r_j"}, {ChessType.red_gun, "r_p"}, {ChessType.red_solider, "r_z"},
        {ChessType.black_car, "b_c"}, {ChessType.black_horse, "b_m"}, {ChessType.black_elephant, "b_x"}, {ChessType.black_shi, "b_s"}, {ChessType.black_general, "b_j"}, {ChessType.black_gun, "b_p"}, {ChessType.black_solider, "b_z"},
    };

    // 棋子类型
    public ChessType type
    {
        get;
        set;
    }

    // 位置
    public chessPos Pos
    {
        get;
        set;
    }

    public void draw()
    {
        if (type == ChessType.empty)
            return;

        // 根据pos 找到棋盘上对应的碰撞体
        string colliderName = string.Format("chessPos/chessPos_{0}_{1}", Pos.hIndex, Pos.wIndex);
        GameObject colliderObj = GameObject.Find(colliderName);
        if (colliderObj == null)
        {
            Debug.Log(string.Format("colliderObj is null when draw chess type {0} h {1}, w {2}", (int)type, Pos.hIndex, Pos.wIndex));
            return;
        }
        transform.position = colliderObj.GetComponent<Transform>().position;

        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        string resname = type2Resname[type];
        resname = string.Format("img/{0}", resname);
        if (string.IsNullOrEmpty(resname))
        {
            return;
        }
        Sprite tempSprite = Sprite.Create(Resources.Load<Texture2D>(resname), spr.sprite.textureRect, new Vector2(0.5f, 0.5f));
        spr.sprite = tempSprite;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
