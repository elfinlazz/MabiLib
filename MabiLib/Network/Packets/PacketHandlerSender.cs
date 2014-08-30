// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

namespace MabiLib.Network.Packets
{
	public interface IPacketHandlerSender<TClient> where TClient : IPacketSender
	{
		void Parse(TClient client, Packet packet);
	}
}
