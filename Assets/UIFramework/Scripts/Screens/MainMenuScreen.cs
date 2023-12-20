using UISystem;
using Screen = UISystem.Screen;

namespace Games.UI
{
	public class MainMenuScreen : Screen
	{

		//unity callbacks
		public override void Awake()
		{
			base.Awake();
		}

		//public methods
		public void OnClickSettings()
		{
			ViewController.instance.ChangeView(ScreenName.SettingsScreen);
		}

		public void OnClickPause()
		{
			ViewController.instance.ShowPopup(PopupName.PausePopup);
		}

		public void OnClickLoading()
		{
			ViewController.instance.ShowLoading(); // why not using ShowPopup(popupName var)
		}

		//Controller Callbacks
		public override void Show()
		{
			base.Show();
		}
		public override void Hide()
		{
			base.Hide();
		}
		public override void Disable()
		{
			base.Disable();
		}
		public override void Redraw()
		{
			base.Redraw();
		}

	}
}
