using Terraria;
using Terraria.ID;

namespace AnglerPlusPlus {
	class AnglerShop {

		private Chest shop;

		public void ShowShop() {
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = 20;

			shop = Main.instance.shop[Main.npcShop];
			shop.SetupShop(0);

			int index = 0;

			AddItem(ref shop, ref index, ItemID.ReinforcedFishingPole, 0, 75);
			AddItem(ref shop, ref index, ItemID.ApprenticeBait, 0, 35);
			AddItem(ref shop, ref index, ItemID.JourneymanBait, 0, 0, 1);
			AddItem(ref shop, ref index, ItemID.MasterBait, 0, 50, 3);
			AddItem(ref shop, ref index, ItemID.MonarchButterfly, 0, 10);
			AddItem(ref shop, ref index, ItemID.FishingPotion, 0, 65);
			AddItem(ref shop, ref index, ItemID.CratePotion, 0, 65);
			AddItem(ref shop, ref index, ItemID.SonarPotion, 0, 65);
		}

		private void AddItem(ref Chest shop, ref int index, int itemID, uint copper = 0, uint silver = 0, uint gold = 0, uint plat = 0) {
			shop.item[index].SetDefaults(itemID);
			shop.item[index].shopCustomPrice = (int)((plat * 100000) + (gold * 10000) + (silver * 100) + copper);
			++index;
		}
	}
}
