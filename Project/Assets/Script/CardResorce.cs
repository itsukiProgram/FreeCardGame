using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リソースファイルからマテリアルデータを持ってくる
/// </summary>
public class CardResorce : MonoBehaviour
{
    public Material GetCardSprite(int number, CardTypeEnum.CardType type)
    {
        if (number == 0 || type == CardTypeEnum.CardType.None) return null;

        string s_type = "";

        switch (type)
        {
            case CardTypeEnum.CardType.spade:
                s_type = "Spade";
                break;
            case CardTypeEnum.CardType.heart:
                s_type = "Heart";
                break;
            case CardTypeEnum.CardType.Clover:
                s_type = "Club";
                break;
            case CardTypeEnum.CardType.Diamond:
                s_type = "Diamond";
                break;
            default:
                break;
        }
        Material material = Resources.Load<Material>("CardMaterial/" + "Card"+ s_type + number.ToString());
        return material;
    }
}
