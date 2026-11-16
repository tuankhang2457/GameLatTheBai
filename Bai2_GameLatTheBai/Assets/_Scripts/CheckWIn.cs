using UnityEngine;
using TMPro;

public class CheckWIn : MonoBehaviour
{
    public TextMeshProUGUI DoneScore;

    protected int doneScore = 0;
    protected int MaxScore = 12;
    public static CheckWIn instance;

    private void Awake()
    {
        if (CheckWIn.instance != null) return;
        CheckWIn.instance = this;
    }

    public void UpdateDoneScore()
    {
        doneScore++;
        DoneScore.text = "Số Cặp Đã Hoàn Thành: " + doneScore + "/" + MaxScore;
        if (doneScore == MaxScore)
        {
            Debug.Log("Ban Da Chien Thang!");
            Time.timeScale = 0f;
        }

    }
}
