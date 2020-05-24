using Terraria;
using Terraria.ModLoader;

namespace AnglerPlusPlus {
	class Player : ModPlayer {

		public override void PostUpdate() {
			if (Main.anglerQuestFinished == true) {
				Main.anglerWhoFinishedToday.Remove(Main.player[Main.myPlayer].name);
				Main.anglerQuestFinished = false;

				Main.anglerQuest = Main.rand.Next(0, Main.anglerQuestItemNetIDs.Length);
			}
		}
	}
}
