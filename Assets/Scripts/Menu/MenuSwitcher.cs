using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnniePlaysGamesTestTask.Menu
{
    public class MenuSwitcher : MonoBehaviour
    {
        private List<MenuDisplay> _menus;
        [SerializeField] Joystick joystick;

        private void Start()
        {
            _menus = GetComponentsInChildren<MenuDisplay>().ToList();
        }

        public void ShowPauseMenu()
        {
            joystick.gameObject.SetActive(false);
            ShowMenu(MenuType.Pause);
        }

        public void ShowVictoryMenu()
        {
            joystick.gameObject.SetActive(false);
            ShowMenu(MenuType.Victory);
        }

        public void ShowLossMenu()
        {
            joystick.gameObject.SetActive(false);
            ShowMenu(MenuType.Loss);
        }

        public void ShowRuntimeMenu()
        {
            joystick.gameObject.SetActive(true);
            ShowMenu(MenuType.Runtime);
        }

        public void ShowMenu(MenuType menuType)
        {
            _menus.ForEach(x => x.HideContent());
            MenuDisplay menu = _menus.Find(x => x.MenuType == menuType);
            menu.ShowContent();
        }
    }
}
