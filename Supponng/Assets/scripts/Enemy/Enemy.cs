using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private BoxCollider BC;
    [SerializeField] private int Scnt;
    [SerializeField] private int MoveLenge;//動き出す範囲
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    float countdown = 3f;
    int count;
    void FixedUpdate()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
        }

        if (countdown <= 0)
        {
            Supponn MV;//呼ぶスクリプトにあだ名をつける
            GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
            MV = obj.GetComponent<Supponn>();//スクリプトを取得
            Vector3 Pvec = new Vector3(MV.playerX, transform.position.y, MV.playerZ);//プレイヤーの座標を保存
            Vector3 vec = Pvec - this.transform.position;//プレイヤーの位置から敵の位置を引く
            if (MoveLenge > vec.magnitude)
            {
                if (MV.Bcnt >= MV.big2)//スッポンの大きさが10以上だとboxcolliderのistriggerが有効
                {
                    BC.isTrigger = true;
                }
                else
                {
                    BC.isTrigger = false;
                    Scnt = Scnt + 1;
                    if (Scnt % 100 == 0)
                    {
                        Instantiate(Bullet, this.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
                        Scnt = 0;
                    }
                }
            }

        }
    }

    void OnTriggerEnter(Collider t)
    {
        Supponn MV;//呼ぶスクリプトにあだ名をつける
        GameObject obj = GameObject.Find("suppon");//Circleというゲームオブジェクトを探す
        MV = obj.GetComponent<Supponn>();//スクリプトを取得
        if (t.gameObject.tag == "Player")
        {
            MV.Bcnt += 1;
            Destroy(this.gameObject);
        }
        if (t.gameObject.tag == "Player" && MV.Bcnt >= MV.big2)
        {
            MV.Bcnt += 10;
            Destroy(this.gameObject);
        }
    }
}
