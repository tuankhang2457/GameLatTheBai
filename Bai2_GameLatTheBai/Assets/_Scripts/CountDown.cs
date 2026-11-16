using UnityEngine;
using TMPro;
using System.Collections;
public class CountDown : MonoBehaviour
{
 [SerializeField] protected TextMeshProUGUI timerText;

 [SerializeField]   protected float totalSeconds = 210f;

    private void Start()
    {
        StartCoroutine(CountDownRoutine());
    }

    IEnumerator CountDownRoutine()
    {
        while(totalSeconds > 0)
        {
            int minutes = Mathf.FloorToInt(totalSeconds / 60);
            int second = Mathf.FloorToInt(totalSeconds % 60);

            timerText.text = string.Format("{00:00}:{1:00}", minutes, second);

            yield return new WaitForSeconds(1f);

            totalSeconds -= 1f;
        }
        timerText.text = "00:00";
        Debug.Log("Ban Da Thua Cuoc");
        Time.timeScale = 0f;
        
    }
}
