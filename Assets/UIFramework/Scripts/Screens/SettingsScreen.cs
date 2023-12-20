using UISystem;
using Screen = UISystem.Screen;

namespace Games.UI
{
	public class SettingsScreen : Screen
	{
		//unity callbacks
		public override void Awake()
		{
			base.Awake();
		}

		//public methods
		public void OnClickClose()
		{
			ViewController.instance.ChangeView(ScreenName.MainMenuScreen);
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
