// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Stride.Core;
using Stride.Core.Assets;

namespace Stride.Assets.DataAssets;

[DataContract(nameof(DataAsset))]
[AssetDescription(FileExtension, AlwaysMarkAsRoot = true, AllowArchetype = false)]
public partial class DataAsset : Asset
{
    public const string FileExtension = ".sddata";
}
