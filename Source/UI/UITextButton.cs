using Terraria;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace AnglerPlusPlus {
	class UITextButton : UIElement {

		private string text;
		private Vector2 textSize;
		private float textScale = 1.0f;
		private readonly float defaultScale = 0.9f;
		private readonly float scaleFactor = 1.1f;

		public delegate void OnButtonClick();
		private OnButtonClick onButtonClick = null;

		public UITextButton(string text, OnButtonClick onButtonClick) : base() {
			this.text = text;

			this.textSize = Main.fontMouseText.MeasureString(text);
			this.Width.Set(textSize.X, 0.0f);
			this.Height.Set(textSize.Y, 0.0f);

			// Set up delegate
			this.onButtonClick += onButtonClick;
		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			int totalLines = default(int);
			Utils.WordwrapString(Main.npcChatText, Main.fontMouseText, 460, 10, out totalLines);

			this.Top.Set(35 + totalLines * 30 + textSize.Y * 0.5f, 0.0f);
			this.Left.Set(160, 0.0f);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch) {
			base.DrawSelf(spriteBatch);

			Color color = new Color(Main.mouseTextColor, (int)((double)Main.mouseTextColor / 1.1), Main.mouseTextColor / 2, Main.mouseTextColor);
			Utils.DrawBorderString(Main.spriteBatch, text, this.GetDimensions().Center(), color, textScale, 0.5f, 0.5f);
		}

		public override void MouseDown(UIMouseEvent evt) {
			base.MouseDown(evt);

			Main.PlaySound(SoundID.MenuTick);
			if (this.onButtonClick != null)
				onButtonClick();
		}

		public override void MouseOver(UIMouseEvent evt) {
			base.MouseOver(evt);

			Main.PlaySound(SoundID.MenuTick);
			textScale = defaultScale * scaleFactor;
		}

		public override void MouseOut(UIMouseEvent evt) {
			base.MouseOut(evt);

			Main.PlaySound(SoundID.MenuTick);
			textScale = defaultScale;
		}
	}
}