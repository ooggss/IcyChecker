﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
namespace SolidityAST
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Logging;

    class TestMain
    {
        public static void Main(string[] args)
        {
            DirectoryInfo debugDirectoryInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            string workingDirectory = debugDirectoryInfo.Parent.Parent.Parent.Parent.FullName;
            string solcPath = "D:\\IcyChecker\\Translator\\Tool\\solc.exe";
            string testDir = "D:\\IcyChecker\\Translator\\Test";

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()); // .AddConsole(LogLevel.Information);
            ILogger logger = loggerFactory.CreateLogger("SolidityAST.RegressionExecutor");

            RegressionExecutor executor = new RegressionExecutor(solcPath, testDir, logger);
            executor.BatchExecute();
            Console.ReadLine();
        }

        // Legacy entry point for testing
        private static void XXMain(string[] args)
        {
            DirectoryInfo debugDirectoryInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            // string workingDirectory = debugDirectoryInfo.Parent.Parent.Parent.Parent.FullName;
            // string filename = "AssertTrue.sol";
            // string solcPath = workingDirectory + "\\Tool\\solc.exe";
            // string filePath = workingDirectory + "\\Test\\regression\\" + filename;
            var solcPath = "D:\\IcyChecker\\Translator\\Tool\\solc.exe";
            var filePath = "D:\\IcyChecker\\Translator\\Test\\Table.sol";
            SolidityCompiler compiler = new SolidityCompiler();
            var compilerOutput = compiler.Compile(solcPath, filePath);
            var ast = new AST(compilerOutput);

            Console.WriteLine(ast.GetSourceUnits());
            Console.ReadLine();
        }
    }
}
