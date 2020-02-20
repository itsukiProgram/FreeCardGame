using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 右上の数字の管理
/// </summary>
public class ShowCardNumber : MonoBehaviour
{
    [SerializeField]
    Transform numbers;

    GameObject[,] numberList = new GameObject[4,13];
    
    //親オブジェクトから子オブジェクトを配列に突っ込む
    public void StartNumberInit()
    {
        for (int i1 = 0; i1 < 4; i1++)
        {
            Transform numberParent = numbers.GetChild(i1);
            for (int i2 = 1; i2 < 14; i2++)
            {
                numberList[i1,i2-1] = numberParent.GetChild(i2).gameObject;
            }
        }
        SetActiveAll();
    }

    /// <summary>
    /// 全ての画像を一気に表示するもの
    /// </summary>

    void SwitchActiveAll(bool active)
    {
        for (int i1 = 0; i1 < 4; i1++)
        {
            for (int i2 = 1; i2 < 14; i2++)
            {
                numberList[i1, i2 - 1].SetActive(active);
            }
        }
    }

    public void SetActiveAll()
    {
        SwitchActiveAll(true);
    }
    public void SetNotActiveAll()
    {
        SwitchActiveAll(false);
    }


    /// <summary>
    /// 個別に画像を表示するところ
    /// </summary>

    void SwitchActive(CardTypeEnum.CardType type, int number,bool active)
    {
        //種類は四種類あります
        if (type == CardTypeEnum.CardType.None)
        {
            Debug.LogError("カードタイプがおかしいです:" + type);
            return;
        }
        int typeNumber = (int)type - 1;


        //数字は1～13で存在しているので配列用に切り替えます
        number -= 1;
        //カードの枚数が最大13枚です
        if (number < 0 || number > 13)
        {
            Debug.LogError("数字がおかしいです:" + number);
            return;
        }
        numberList[typeNumber, number].SetActive(active);
    }

    //番号を復活させる
    public void PlaybackNumber(CardTypeEnum.CardType type, int number)
    {
        SwitchActive(type, number,true);
    }
    //番号を消したいときにわかりやすく
    public void UseNumber(CardTypeEnum.CardType type,int number)
    {
        SwitchActive(type, number, false);
    }
}
