// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using MabiLib.Network;
using MabiLib.Network.Packets.Login;
using Xunit;

namespace MabiLib.Tests.Network.Packets
{
	public class ClientIdentPacketTests
	{
		[Fact]
		public void ParsingClientIdent()
		{
			var packet = new Packet(Op.ClientIdent, 0);
			packet.PutByte(100);
			packet.PutString("XYZ-TEST123-FOO");
			packet.PutInt(200);
			packet.PutString("user1");
			packet.PutString("user2");

			packet = new Packet(packet.Build(), 0);

			var client = new ClientIdentClient();
			var handler = new ClientIdentPacket();
			handler.Parse(client, packet);
		}

		[Fact]
		public void SendingClientIdent()
		{
			var client = new ClientIdentClient();
			var handler = new ClientIdentPacket();

			ClientIdentPacket.Send(client, 100, "XYZ-TEST123-FOO", 200, "user1", "user2");
		}
	}

	public class ClientIdentPacket : ClientIdentPacket<ClientIdentClient>
	{
		public override void Handle(ClientIdentClient client, byte unkByte, string ident, int unkInt, string accountName1, string accountName2)
		{
			Assert.Equal(unkByte, 100);
			Assert.Equal(ident, "XYZ-TEST123-FOO");
			Assert.Equal(unkInt, 200);
			Assert.Equal(accountName1, "user1");
			Assert.Equal(accountName2, "user2");
		}
	}

	public class ClientIdentClient : IPacketReceiver, IPacketSender
	{
		public void Send(Packet packet)
		{
			packet = new Packet(packet.Build(), 0);

			Assert.Equal(packet.GetByte(), 100);
			Assert.Equal(packet.GetString(), "XYZ-TEST123-FOO");
			Assert.Equal(packet.GetInt(), 200);
			Assert.Equal(packet.GetString(), "user1");
			Assert.Equal(packet.GetString(), "user2");
		}
	}
}
