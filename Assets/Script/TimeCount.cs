//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class TimeCount : MonoBehaviour
//{
//    //カウントアップ
//    private float countup = 0.0f;

//    //タイムリミット
//    public float timeLimit = 5.0f;

//    //時間を表示するText型の変数
//    public TMP_Text timeText;

//    // Update is called once per frame
//    void Update()
//    {
//        //時間をカウントする
//        if (timeText != null)
//        {
//            timeText.text = countup.ToString("f1") + "秒";
//        }

//        //時間を表示する
//        timeText.text = countup.ToString("f1") + "秒";

//        if (countup >= timeLimit)
//        {
//            timeText.text = "時間になりました！";
//        }
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//public class TimeCount : MonoBehaviour
//{
//    // カウントアップ
//    private float countup = 0.0f;
//    // タイムリミット（秒）
//    public float timeLimit = 5.0f;
//    // 画面に表示する Text (TextMeshPro)
//    public TMP_Text timeText;
//    void Update()
//    {
//        // 時間をカウントする
//        countup += Time.deltaTime;
//        // 時間を表示する（小数1桁）
//        if (timeText != null)
//        {
//            timeText.text = countup.ToString("f1") + "秒";
//        }
//        // リミットを超えたらメッセージ
//        if (countup >= timeLimit && timeText != null)
//        {
//            timeText.text = "時間になりました！";
//            // 一度だけにしたい場合は次の1行を有効化
//            // enabled = false;
//        }
//    }
//}
//using UnityEngine;
//using TMPro;
//public class TimeCountDown : MonoBehaviour
//{
//    public float startSeconds = 60f;  // 開始秒
//    public TMP_Text timeText;
//    float remaining;
//    void Awake()
//    {
//        remaining = startSeconds;
//        UpdateLabel();
//    }
//    void Update()
//    {

//        //Debug.Log($"dt={Time.deltaTime}, ts={Time.timeScale}");
//        remaining -= Time.deltaTime;
//        if (remaining <= 0f)
//        {
//            remaining = 0f;
//        }
//        UpdateLabel();
//        // 0で止めたいなら
//        // if (remaining <= 0f) enabled = false;

//    }
//    void UpdateLabel()
//    {
//        if (timeText == null) return;
//        // mm:ss
//        int sec = Mathf.CeilToInt(remaining);
//        int m = sec / 60;
//        int s = sec % 60;
//        timeText.text = $"{m:00}:{s:00}";
//    }
//}
using System;
using UnityEngine;
using TMPro;
using System;

public class TimeCount : MonoBehaviour
{
    public int countdownMinutes = 3; // 制限時間（分）
    private float countdownSeconds; // 残り秒数
    private TextMeshProUGUI timeText; // 表示用テキスト

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        countdownSeconds = countdownMinutes * 60; // 分を秒に変換
    }

    private void Update()
    {
        countdownSeconds -= Time.deltaTime; // 毎フレーム経過時間を減算
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss"); // mm:ss形式で表示

        if (countdownSeconds <= 0)
        {
            // カウントダウン終了時の処理
            timeText.text = "00:00";
            enabled = false; // Update停止
        }
    }
}
