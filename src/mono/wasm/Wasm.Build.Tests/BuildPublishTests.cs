// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using System.Linq;
using Wasm.Build.NativeRebuild.Tests;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

#nullable enable

namespace Wasm.Build.Tests
{
    public class BuildPublishTests : NativeRebuildTestsBase
    {
        public BuildPublishTests(ITestOutputHelper output, SharedBuildPerTestClassFixture buildContext)
            : base(output, buildContext)
        {
        }

        [Theory]
        [BuildAndRun(host: RunHost.Chrome, aot: false, config: "Release")]
        [BuildAndRun(host: RunHost.Chrome, aot: false, config: "Debug")]
        public void BuildThenPublishNoAOT(BuildArgs buildArgs, RunHost host, string id)
        {
            string projectName = $"build_publish_{buildArgs.Config}{s_unicodeChar}";

            buildArgs = buildArgs with { ProjectName = projectName };
            buildArgs = ExpandBuildArgs(buildArgs);

            // no relinking for build
            bool relinked = false;
            BuildProject(buildArgs,
                        id: id,
                        new BuildProjectOptions(
                        InitProject: () => File.WriteAllText(Path.Combine(_projectDir!, "Program.cs"), s_mainReturns42),
                        DotnetWasmFromRuntimePack: !relinked,
                        CreateProject: true,
                        Publish: false
                        ));

            Run();

            if (!_buildContext.TryGetBuildFor(buildArgs, out BuildProduct? product))
                throw new XunitException($"Test bug: could not get the build product in the cache");

            File.Move(product!.LogFile, Path.ChangeExtension(product.LogFile!, ".first.binlog"));

            _testOutput.WriteLine($"{Environment.NewLine}Publishing with no changes ..{Environment.NewLine}");

            // relink by default for Release+publish
            relinked = buildArgs.Config == "Release";
            BuildProject(buildArgs,
                        id: id,
                        new BuildProjectOptions(
                            DotnetWasmFromRuntimePack: !relinked,
                            CreateProject: false,
                            Publish: true,
                            UseCache: false));

            Run();

            void Run() => RunAndTestWasmApp(
                                buildArgs, buildDir: _projectDir, expectedExitCode: 42,
                                test: output => {},
                                host: host, id: id);
        }

        [Theory]
        [BuildAndRun(host: RunHost.Chrome, aot: true, config: "Release")]
        [BuildAndRun(host: RunHost.Chrome, aot: true, config: "Debug")]
        public void BuildThenPublishWithAOT(BuildArgs buildArgs, RunHost host, string id)
        {
            string projectName = $"build_publish_{buildArgs.Config}";

            buildArgs = buildArgs with { ProjectName = projectName };
            buildArgs = ExpandBuildArgs(buildArgs, extraProperties: "<_WasmDevel>true</_WasmDevel>");

            // no relinking for build
            bool relinked = false;
            (_, string output) = BuildProject(buildArgs,
                                    id,
                                    new BuildProjectOptions(
                                        InitProject: () => File.WriteAllText(Path.Combine(_projectDir!, "Program.cs"), s_mainReturns42),
                                        DotnetWasmFromRuntimePack: !relinked,
                                        CreateProject: true,
                                        Publish: false,
                                        Label: "first_build"));

            BuildPaths paths = GetBuildPaths(buildArgs);
            var pathsDict = GetFilesTable(buildArgs, paths, unchanged: false);

            string mainDll = $"{buildArgs.ProjectName}.dll";
            var firstBuildStat = StatFiles(pathsDict.Select(kvp => kvp.Value.fullPath));
            Assert.False(firstBuildStat["pinvoke.o"].Exists);
            Assert.False(firstBuildStat[$"{mainDll}.bc"].Exists);

            CheckOutputForNativeBuild(expectAOT: false, expectRelinking: relinked, buildArgs, output);

            Run(expectAOT: false);

            if (!_buildContext.TryGetBuildFor(buildArgs, out BuildProduct? product))
                throw new XunitException($"Test bug: could not get the build product in the cache");

            File.Move(product!.LogFile, Path.ChangeExtension(product.LogFile!, ".first.binlog"));

            _testOutput.WriteLine($"{Environment.NewLine}Publishing with no changes ..{Environment.NewLine}");

            // relink by default for Release+publish
            (_, output) = BuildProject(buildArgs,
                                    id: id,
                                    new BuildProjectOptions(
                                        DotnetWasmFromRuntimePack: false,
                                        CreateProject: false,
                                        Publish: true,
                                        UseCache: false,
                                        Label: "first_publish"));

            var publishStat = StatFiles(pathsDict.Select(kvp => kvp.Value.fullPath));
            Assert.True(publishStat["pinvoke.o"].Exists);
            Assert.True(publishStat[$"{mainDll}.bc"].Exists);
            CheckOutputForNativeBuild(expectAOT: true, expectRelinking: false, buildArgs, output);
            CompareStat(firstBuildStat, publishStat, pathsDict.Values);

            Run(expectAOT: true);

            // second build
            (_, output) = BuildProject(buildArgs,
                                        id: id,
                                        new BuildProjectOptions(
                                            InitProject: () => File.WriteAllText(Path.Combine(_projectDir!, "Program.cs"), s_mainReturns42),
                                            DotnetWasmFromRuntimePack: !relinked,
                                            CreateProject: true,
                                            Publish: false,
                                            Label: "second_build"));
            var secondBuildStat = StatFiles(pathsDict.Select(kvp => kvp.Value.fullPath));

            // no relinking, or AOT
            CheckOutputForNativeBuild(expectAOT: false, expectRelinking: false, buildArgs, output);

            // no native files changed
            pathsDict.UpdateTo(unchanged: true);
            CompareStat(publishStat, secondBuildStat, pathsDict.Values);

            void Run(bool expectAOT) => RunAndTestWasmApp(
                                buildArgs with { AOT = expectAOT },
                                buildDir: _projectDir, expectedExitCode: 42,
                                host: host, id: id);
        }

        void CheckOutputForNativeBuild(bool expectAOT, bool expectRelinking, BuildArgs buildArgs, string buildOutput)
        {
            AssertSubstring($"{buildArgs.ProjectName}.dll -> {buildArgs.ProjectName}.dll.bc", buildOutput, expectAOT);
            AssertSubstring($"{buildArgs.ProjectName}.dll.bc -> {buildArgs.ProjectName}.dll.o", buildOutput, expectAOT);

            AssertSubstring("pinvoke.c -> pinvoke.o", buildOutput, expectRelinking || expectAOT);
        }

    }
}
