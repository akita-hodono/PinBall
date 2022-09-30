using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //得点（Score）を初期化
    private int score = 0;

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点を表示するテキスト
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のscoreTextを取得
        this.scoreText = GameObject.Find("Score");

        //スタート時にスコアを表示する
        this.scoreText.GetComponent<Text>().text = "SCORE:";

    }

    // Update is called once per frame
    void Update()
    {
        //もしも、ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "LargeStarTag")
        {
            Debug.Log("LargeStarTag hit");
            //スコアを3加算する
            score += 3;

            //ScoreTextにスコア3を表示
            this.scoreText.GetComponent<Text>().text = "SCORE:"+score;  
        }

        if (collision.gameObject.tag == "SmallCloudTag")
        {
            Debug.Log("SmallCloudTag hit");
            //スコアを5加算する

            //ScoreTextにスコア5を表示
            score += 5;
            this.scoreText.GetComponent<Text>().text = "SCORE:" + score;
        }

        if (collision.gameObject.tag == "LargeCloudTag")
        {
            Debug.Log("LargeCloudTag hit");
            //スコアを10加算する

            //ScoreTextにスコア10を表示
            score += 10;
            this.scoreText.GetComponent<Text>().text = "SCORE:" + score;
        }
    }
}




