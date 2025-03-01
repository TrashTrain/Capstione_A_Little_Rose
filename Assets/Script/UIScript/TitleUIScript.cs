using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIScript : MonoBehaviour
{
    private DataManager dataManager;

    private GameObject inputCharacterPanel;
    public GameObject loadingPanel;
    private GameObject mainPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        inputCharacterPanel = 
            GameObject.Find("GameStartUI").transform.Find("InputCharacterNamePanel").gameObject;
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        mainPanel = GameObject.Find("GameStartUI").transform.Find("MainPanel").gameObject;
        mainPanel.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void OnClickNewGameButton()
    {
        inputCharacterPanel.SetActive(true);
    }
    
    public void OnclickStartGameButtonButton()
    {
        GameObject inputText = inputCharacterPanel.transform.Find("InputCharacterNameField").gameObject;
        string characterName = inputText.GetComponent<TMP_InputField>().text;
        
        dataManager.GetComponent<PlayerData>().PlayerName = characterName;
        inputCharacterPanel.SetActive(false);
        // 게임 시작 버튼 누를시 데이터 로드 후 게임 시작
        dataManager.LoadDataManager("Street");
    }

    public void OnClickLoadGameButton()
    {
        // 게임 데이터 로드 이후 
        dataManager.LoadDataManager("LoadGameScene");
    }

    public static void OnClickExitGameButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
