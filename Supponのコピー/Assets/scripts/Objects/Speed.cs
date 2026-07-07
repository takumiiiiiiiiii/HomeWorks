using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private BoxCollider BC;
    [SerializeField] private float esc,ecnt;//すっぽんから逃げる速度,
    private int Mcnt;//移動カウント
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mcnt == ecnt){
            Mcnt = 0;
            Supponn MV;//呼ぶスクリプトにあだ名をつける
            GameObject obj = GameObject.Find("Cylinder");//Circleというゲームオブジェクトを探す
            MV = obj.GetComponent<Supponn>();//スクリプトを取得
            Vector3 Pvec = new Vector3(MV.playerX, transform.position.y, MV.playerZ);//プレイヤーの座標を保存
            Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
            vec = vec.normalized;//正規化
            RB.velocity = vec * esc;//スピードをかける
        }
        Mcnt++;
    }

    void OnTriggerEnter(Collider t)//すっぽんに接触したら破壊
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("Cylinder");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        if (t.gameObject.tag == "Player"&&MV.up!=true)
        {
            MV.Bcnt +=3;
            Destroy(this.gameObject);
        }
    }
}
