// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stride.Core.Assets;
using Stride.Core.Assets.Analysis;
using Stride.Core.Assets.Compiler;
using Stride.Core.BuildEngine;
using Stride.Core.IO;
using Stride.Core.Serialization;
using Stride.Graphics;

namespace Stride.Assets.GlobalData
{
    [AssetCompiler(typeof(GlobalDataAsset), typeof(AssetCompilationContext))]
    internal class GlobalDataAssetCompiler : AssetCompilerBase
    {
        public override IEnumerable<BuildDependencyInfo> GetInputTypes(AssetItem assetItem)
        {
            yield return new BuildDependencyInfo(typeof(GlobalDataAsset), typeof(AssetCompilationContext), BuildDependencyType.CompileAsset);
        }


        protected override void Prepare(AssetCompilerContext context, AssetItem assetItem, string targetUrlInStorage, AssetCompilerResult result)
        {
            var asset = (GlobalDataAsset)assetItem.Asset;
            result.BuildSteps = new AssetBuildStep(assetItem);
            result.BuildSteps.Add(new GlobalDataCompileCommand(targetUrlInStorage, assetItem, asset, context));
        }


        private class GlobalDataCompileCommand : AssetCommand<GlobalDataAsset>
        {
            private readonly AssetItem assetItem;

            private readonly GraphicsProfile graphicsProfile;
            private readonly ColorSpace colorSpace;

            private UFile assetUrl;


            public GlobalDataCompileCommand(string url, AssetItem assetItem, GlobalDataAsset value, AssetCompilerContext context)
                : base(url, value, assetItem.Package)
            {
                Version = 6;
                this.assetItem = assetItem;
                colorSpace = context.GetColorSpace();
                assetUrl = new UFile(url);

                graphicsProfile = context.GetGameSettingsAsset().GetOrCreate<RenderingSettings>(context.Platform).DefaultGraphicsProfile;
            }


            protected override void ComputeParameterHash(BinarySerializationWriter writer)
            {
                base.ComputeParameterHash(writer);

                writer.Serialize(ref assetUrl, ArchiveMode.Serialize);

                // TODO Compute hash from data, like:
                // Write graphics profile and color space
                //writer.Write(graphicsProfile);
                //writer.Write(colorSpace);
            }


            protected override Task<ResultStatus> DoCommandOverride(ICommandContext commandContext)
            {
                // TODO Save asset to disk, like:
                //var assetManager = new ContentManager(MicrothreadLocalDatabases.ProviderService);
                //assetManager.Save(assetUrl, result.Material);

                return Task.FromResult(ResultStatus.Successful);
            }


            public override string ToString()
            {
                return (assetUrl ?? "[File]") + " (Material) > " + (assetUrl ?? "[Location]");
            }
        }
    }
}
