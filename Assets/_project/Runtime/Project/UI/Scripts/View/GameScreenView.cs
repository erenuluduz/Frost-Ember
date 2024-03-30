using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using _project.Runtime.Core.Singleton;
using _project.Runtime.Core.UI.Scripts.Manager;
using _project.Runtime.Project.Launcher.Scripts.Manager.Bootstrap;
using DG.Tweening;

namespace _project.Runtime.Project.UI.Scripts.View
{
    public class GameScreenView : SingletonBehaviour<GameScreenView>
    {
        public FixedJoystick fixedJoystick;
        public GameObject pauseMenuUI;
        public GameObject countdownUI;
        public TMP_Text countdownText;
        private GameObject player;
        private Rigidbody2D rb;
        public Vector2 move;
        public float dashTimer;

        public GameObject playerBullet;
        public List<GameObject> snowBalls;
        private int emptyClickCount = 0;

        private int bulletSize = 7;
        private float fadeDuration = 2f;
        private float currentSpeed = 5f;
        public bool dashing;

        public GameObject attackButtonOn;
        public GameObject attackButtonOff;
        public Button dashButtonOn;
        public Button dashButtonOff;
        public Button soundButtonOn;
        public Button soundButtonOff;
        public Slider reloadSlider;


        private void Start()
        {
            //blackScreen.DOFade(0f, fadeDuration).OnComplete(() => { blackScreen.gameObject.SetActive(false); });
            
            bulletSize = snowBalls.Count - 1;

            player = GameObject.FindGameObjectWithTag("Player");
            rb = player.GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            move.x = fixedJoystick.Horizontal;
            move.y = fixedJoystick.Vertical;
            rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);
            Debug.Log("x: " + move.x + "y: " + move.y); 
            
            PlayerModel.Instance.animator.SetFloat("Speed",move.x);
            if (move.x == 0)
            {
                PlayerModel.Instance.animator.SetBool("isWalk",false);
            }
            else
            {
                PlayerModel.Instance.animator.SetBool("isWalk",true);

            }
                
        }
        
        public void OnClickOption()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        async Task Countdown(int seconds)
        {
            int counter = seconds;
            while (counter > 0)
            {
                countdownText.text = counter.ToString();
                counter--;
                await Task.Delay(1000); 
            }
            countdownText.text = "GO!";
            await Task.Delay(1000); 

            Time.timeScale = 1f;
            countdownUI.SetActive(false);
        }
        public void OnClickContinue()
        { 
            pauseMenuUI.SetActive(false); 
            countdownUI.SetActive(true);
            _ = Countdown(3); // Asenkron fonksiyonu başlat
        }
        public void OnClickRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }

        public void OnClickSoundsOnOff()
        {
            if (soundButtonOn.gameObject.activeSelf)
            {
                soundButtonOff.gameObject.SetActive(true);
                soundButtonOn.gameObject.SetActive(false);
            }
            else
            {
                soundButtonOff.gameObject.SetActive(false);
                soundButtonOn.gameObject.SetActive(true);
            }
        }

        public async void OnClickMainMenu()
        {
            SceneManager.LoadScene("Launcher");
            var screenManager = ScreenManager.Instance;
            
            await screenManager.OpenScreen(ScreenKeys.MainMenuScreen, ScreenLayerKeys.FirstLayer);
        }
        public async void OnClickSettingsMenu()
        {
            var screenManager = ScreenManager.Instance;
            
            await screenManager.OpenScreen(ScreenKeys.SettingsMenuScreen, ScreenLayerKeys.FirstLayer);
        }
        
        
        
        public void OnClickAttack()
        {
            Debug.Log(bulletSize);

            if (bulletSize > 0)
            {
                Instantiate(playerBullet, player.transform.position, Quaternion.identity);
                snowBalls[bulletSize].SetActive(false);
                bulletSize--;
                emptyClickCount = 0;
            }
            else if (bulletSize <= 0)
            {
                snowBalls[bulletSize].SetActive(false);

                if (emptyClickCount <= 0)
                {
                    attackButtonOn.gameObject.SetActive(false);
                    attackButtonOff.gameObject.SetActive(true);
                    StartCoroutine(SnowBallsActive());
                    StartCoroutine(AttackButtonActive());
                    StartCoroutine(SliderActive());
                    emptyClickCount++;
                }
            }
        }

        IEnumerator SliderActive()
        {
            reloadSlider.gameObject.SetActive(true);
            while (reloadSlider.value < 1f)
            {
                yield return new WaitForSeconds(0.2f);
                reloadSlider.value += 0.1f;
            }

            reloadSlider.value = 1f;
            if (reloadSlider.value == 1f)
            {
                reloadSlider.gameObject.SetActive(false);
                reloadSlider.value = 0f;
            }
        }
        IEnumerator SnowBallsActive()
        {
            foreach (var VARIABLE in snowBalls)
            {
                if (VARIABLE.activeSelf != true)
                {
                    yield return new WaitForSeconds(0.25f);
                    VARIABLE.SetActive(true);
                }
            }
        }
        IEnumerator AttackButtonActive()
        {
            yield return new WaitForSeconds(2);

            attackButtonOn.gameObject.SetActive(true);
            attackButtonOff.gameObject.SetActive(false);
            bulletSize = snowBalls.Count - 1;
        }
        public void OnClickDashing()
        {
                dashButtonOn.gameObject.SetActive(false);
                dashButtonOff.gameObject.SetActive(true);
                //currentSpeed = PlayerModel.Instance.dashSpeed;
                dashing= true;
                //PlayerModel.Instance.invincible = true;
                //PlayerModel.Instance.dashTimer = 1;
        }
        public IEnumerator DashButtonActive()
        {
            yield return new WaitForSeconds(2);
            dashButtonOn.gameObject.SetActive(true);
            dashButtonOff.gameObject.SetActive(false);
        }
        
    }
}

