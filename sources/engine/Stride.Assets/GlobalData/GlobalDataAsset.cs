// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Stride.Core;
using Stride.Core.Assets;

namespace Stride.Assets.GlobalData;

[DataContract(nameof(GlobalDataAsset))]
[AssetDescription(FileExtension)]
[AssetContentType(typeof(GlobalDataObject))]
[AssetFormatVersion(StrideConfig.PackageName, CurrentVersion, "2.0.0.0")]
public partial class GlobalDataAsset : Asset
{
    private const string CurrentVersion = "1.0.0.0";
    
    public const string FileExtension = ".sddata";
    
    
    public string SubclassName { get; set; }
}
