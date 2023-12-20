using UISystem;

namespace Games.UI
{
	public class InitScreen : UISystem.Screen
	{
		//unity callbacks
		public override void Awake()
		{
			base.Awake();
		}

		//public methods


		//Controller Callbacks
		public override void Show()
		{
			base.Show();
			ViewController.instance.ChangeView(ScreenName.MainMenuScreen);
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
