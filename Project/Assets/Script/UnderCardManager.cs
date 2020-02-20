using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 下のカードの
/// </summary>
public class UnderCardManager : MonoBehaviour
{

    /// <summary>
    /// 下のカードたち
    /// </summary>


    MeshRenderer[] undercardImages = new MeshRenderer[5];
    ObjCardData[] undercardDatas = new ObjCardData[5];
    CardRotation[] cardRotations = new CardRotation[5];

    [SerializeField]
    GameObject[] cardObj = new GameObject[5];

    /// <summary>
    /// 上のカード
    /// </summary>

    [SerializeField]
    MeshRenderer upCardImages;
    [SerializeField]
    ObjCardData upCardDatas;

    /// <summary>
    /// ほかのスクリプト
    /// </summary>

    [SerializeField]
    CardManager cardManager;

    [SerializeField]
    ShowCardNumber showCardNumber;

    [SerializeField]
    CardResorce resorce;

    [SerializeField]
    MainSystem mainsystm;

    //画像を透明にするときのマテリアル
    [SerializeField]
    Material transparentMaterial;

    /// <summary>
    /// 子オブジェクトのコンポーネントを取得
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            undercardImages[i] = cardObj[i].GetComponent<MeshRenderer>();
            undercardDatas[i] = cardObj[i].GetComponent<ObjCardData>();
            cardRotations[i] = cardObj[i].GetComponent<CardRotation>();
        }
    }

    /// <summary>
    /// 一気にカードを５枚引く関数
    /// </summary>
    public void StartCardDraw()
    {
        for (int i = 0; i < 5; i++)
        {
            CardDraw(i);
        } 
    }

    /// <summary>
    /// 透明にしてカードのデータを初期化する
    /// </summary>
    public void ResetCard()
    {
        for (int i = 0; i < 5; i++)
        {
            undercardImages[i].material = transparentMaterial;
            undercardDatas[i].DataInit();
        }
        upCardImages.material = transparentMaterial;
        upCardDatas.DataInit();
    }


    /// <summary>
    /// カードを引いて下のマスに入れていく
    /// </summary>
    public void CardDraw(int i)
    {
        //i番目のカードにデータと画像を代入する
        ObjCardData.CardData data = cardManager.GetDrawCard();
        if (data == null)
        {
            undercardImages[i].material = transparentMaterial;
            undercardDatas[i].DataInit();
            Debug.LogWarning("カードが引き終わりました");
            return;
        }
        Material material = resorce.GetCardSprite(data.number, data.type);
        if (material == null )
        {
            Debug.LogError("そんなスプライトデータないよ");
            return;
        }
        undercardImages[i].material = material;
        undercardDatas[i].cardData = data;

        //カードを回転させる
        cardRotations[i].GoRotation();
    }

    /// <summary>
    /// カードについてるボタンから呼び出す関数
    /// </summary>
    public void SelectCard(int i)
    {
        //選択してるカードと上にあるカードとタイプと数字がどっちも違うと中に入る
        if (upCardDatas.cardData.type != undercardDatas[i].cardData.type && upCardDatas.cardData.number != undercardDatas[i].cardData.number)
        {
            Debug.LogError("タイプも数字も違います");
            //上のカードが初期化状態じゃなかったら中に入る
            if (upCardDatas.cardData.type != CardTypeEnum.CardType.None || upCardDatas.cardData.number != 0) 
            {
                Debug.LogError("重ねることが出来ません");
                return;
            }
            Debug.LogError("出す場所が初期値だったので通しました。");
        }

        //上の画像に移動させる
        upCardImages.material = undercardImages[i].material;
        upCardDatas.cardData.number = undercardDatas[i].cardData.number;
        upCardDatas.cardData.type = undercardDatas[i].cardData.type;

        //右上の数字を減らす
        showCardNumber.UseNumber(undercardDatas[i].cardData.type, undercardDatas[i].cardData.number);
        //カードが移動したのでカードを引く
        CardDraw(i);
        //勝敗判定を呼ぶ
        Judgewd();
    }

    //勝敗判定
    public void Judgewd()
    {
        //カードが全部残っているか(勝利判定)
        bool win = true;
        for (int i = 0; i < 5; i++)
        {
            if (undercardDatas[i].cardData.type != CardTypeEnum.CardType.None) win = false;
        }

        if(win)//ゲーム終了　勝利
        {
            mainsystm.Win();
            return;
        }
        //カードが全部重ねることが出来るかを判定(敗北判定)
        bool lose = true;
        for (int i = 0; i < 5; i++)
        {
            if (upCardDatas.cardData.type != undercardDatas[i].cardData.type && 
                upCardDatas.cardData.number != undercardDatas[i].cardData.number) 
            {
                continue;
            }
            lose = false;
        }
        if (lose)//ゲーム終了　敗北
        {
            mainsystm.Lose();
            return;
        }
    }
}
