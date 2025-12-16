using System;

namespace NoName.Core.Cards
{
	/// <summary>
	/// 유저가 소유한 카드 인스턴스의 ID 입니다. (동일 카드라도 개체로써 각각 존재)
	/// </summary>
	public readonly struct CardInstanceId : IEquatable<CardInstanceId>
	{
		public Guid Value { get; }

		public CardInstanceId(Guid value)
		{
			Value = value;
		}

		public bool Equals(CardInstanceId other) => Value.Equals(other.Value);

		public override bool Equals(object obj) => obj is CardInstanceId other && Equals(other);

		public override int GetHashCode() => Value.GetHashCode();

		public override string ToString() => Value.ToString();

		public static bool operator ==(CardInstanceId left, CardInstanceId right) => left.Equals(right);

		public static bool operator !=(CardInstanceId left, CardInstanceId right) => !left.Equals(right);
	}
}
