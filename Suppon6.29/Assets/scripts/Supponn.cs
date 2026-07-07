using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Supponn : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CapsuleCollider cd;
    [SerializeField] private int moveSpeed,spr;//移動速度,すっぽん落下速度
    [SerializeField] public int Bcnt;//大きくなるカウント
    [SerializeField] public float Bw;//大きさ
    [HideInInspector] public bool up;//上昇
    [HideInInspector] public bool NM;//動けなくする
    private int NMcnt;//動けない時間
    [HideInInspector] public float playerX, playerZ;//プレイヤーの座標を保存
    [SerializeField] public Vector3 Npos; //最初の座標
    // Start is called before the first frame update
    void Start()
    {
        up = false;
        Npos = transform.position;//最初のy座標
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //大きさを変えるプログラム
        if (Bcnt >= 10)
        {
            if (Bw < 0.1f)
            {
                Bw = Bw + 0.01f;
                this.transform.localScale = new Vector3(this.transform.localScale.x + Bw, this.transform.localScale.y + Bw, +this.transform.localScale.z + Bw);
                Npos =new Vector3(Npos.x, Npos.y+Bw*3,Npos.z);
            }
        }
        if(Bcnt >= 50)
        {
            if (Bw < 0.2f)
            {
                Bw = Bw + 0.01f;
                this.transform.localScale = new Vector3(this.transform.localScale.x + Bw, this.transform.localScale.y + Bw, +this.transform.localScale.z + Bw);
                Npos = new Vector3(Npos.x, Npos.y + Bw * 3, Npos.z);
            }
        }

        if (NM == false)//移動できる状態か
        {
            //スッポンの移動
            if (Input.GetKey(KeyCode.Space))//すっぽん落下
            {
                rb.velocity = new Vector3(0, -spr, 0);
            }
            else//すっぽん上昇
            {
                if (transform.position.y < Npos.y && up == true)//現在のY座標が最初のY座標より小さい時
                {
                    rb.velocity = new Vector3(rb.velocity.x, spr, rb.velocity.z);//上方向に力を加える
                }
                else if (up == true)
                {//Y座標が最初のY座標と同じになったら
                    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);//上方向への力を無くす
                    up = false;
                }
                if (transform.position.y > Npos.y && up == true)
                {
                    this.transform.position = new Vector3(transform.position.x, Npos.y, transform.position.z);
                }
                //移動
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                {
                    rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxisRaw("Vertical") * moveSpeed);//移動 
                }
            }
        }

        if (NM == true)
        {
            NMcnt+=1;
            Debug.Log(NMcnt);
            if (NMcnt == 50)
            {
                NMcnt = 0;
                NM = false;
                //gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        //現在の座標を保存
        playerX = transform.position.x;
        playerZ = transform.position.z;
    }
    void OnCollisionEnter(Collision CD)
    {
        if (CD.gameObject.tag == "ground")
        {
            up = true;
        }
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "balet")
        {
            NM = true;//動けなくする
            Debug.Log("hit");
            rb.velocity = Vector3.zero;
            //gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        Debug.Log(Bcnt);
    }
}
