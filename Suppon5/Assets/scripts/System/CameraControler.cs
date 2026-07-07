using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private bool i;
    [SerializeField] private float x, y, z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        //大きさをすっぽんに合わせる
        this.transform.localScale = new Vector3(MV.transform.localScale.x, MV.transform.localScale.y, MV.transform.localScale.z);
        if (MV.NM == false)//被弾していない時だけ動かす（カメラが振動しなくなってしまうから）
        {
            //現在の座標をすっぽんに合わせる
            this.transform.position = new Vector3(MV.transform.position.x + x, MV.Npos.y * y, MV.transform.position.z + MV.Npos.y * z);
        }
    }
}