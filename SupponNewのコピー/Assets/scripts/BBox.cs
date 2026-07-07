using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class BBox : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private BoxCollider BC;
    [SerializeField] private int speed, longe;
    [SerializeField] private float esc;
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
        Vector3 Pvec = new Vector3(MV.playerX, transform.position.y, MV.playerZ);//プレイヤーの座標を保存
        Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
        vec = vec.normalized;//正規化
        RB.velocity = vec * -esc;//スピードをかける
        //当たり判定の設定
        if (MV.Bcnt >= 10)//スッポンの大きさが10以上だとboxcolliderのistriggerが有効
        {
            BC.isTrigger = true;
        }
        else
        {
            BC.isTrigger = false;
        }
    }

    void OnTriggerEnter(Collider t)
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        if (t.gameObject.tag == "Player"&&MV.Bcnt>=10)
        {
            MV.Bcnt += 5;
            Destroy(this.gameObject);
        }
    }
}