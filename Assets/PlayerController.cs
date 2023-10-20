using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private bool GameStarted = false;
    [SerializeField]
    CanvasGroup startGroup;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    CanvasGroup looseGroup;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text highScoreText;
    private int Score;
    private bool toJump;
    [SerializeField]
    private ObstacleController obstacleController;
    // Start is called before the first frame update
    [SerializeField]
    private float jumpForce;
    private Rigidbody2D rb;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("Record")}";
        obstacleController.SetObstaclesSpeed(0);
    }
    public void StartGame()
    {
        toJump = true;
        obstacleController.SetObstaclesSpeed(3);

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
    }
    void Update()
    {
        if(GameStarted)
        {
            if (toJump)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    rb.angularVelocity = 0;
                    rb.AddTorque(Random.Range(-20, 20));
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                HideStartGroup();
                GameStarted = true;
                rb.gravityScale = 1;
                SetToJump(true);
                obstacleController.SetObstaclesSpeed(3);
            }
        }
       
          
    }
    public void HideStartGroup()
    {
        startGroup.alpha = 0;
        startGroup.interactable = false;
        startGroup.blocksRaycasts = false;
    }    
    public void ShowGroup()
    {
        looseGroup.alpha = 1;
        looseGroup.interactable = true;
        looseGroup.blocksRaycasts = true;
    }
    public void SetToJump(bool value)
    {
        toJump = value;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        obstacleController.SetObstaclesSpeed(0);
        SetToJump(false);
        ShowGroup();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Obstacle>().GetHitted() == false)
        {
            if (toJump)
            {
                other.gameObject.GetComponent<Obstacle>().SetHitted(true);
                print("Add");
                source.Play();
                Score++;
                scoreText.text = $"Score: {Score}";
                if (Score > PlayerPrefs.GetInt("Record"))
                {
                    highScoreText.text = $"High Score: {Score}";
                    PlayerPrefs.SetInt("Record", Score);
                    PlayerPrefs.Save();

                }
            }
            
        }
           
    }


    private void Jump()
    { 
    
    }
}
