using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    //最大Scoreと現在のScore。
    //int maxScore = 4;
    int currentScore;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを０にする。
        slider.value = 0;
        //現在のScoreを0に
        currentScore = 0;
        Debug.Log("Start currentHp : " + currentScore);
    }

    private void Update()
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        slider.value = MV.Bcnt;
        if (MV.Bcnt >= 10)
        {
            slider.maxValue = 50;
        }
        if (MV.Bcnt >= 50)
        {
            slider.maxValue = 100;
        }

    }
    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider t)
    {
        Debug.Log("ok");
        //Enemyタグのオブジェクトに触れると発動
        if (t.gameObject.tag == "enemy")
        {

            //int add = 10;

        //現在のScoreに足す
        //currentScore += add;
            Debug.Log("After currentScore : " + currentScore);

            //最大Scoreにおける現在のScoreをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            //slider.value = (float)currentScore / (float)maxScore; ;
            //slider.value = currentScore;
            
            Debug.Log("slider.value : " + slider.value);
            //slider.value = currentScore;
       }
    }
}