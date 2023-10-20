using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text recordText;
    
    void Start()
    {
        if(PlayerPrefs.HasKey("Record"))
        {
            recordText.text = $"High Score: {PlayerPrefs.GetInt("Record")}";
        }
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
   
}
