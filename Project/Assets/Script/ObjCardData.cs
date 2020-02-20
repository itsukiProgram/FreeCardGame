using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// new出来ないコンポーネント用
/// </summary>
public class ObjCardData : MonoBehaviour
{
    /// <summary>
    /// newする変数用
    /// </summary>
    public class CardData
    {
        /// <summary>
        /// 数字を表す
        /// </summary>
        public int number = 0;

        /// <summary>
        /// カードタイプ
        /// </summary>
        public CardTypeEnum.CardType type = CardTypeEnum.CardType.None;

        public CardData()
        {
            DataInit();
        }

        public CardData(int number_, CardTypeEnum.CardType type_)
        {
            number = number_;
            type = type_;
        }

        public void DataInit()
        {
            number = 0;
            type = CardTypeEnum.CardType.None;
        }
    }


    public CardData cardData;


    public ObjCardData()
    {
        cardData = new CardData();
    }

    public ObjCardData(int number, CardTypeEnum.CardType type)
    {
        cardData = new CardData(number, type);
    }

    public ObjCardData(CardData data_)
    {
        cardData = new CardData(data_.number, data_.type);
    }
    public void DataInit()
    {
        cardData.DataInit();
    }
}
