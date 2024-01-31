using System.Collections;
using UnityEngine;
using Wanderer.NSUI.Overlay;
using Wanderer.NSUI.Screen;

namespace Wanderer
{
    public class LoadNext : MonoBehaviour
    {
        [SerializeField] GameObject[] maps;
        [SerializeField] PlayerController playerController;
        PlayerHealth playerHealth;
        PlayerResetPos playerResetPos;
        public int currentIndex;
        public GameObject allMaps;
        Magnet magnet;
        private void Start()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            playerController = FindObjectOfType<PlayerController>();
            playerResetPos = FindObjectOfType<PlayerResetPos>();
            currentIndex = 0;
            magnet = FindObjectOfType<Magnet>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && currentIndex < maps.Length - 1)
            {
                ShowLevelChanger();
                maps[currentIndex].SetActive(false);
                currentIndex++;
                maps[currentIndex].SetActive(true);
                playerController.isTeleported = true;
                playerController.transform.position = new Vector3(0, 0, -15f);
                playerResetPos.isMove = true;
                magnet.isArenaCleaned = false;
                this.gameObject.SetActive(false);
            }
        }

        private async void ShowLevelChanger()
        {
            var canvas = CanvasManager.Instance.SetCanvases[2].GetComponent<LevelChangeOverlay>();
            var fadeDelay = 1f;

            canvas.Show(true, fadeDelay);

            await canvas.PlayAnimationAsync();
            canvas.Show(false, fadeDelay);
        }

    }
}