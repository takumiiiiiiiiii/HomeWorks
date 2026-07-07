using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private SphereCollider BC;
    [SerializeField] private int speed, longe;
    [SerializeField] private float esc;
    // Start is called before the first frame update
    void Start()
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        Vector3 Pvec = new Vector3(MV.playerX, transform.position.y, MV.playerZ);//プレイヤーの座標を保存
        Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
        vec = vec.normalized;//正規化
        RB.velocity = vec * esc;//スピードをかける
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
