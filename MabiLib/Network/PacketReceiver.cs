// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

namespace MabiLib.Network
{
	/// <summary>
	/// Represents something that's able to receive a packet.
	/// </summary>
	public interface IPacketReceiver
	{
		void Send(Packet packet);
	}
}
