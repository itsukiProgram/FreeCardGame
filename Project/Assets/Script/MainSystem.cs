using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainSystem : MonoBehaviour
{
    [SerializeField]
    CardManager cardManager;

    [SerializeField]
    UnderCardManager u_cardManager;

    [SerializeField]
    ShowCardNumber showCardNumber;

    [SerializeField]
    GameObject win;
    [SerializeField]
    GameObject lose;

    [SerializeField]
    bool debug = false;

    //ここに全て持ってきてスタートの順番を制御する
    void Start()
    {
        if(debug) 
        {
            cardManager.Debug_CreateCardDate();
        }
        else
        {
            cardManager.CreateCardDate();
        }
        u_cardManager.StartCardDraw();
        showCardNumber.StartNumberInit();
    }
    //ゲーム終了関数
    public void GameEnd()
    {
        #if UNITY_EDITOR//UnityEditerを閉じる分岐
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE//exeにしたときにゲームを閉じる分岐
              UnityEngine.Application.Quit();
        #endif
    }
    //これを読んだらすべてがリセットされて再スタート
    public void ReStart()
    {
        cardManager.DeleteCardDate();
        u_cardManager.ResetCard();
        if (debug)
        {
            cardManager.Debug_CreateCardDate();
        }
        else
        {
            cardManager.CreateCardDate();
        }
        u_cardManager.StartCardDraw();
        showCardNumber.SetActiveAll();
        win.SetActive(false);
        lose.SetActive(false);
    }
    //勝利したときwinのキャンバスをtrueにして表示する
    public void Win()
    {
        win.SetActive(true);
    }
    //敗北したときLoseのキャンバスをtrueにして表示する
    public void Lose()
    {
        lose.SetActive(true);
    }
}
/*

    カードを生成する
    カードを混ぜる
    カードを配る

    枠を動かして選択させる
    選択したら画像とデータを移して
    カードを引く

    下のカードを毎回確認して
    カードが全部残っているか
    カードが全部重ねることが出来るか
    を判定
 */