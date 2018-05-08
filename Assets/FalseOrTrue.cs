using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FalseOrTrue
{
	/// <summary>
    /// 偶数かどうかを返します
    /// </summary>
    public static bool IsEven(this int self)
    {
        return self % 2 == 0;
    }
}
