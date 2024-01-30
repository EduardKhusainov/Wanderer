using UnityEngine;
using Wanderer.NSUI.Overlay;
using Wanderer.NSUI.Screen;

namespace Wanderer
{
    public class LoadNext : MonoBehaviour
    {
        [SerializeField] GameObject[] maps;
        [SerializeField] PlayerController playerController;
        PlayerResetPos playerResetPos;
        int currentIndex;
        bool isMove;

        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            playerResetPos = FindObjectOfType<PlayerResetPos>();
            currentIndex = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ShowLevelChanger();
                maps[currentIndex].SetActive(false);
                currentIndex++;
                maps[currentIndex].SetActive(true);
                playerController.isTeleported = true;
                playerController.transform.position = new Vector3(0, 0, -15f);
                playerResetPos.isMove = true;
                this.gameObject.SetActive(false);
                FindObjectOfType<BuffScreen>().isBuffed = true;
            }
        }

        private async void ShowLevelChanger()
        {
            var canvas = FindObjectOfType<LevelChangeOverlay>();
            var fadeDelay = 1f;

            canvas.Show(true, fadeDelay);

            await canvas.PlayAnimationAsync();
            canvas.Show(false, fadeDelay);
        }
    }
}