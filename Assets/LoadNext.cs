using System.Threading.Tasks;
using UnityEngine;
using Wanderer.NSUI.Overlay;
using Wanderer.NSUI.Screen;

namespace Wanderer
{
    public class LoadNext : MonoBehaviour
    {
        [SerializeField] GameObject destrotMap;
        [SerializeField] GameObject nextMap;
        [SerializeField] PlayerController playerController;
        PlayerResetPos playerResetPos;
        bool isMove;

        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            playerResetPos = FindObjectOfType<PlayerResetPos>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ShowLevelChanger();
                playerController.isTeleported = true;
                playerController.transform.position = new Vector3(0, 0, -15f);
                destrotMap.SetActive(false);
                nextMap.SetActive(true);
                playerResetPos.isMove = true;
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
