// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;

namespace MabiLib.Network.Packets.Login
{
	public abstract class ClientIdentPacket<TClient> : IPacketHandlerSender<TClient> where TClient : IPacketSender
	{
		public void Parse(TClient client, Packet packet)
		{
			var unkByte = packet.GetByte();
			var ident = packet.GetString();

			// [180x00] Added some time in G18
			var unkInt = packet.GetInt();
			var accountName1 = packet.GetString(); // sometimes empty?
			var accountName2 = packet.GetString();
			// [/180x00]

			this.Handle(client, unkByte, ident, unkInt, accountName1, accountName2);
		}

		public virtual void Handle(TClient client, byte unkByte, string ident, int unkInt, string accountName1, string accountName2)
		{
			throw new NotImplementedException();
		}

		public static void Send(IPacketReceiver receiver, byte unkByte, string ident, int unkInt, string accountName1, string accountName2)
		{
			var packet = new Packet(Op.ClientIdent, 0);
			packet.PutByte(unkByte);
			packet.PutString(ident);
			packet.PutInt(unkInt);
			packet.PutString(accountName1);
			packet.PutString(accountName2);

			receiver.Send(packet);
		}
	}
}
