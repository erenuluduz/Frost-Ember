using System;
using System.Collections;
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
        public GameObject player;
        private Rigidbody2D rb;
        public Image blackScreen;
        private float fadeDuration = 2f;
        private float currentSpeed = 500f;
        
        public Button attackButtonOn;
        public Button attackButtonOff;
        public Button dashButtonOn;
        public Button dashButtonOff;
        
        private void Start()
        {
            blackScreen.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                blackScreen.gameObject.SetActive(false);
            });
            
            
            player = GameObject.FindGameObjectWithTag("Player");
            rb = player.GetComponent<Rigidbody2D>();
        }
            
        public void OnLevelComplete()
        {
            var levelObject = LevelObject.Instance;

            levelObject.UnlockedLevel();
        }

        private void Update()
        {
            rb.MovePosition(rb.position + new Vector2(fixedJoystick.Horizontal,fixedJoystick.Vertical) * currentSpeed * Time.deltaTime);
            Debug.Log("joystick v" + fixedJoystick.Vertical + "horiz: "+ fixedJoystick.Horizontal);
        }
    }
}
