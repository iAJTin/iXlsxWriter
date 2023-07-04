
using System;

using Newtonsoft.Json;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a generic style
/// </summary>
[JsonArray(AllowNullItems = true)]
public interface IBorders : ICombinable<IBorders>, ICloneable, IOwner
{
}
