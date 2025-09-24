using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    // 시간이 흐르다가 목표시간이 되면 결과UI를 보이게 하고싶다. TimeScale을 0으로 하고싶다.
    public static ResultManager instance;
    float curTime;
    public float limitTime = 3;
    public GameObject resultUI;
    public TextMeshProUGUI textTime;

    private void Awake()
    {
        instance = this;
        resultUI.SetActive(false);
    }

    void Start()
    {

    }

    void Update()
    {
        // 만약 결과UI가 보여지고 있다면 함수를 바로 종료하고싶다.
        if (resultUI.activeSelf)
            return;

        // 시간이 흐르다가
        curTime += Time.deltaTime;

        int time = (int)(limitTime - curTime);
        textTime.SetText(time.ToString() + "s");

        // 현재시간이 제한시간이 되면
        if (curTime >= limitTime)
        {
            textTime.SetText("0s");
            ShowResultUI();
        }
    }

    public void ShowResultUI()
    {
        // resultUI를 보이게하고
        resultUI.SetActive(true);
        // 시간을 멈추고싶다.
        Time.timeScale = 0;
    }


    public void OnClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickQuit()
    {
        // 에디터상태인가?
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        // 그렇지 않은가?
        Application.Quit();
#endif
    }
}

