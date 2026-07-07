using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private float height;
    public float SS;//影の大きさ
    void Start()
    {
        height = this.transform.lossyScale.y;
    }
    // Update is called once per frame
    void Update()
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        this.transform.localScale = new Vector3(MV.transform.localScale.x*SS,height,MV.transform.localScale.z*SS);
        this.transform.position = new Vector3(MV.transform.position.x, this.transform.position.y, MV.transform.position.z);
    }
}
