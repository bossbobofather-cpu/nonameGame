using System;

namespace NoName.Core.Cards
{
	/// <summary>
	/// 유저가 소유한 카드 인스턴스의 ID 입니다. (동일 카드라도 개체로써 각각 존재)
	/// </summary>
	public readonly record struct CardInstanceId(Guid Value);
}
