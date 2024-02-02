using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;
using TMPro;

namespace DShon {

    public class AboutUsLink : MonoBehaviour
    {
        /*[SerializeField]
        TextMeshProUGUI text;

        string link = "https://trello.com/b/vxe2NMm3/wanderer";
        void Start ()
        {
            text.text = "Autor link:" + link;
        }*/
        public void FollowLink(string folowingLink)
        {
            Application.OpenURL(folowingLink);
        }
    }

}
