using Terraria;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;

namespace AnglerPlusPlus {
	class AnglerUI : UIState {

		const int MAX_TEXT = 10;
		private UIPanel panel = new UIPanel();
		private UIText questsText = new UIText("Completed Quests: ");
		private UITextButton button = new UITextButton("Shop", OnButtonClick);

		public static void OnButtonClick() {
			AnglerPlusPlus.Instance.SetupAnglerShop();
		}

		public override void OnInitialize() {
			panel.HAlign = 0.5f;
			panel.Top.Set(100.0f, 0.0f);
			panel.BackgroundColor = Color.Transparent;
			panel.BorderColor = Color.Transparent;
			panel.Append(button);

			panel.Append(questsText);

			Append(panel);
		}

		public override void Update(GameTime gameTime) {
			int size = default(int);
			Utils.WordwrapString(Main.npcChatText, Main.fontMouseText, 460, MAX_TEXT, out size);

			panel.Width.Set(Main.chatBackTexture.Width, 0.0f);
			panel.Height.Set(60 + (size + 1) * 30, 0);

			string text = "Completed Quests: " + Main.LocalPlayer.anglerQuestsFinished.ToString();
			Vector2 length = Main.fontMouseText.MeasureString(text);

			questsText.SetText(text);
			questsText.Left.Set(230, 0.0f);
			questsText.Top.Set((35 + size * 30 + length.Y * 0.5f) + 2, 0);
			questsText.TextColor = new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);

			base.Update(gameTime);
		}
	}
}
