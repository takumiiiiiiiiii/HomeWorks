using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Box : MonoBehaviour
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
    void FixedUpdate()
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        Vector3 Pvec = new Vector3(MV.playerX,transform.position.y,MV.playerZ);//プレイヤーの座標を保存
        Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
        vec = vec.normalized;//正規化
        RB.velocity = vec * -esc;//スピードをかける
    }

    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Player")
        {
            Supponn MV;//呼ぶスクリプトにあだ名をつける
            GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
            MV = obj.GetComponent<Supponn>();//スクリプトを取得
            MV.Bcnt += 1;
            Destroy(this.gameObject);
        }
    }
}