using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// いわゆるデッキ
/// シャッフルはせずにランダムで値を決めている
/// </summary>
public class CardManager : MonoBehaviour
{
    List<ObjCardData.CardData> cardlist　= new List<ObjCardData.CardData>();

    [SerializeField]
    bool debug = false;
    public void CreateCardDate()
    {
        for (int type = 1; type < 5; type++)
        {
            CardTypeEnum.CardType cardType = (CardTypeEnum.CardType)type;
            for (int number = 1; number < 14; number++)
            {
                cardlist.Add(new ObjCardData.CardData(number, cardType));
            }
        }
    }
    /// <summary>
    /// デバッグ用
    /// </summary>
    public void Debug_CreateCardDate()
    {
        {
            CardTypeEnum.CardType cardType = (CardTypeEnum.CardType)1;
            for (int number = 1; number < 14; number++)
            {
                cardlist.Add(new ObjCardData.CardData(number, cardType));
            }
        }
        {
            CardTypeEnum.CardType cardType = (CardTypeEnum.CardType)2;
            for (int number = 13; number >0; number--)
            {
                cardlist.Add(new ObjCardData.CardData(number, cardType));
            }
        }
        {
            CardTypeEnum.CardType cardType = (CardTypeEnum.CardType)3;
            for (int number = 1; number < 14; number++)
            {
                cardlist.Add(new ObjCardData.CardData(number, cardType));
            }
        }
        {
            CardTypeEnum.CardType cardType = (CardTypeEnum.CardType)4;
            for (int number = 13; number > 0; number--)
            {
                cardlist.Add(new ObjCardData.CardData(number, cardType));
            }
        }

    }


    //配列の中身をすべて消す
    public void DeleteCardDate()
    {
        if (cardlist.Count != 0) cardlist.Clear();
    }

    //カードを引く(必ずランダムで引かれる
    public ObjCardData.CardData GetDrawCard()
    {
        if (cardlist.Count == 0)
        {
            Debug.LogWarning("もう中身がないよ");
            return null;
        }

        int i = 0;
        if(!debug)i = Random.Range(0, cardlist.Count);
        ObjCardData.CardData data = cardlist[i];
        cardlist.RemoveAt(i);

        return data;
    }
    //残りのカード枚数
    public int GetTicketsRemainingNumber()
    {
        return cardlist.Count;
    }
}

