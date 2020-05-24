using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.ID;
using Terraria;

namespace AnglerPlusPlus
{
	public class AnglerPlusPlus : Mod
	{
		private static AnglerPlusPlus instance;
		public static AnglerPlusPlus Instance { get { return instance; } }

		private GameTime _lastUpdateUiGameTime;
		private AnglerShop shop;
		private bool isShopOpen = false;

		internal UserInterface userInterface;
		internal AnglerUI ui;

		public override void Load() {
			if (!Main.dedServ) {

				instance = this;
				shop = new AnglerShop();

				userInterface = new UserInterface();

				ui = new AnglerUI();
				ui.Activate();
				userInterface.SetState(ui);
			}
		}

		public override void UpdateUI(GameTime gameTime) {
			_lastUpdateUiGameTime = gameTime;

			if (Main.LocalPlayer.talkNPC > 0 && Main.npc[Main.LocalPlayer.talkNPC].type == NPCID.Angler && !isShopOpen) {
				if (userInterface.CurrentState == null)
					userInterface.SetState(ui);

				if (userInterface?.CurrentState != null) {
					userInterface.Update(gameTime);
				}
			} else {
				userInterface.SetState(null);
			}

			if (Main.LocalPlayer.talkNPC <= 0)
				isShopOpen = false;
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text")); // Vanilla: Mouse Text
			if (mouseTextIndex != -1) {
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"AnglerPlus: Shop",
					delegate {
						if (_lastUpdateUiGameTime != null && userInterface?.CurrentState != null) {
							userInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
						}
						return true;
					},
					   InterfaceScaleType.UI));
			}
		}

		public void SetupAnglerShop() {
			shop.ShowShop();
			userInterface.SetState(null);
			isShopOpen = true;
		}
	}
}